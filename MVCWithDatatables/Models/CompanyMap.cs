using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithDatatables.Models
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.Town);
        }
        
    }
}