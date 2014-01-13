using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Northwind;
using DAL;
using System.Data.Entity;

namespace Repository.ReportService
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IReportServiceContext _context;

        public OrdersRepository(IUnitOfWork uow)
        {
            _context = uow.Context as IReportServiceContext;
        }

        public IQueryable<Orders> All
        {
            get { return _context.Orders; }
        }

        public IQueryable<Orders> AllIncluding(params System.Linq.Expressions.Expression<Func<Orders, object>>[] includeProperties)
        {
            IQueryable<Orders> query = _context.Orders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Orders Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public void InsertOrUpdate(Orders entity)
        {
            if (entity.OrderID == default(int))
            {
                _context.SetAdd(entity);
            }
            else
            {
                _context.SetModified(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Orders.Find(id);
            _context.Orders.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
