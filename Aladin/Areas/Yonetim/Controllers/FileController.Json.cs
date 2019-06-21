using Aladin.Business.Interfaces;
using Aladin.Controllers;
using Aladin.Core.Filter;
using Framework.Core.Extensions;
using Framework.Model.Authentication.Enum;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M = Aladin.Model;

namespace Aladin.Areas.Yonetim.Controllers
{
    public class FileController : AuthenticatedController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [CustomAuthentication(AuthenticationType.Anonymous)]
        public JsonResult Get(Guid referenceGuid)
        {
            List<M.File> retVal = _fileService.Get(referenceGuid);

            return Result(new Result<List<M.File>>(retVal));
        }

        public JsonResult Save(Guid ReferenceGuid)
        {
            M.File file = new M.File();

            try
            {
                foreach (string postedFile in Request.Files)
                {
                    HttpPostedFileBase File = Request.Files[postedFile];


                    if (File != null && File.ContentLength > 0)
                    {
                        DirectoryInfo FilesFolder = new DirectoryInfo(string.Format("{0}\\Files", Server.MapPath(@"\")));
                        string Extension = Path.GetExtension(File.FileName);
                        Guid GuidName = Guid.NewGuid();
                        string FileName = GuidName.ToString() + Extension;
                        string FilePath = string.Format("{0}\\{1}", FilesFolder.ToString(), FileName);

                        File.SaveAs(FilePath);

                        file.ContentType = File.ContentType;
                        file.Extension = Extension;
                        file.GuidName = GuidName;
                        file.Name = File.FileName;
                        file.Path = FilePath;
                        file.ReferenceGuid = ReferenceGuid;
                        file.Size = File.ContentLength;

                        file = _fileService.Create(file);
                    }
                }

            }
            catch (Exception Ex)
            {
                throw new HttpException(HttpStatusCode.InternalServerError.ToInt(), Definition.Message.Dropzone.Error);
            }

            return Result(new Result<M.File>(file));
        }

        public JsonResult Delete(Guid ID, string FileGuidName)
        {
            var filesFolder = new DirectoryInfo(string.Format("{0}\\Files", Server.MapPath(@"\")));

            string filePath = string.Format("{0}\\{1}", filesFolder.ToString(), FileGuidName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _fileService.Delete(filePath);

            return Result(new Result());
        }
    }
}