using System;
using System.Collections.Generic;
using System.Web;
using M = Aladin.Model;

namespace Aladin.Business.Interfaces
{
    public interface IFileService
    {
        List<M.File> Get(Guid referenceGuid);
        M.File Create(M.File file);
        void Delete(string filePath);
    }

}
