using Aladin.Business.Interfaces;
using Aladin.Business.Services.Common;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DB = Aladin.Data;
using M = Aladin.Model;

namespace Aladin.Business.Services
{
    public class FileService : Service, IFileService
    {
        IRepository<DB.File> _fileRepo;

        public FileService()
        {
            _fileRepo = UnitOfWork.GetRepository<DB.File>();
        }

        public M.File Create(M.File model)
        {
            var file = new DB.File
            {
                ContentType = model.ContentType,
                Extension = model.Extension,
                GuidName = model.GuidName,
                Name = model.Name,
                Path = model.Path,
                ReferenceGuid = model.ReferenceGuid,
                Size = model.Size
            };

            _fileRepo.Create(file);
            UnitOfWork.SaveChanges();

            model.ID = file.ID;

            return model;
        }

        public void Delete(string filePath)
        {
            _fileRepo.Delete(x => x.Path == filePath);
            UnitOfWork.SaveChanges();
        }

        public List<M.File> Get(Guid ReferenceGuid)
        {
            return _fileRepo.GetAll(x => x.ReferenceGuid == ReferenceGuid).OrderBy(x => x.Order).Select(k => new M.File
            {
                ContentType = k.ContentType,
                Extension = k.Extension,
                GuidName = k.GuidName,
                Name = k.Name,
                Order = k.Order,
                Path = k.Path,
                ReferenceGuid = k.ReferenceGuid,
                Size = k.Size,
                ID = k.ID
            }).ToList();
        }
    }
}
