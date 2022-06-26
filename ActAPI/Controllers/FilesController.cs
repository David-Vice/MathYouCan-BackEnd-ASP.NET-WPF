using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ActAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IQuestionService _questionService;
        private readonly IQuestionAnswerService _questionAnswerService;
        public FilesController(IQuestionService questionService,IQuestionAnswerService questionAnswerService)
        {
            _questionService=questionService;
            _questionAnswerService=questionAnswerService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> UploadFile(IFormFile formFile,int objId , char type)
        {
            try
            {

               // IFormFile formFile = this.Request.Form.Files[0];

                int? offlineExamId = await GetOfflineExamIdByType(objId,type);
                if (offlineExamId.HasValue&&offlineExamId>0)
                {

                    var folderName = Path.Combine("Uploads", $"{offlineExamId}");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (!Directory.Exists(pathToSave))
                    {
                        Directory.CreateDirectory(pathToSave);
                    }
                    if (formFile.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                        string ext = Path.GetExtension(fileName);
                        fileName = $"{type}{objId}{ext}";
                       // var fileName = $"{type}{objId}"+;
                        
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        SaveFilePath(objId, dbPath, type);
                        return Ok(new { dbPath });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void SaveFilePath(int objId,string path, char type)
        {
            if (type == 'q')
            {
                Question? q = await _questionService.Get(objId);
                Question? source = q;
                source.PhotoName = path;
                await _questionService.Update(q, source);
            }
            else
            {
                QuestionAnswer? a = await _questionAnswerService.Get(objId);
                QuestionAnswer? source= a;
                source.PhotoName= path;
                await _questionAnswerService.Update(a, source);
                
            }
        }
        private async Task<int?> GetOfflineExamIdByType(int objId,char type)
        {

            if (type=='q')
            {
                Question? q=await _questionService.Get(objId);
                if (q != null)
                {
                    return q.Section?.OfflineExamId;
                }
                else { return null; }
            }else if (type == 'a')
            {
                QuestionAnswer? a = await _questionAnswerService.Get(objId);
                if (a != null)
                {
                    return a.Question?.Section?.OfflineExamId;
                }
                else { return null; }
            }
            else
            {
                return - 1;
            }
        }
    }
    
}
