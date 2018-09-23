using HotelProductWebAPI.Entities;
using HotelProductWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Service
{
    public class LogService
    {
        private LogSQLRepository _repository;
        private static LogService _logger;
        private LogService()
        {
            _repository = new LogSQLRepository();

        }

        public static LogService GetLogger()
        {
            if (_logger == null)
                _logger = new LogService();
            return _logger;
        }

        public bool LogAction(string request, string response, string comment)
        {
            Log log = new Log()
            {
                Request = request,
                Response = response,
                Comment = comment
            };
            return this._repository.Create(log);
        }
    }
}