using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Model.Northwind;
using Model.ReportService;

namespace Repository.ReportService
{
    public interface IOrdersRepository : RSinterface<Orders> { }
    public interface IUserProfileRepository : RSinterface<UserProfile> { }
    public interface Iwebpages_RolesRepository : RSinterface<webpages_Roles> { }
    public interface Iwebpages_UsersInRolesRepository : RSinterface<webpages_UsersInRoles> { }
    
    public interface RSinterface<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
    }
}
