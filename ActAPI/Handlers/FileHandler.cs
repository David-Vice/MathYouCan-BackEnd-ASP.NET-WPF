﻿using ActAPI.Models;
using ActAPI.Services.Abstract;
using System.Net.Http.Headers;

namespace ActAPI.Handlers
{
    public static class FileHandler
    {
        
        public async static Task<string> UploadFile(IWebHostEnvironment webHostEnvironment,int? offlineExamId,IFormFile formFile, int objId, char type)
        {
            try
            {

                // IFormFile formFile = this.Request.Form.Files[0];

              //  int? offlineExamId = await GetOfflineExamIdByType(questionService,questionAnswerService,objId, type);
                
                if (offlineExamId.HasValue&& offlineExamId > 0)
                {

                    //var folderName = Path.Combine("Uploads", $"{offlineExamId}");
                    string rootPath = "";
                    var pathToSave = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", $"{offlineExamId}");
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
                     //   var dbPath = Path.Combine(folderName, fileName);
                        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        string result = fullPath;
                        if (webHostEnvironment.IsProduction())
                        {
                            result = "Uploads/" + $"{offlineExamId}" + $"/{fileName}";
                        }
                      //  SaveFilePath(questionService,questionAnswerService,objId, dbPath, type);
                        
                        return   result+"&"+fullPath;
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
       public static void Delete(string? path)
       {
            if (path != null&&path!="")
            {
                string s = path.Split("&")[1];
                FileInfo fi = new FileInfo(s);
                if (fi.Exists)
                {

                    File.Delete(s);
                }
            }

       }
    }
}

