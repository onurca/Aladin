using Framework.Model;
using Framework.Model.Logger;
using Framework.Model.Logger.Enum;
using System;

namespace Framework.Core.Logger
{
    public interface ILogger
    {
        void Info(InfoType type,string message, string location);
        Guid Error(Exception Ex, string location = "");
        Guid Fatal(Exception Ex, string location = "");
        Guid Warning(Exception Ex, string location = "");
    }

    public class Logger : ILogger
    {
        private IUnitOfWork _unitOfWork;

        public Logger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid Error(Exception Ex, string location = "")
        {
            var log = ConvertException(Ex, LogLevel.Error, location);
            _unitOfWork.GetRepository<Log>().Create(log);
            Save();
            return log.CorrelationId;
        }

        public Guid Fatal(Exception Ex, string location = "")
        {
            var log = ConvertException(Ex, LogLevel.Fatal, location);
            _unitOfWork.GetRepository<Log>().Create(log);
            Save();
            return log.CorrelationId;
        }

        public void Info(InfoType type,string message,string location)
        {
            var info = new Info(message, location,type);
            _unitOfWork.GetRepository<Info>().Create(info);
            Save();
        }

        public Guid Warning(Exception Ex, string location = "")
        {
            var log = ConvertException(Ex, LogLevel.Warning, location);
            _unitOfWork.GetRepository<Log>().Create(log);
            Save();
            return log.CorrelationId;
        }

        private Log ConvertException(Exception Ex, LogLevel logLevel, string location = "")
        {
            var retVal = new Log
            {
                Message = Ex.Message,
                StackTrace = Ex.StackTrace,
                LogLevel = logLevel,
                Location = location,
                CorrelationId = Guid.NewGuid()
            };
            return retVal;
        }

        private void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
