using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithDatatables.Models.DataTables;
using Newtonsoft.Json;
using MVCWithDatatables.Models;
using NHibernate;

namespace MVCWithDatatables.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataRepository _repository;

        public HomeController()
        {
            ISession session = NHibernateHelper.OpenSession();
            _repository = new DataRepository(session);
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult AjaxHandler(DataTableParamModel param)
        {
            var companies = _repository.Companies(param);
            var result = from c in companies select new[] { Convert.ToString(c.Id), c.Name, c.Address, c.Town, Convert.ToString(param.Columns.Count)};
            //var result = from c in companies select new[] { Convert.ToString(c.Id), c.Name, c.Address, c.Town, Convert.ToString(param.columns[0]["search"]) + "asf" };
            return Content(JsonConvert.SerializeObject(new
            {
                draw = param.Draw,
                recordsTotal = _repository.TotalCompanies(),
                recordsFiltered = _repository.TotalCompaniesFiltered(param),
                data = result
            }), "application/json");
        }
    }
}