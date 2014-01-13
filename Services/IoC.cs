using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Services
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                x.For<Repository.IUnitOfWork>().Use<Services.UnitOfWork<DAL.UsersAccountContext>>();
            });
            return ObjectFactory.Container;
        }
    }
}
