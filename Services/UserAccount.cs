﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Repository.ReportService;

namespace Services
{
    public class UserAccount
    {
        private readonly UnitOfWork<UsersAccountContext> _uow;
        private readonly UserProfileRepository _user;
        private readonly webpages_RolesRepository _roles;
        private readonly webpages_UsersInRolesRepository _inRoles;

        public UserAccount()
        {
            _uow = new UnitOfWork<UsersAccountContext>();
            _user = new UserProfileRepository(_uow);
            _roles = new webpages_RolesRepository(_uow);
            _inRoles = new webpages_UsersInRolesRepository(_uow);
        }

        public UserProfileRepository UserRepo
        {
            get { return _user; }
        }

        public webpages_RolesRepository RoleRepo
        {
            get { return _roles; }
        }

        public webpages_UsersInRolesRepository InRoleRepo
        {
            get { return _inRoles; }
        }

        public void Save()
        {
            _uow.Save();
        }
    }
}
