using ActAPI.Models;
using ActAPI.Services.Abstract;
using System.Net.Http.Headers;

namespace ActAPI.Handlers
{
    public static class FileHandler
    {
        
        public async static Task<string> UploadFile(int? offlineExamId,IFormFile formFile, int objId, char type)
        {
            try
            {

                // IFormFile formFile = this.Request.Form.Files[0];

              //  int? offlineExamId = await GetOfflineExamIdByType(questionService,questionAnswerService,objId, type);
                if (offlineExamId.HasValue&& offlineExamId > 0)
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
                      //  SaveFilePath(questionService,questionAnswerService,objId, dbPath, type);
                        return   dbPath ;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private async static void SaveFilePath(IQuestionService questionService, IQuestionAnswerService questionAnswerService,int objId, string path, char type)
        {
            if (type == 'q')
            {
                Question? q = await questionService.Get(objId);
                Question? source = q;
                source.PhotoName = path;
                await questionService.Update(q, source);
            }
            else
            {
                QuestionAnswer? a = await questionAnswerService.Get(objId);
                QuestionAnswer? source = a;
                source.PhotoName = path;
                await questionAnswerService.Update(a, source);

            }
        }
        private async static Task<int?> GetOfflineExamIdByType(IQuestionService questionService, IQuestionAnswerService questionAnswerService,int objId, char type)
        {

            if (type == 'q')
            {
                Question? q = await questionService.Get(objId);
                if (q != null)
                {
                    return q.Section?.OfflineExamId;
                }
                else { return null; }
            }
            else if (type == 'a')
            {
                QuestionAnswer? a = await questionAnswerService.Get(objId);
                if (a != null)
                {
                    return a.Question?.Section?.OfflineExamId;
                }
                else { return null; }
            }
            else
            {
                return -1;
            }
        }
    }
}

