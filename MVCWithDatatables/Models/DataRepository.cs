using MVCWithDatatables.Models.DataTables;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace MVCWithDatatables.Models
{
    public class DataRepository
    {
        private readonly ISession _session;

        public DataRepository(ISession session)
        {
            _session = session;
        }

        public IList<Company> Companies(DataTableParamModel tableParam)
        {
            IQueryable<Company> companies;
            if (!string.IsNullOrEmpty(tableParam.Search.Value))
            {
                var filterCol = from i in tableParam.Columns
                                where i.Searchable
                                select i.Name;

                StringBuilder filterString =  new StringBuilder();
                bool beginFlag = true;
                foreach (string col in filterCol) // Loop through all strings
                {
                    if(beginFlag)
                    {
                        beginFlag = false;
                    }
                    else
                    {
                        filterString.Append(" Or ");
                    }
                    filterString.AppendFormat("{0}.ToLower().Contains(@0)", col);
                }
                companies = _session.Query<Company>()
                                .Where(filterString.ToString(), tableParam.Search.Value.ToLower())
                                .Skip(tableParam.Start)
                                .Take(tableParam.Length);
            }
            else
            {
                companies = _session.Query<Company>()
                               .Skip(tableParam.Start)
                               .Take(tableParam.Length);
            }
            return companies.ToList();
        }

        public int TotalCompanies()
        {
            return _session.Query<Company>().Count();
        }

        public int TotalCompaniesFiltered(DataTableParamModel tableParam)
        {
            if (!string.IsNullOrEmpty(tableParam.Search.Value))
            {
                var filterCol = from i in tableParam.Columns
                                where i.Searchable
                                select i.Name;
                StringBuilder filterString = new StringBuilder();
                bool beginFlag = true;
                foreach (string col in filterCol) // Loop through all strings
                {
                    if (beginFlag)
                    {
                        beginFlag = false;
                    }
                    else
                    {
                        filterString.Append(" Or ");
                    }
                    filterString.AppendFormat("{0}.ToLower().Contains(@0)", col);
                }
                return _session.Query<Company>()
                                .Where(filterString.ToString(), tableParam.Search.Value.ToLower()).Count();
            }
            return _session.Query<Company>().Count();
        }
    }
}