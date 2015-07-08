using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithDatatables.Models
{
    public class DataRepository
    {
        private readonly ISession _session;

        public DataRepository(ISession session)
        {
            _session = session;
        }

        public IList<Company> Companies()
        {
            var companies = _session.Query<Company>()
                                  .OrderByDescending(p => p.Name)
                                  .ToList();
            return companies;
        }

    }
}