using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ReportService;
using DAL;
using System.Data.Entity;

namespace Repository.ReportService
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IUsersAccountContext _context;

        public UserProfileRepository(IUnitOfWork uow)
        {
            _context = uow.Context as IUsersAccountContext;
        }

        public IQueryable<UserProfile> All
        {
            get { return _context.UserProfile; }
        }

        public IQueryable<UserProfile> AllIncluding(params System.Linq.Expressions.Expression<Func<UserProfile, object>>[] includeProperties)
        {
            IQueryable<UserProfile> query = _context.UserProfile;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public UserProfile Find(int id)
        {
            return _context.UserProfile.Find(id);
        }

        public void InsertOrUpdate(UserProfile entity)
        {
            if (entity.UserId == default(int))
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
            var entity = _context.UserProfile.Find(id);
            _context.UserProfile.Remove(entity);
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
