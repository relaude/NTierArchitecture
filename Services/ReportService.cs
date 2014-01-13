
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Repository.ReportService;
using Breeze.WebApi;
using Newtonsoft.Json.Linq;

namespace Services
{
    public class ReportService
    {
        private readonly UnitOfWork<ReportServiceContext> _uow;
        private readonly OrdersRepository _order;
        

        public ReportService()
        {
            _uow = new UnitOfWork<ReportServiceContext>();
            _order = new OrdersRepository(_uow);
            
        }

        public OrdersRepository OrderRepo
        {
            get { return _order; }
        }

        public string Metadata()
        {
            return _uow.Context.Metadata();
        }

        public SaveResult BreezeSaveChanges(JObject saveBundle)
        {
            return _uow.Context.BreezeSaveChanges(saveBundle);
        }

        public void Save()
        {
            _uow.Save();
        }
    }
}
