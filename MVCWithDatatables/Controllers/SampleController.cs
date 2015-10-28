using MVCWithDatatables.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithDatatables.Controllers
{
    public class SampleController : Controller
    {
        private readonly DataRepository _repository;

        public SampleController()
        {
            ISession session = NHibernateHelper.OpenSession();
            _repository = new DataRepository(session);
        }
        // GET: Sample
        public ActionResult Index()
        {
            return View(_repository.Companies());
        }
    }
}