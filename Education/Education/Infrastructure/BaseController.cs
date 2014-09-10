using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Implementation;

namespace Education.Infrastructure
{
    public class BaseController : Controller
    {
        public readonly IEducationRepository EduRepo;
        public BaseController() : this(new EducationRepository()) { }

        public BaseController(IEducationRepository repository)
        {
            EduRepo = repository;
        }
       

    }
}
