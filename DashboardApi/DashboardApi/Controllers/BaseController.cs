using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DashboardApi.Controllers
{


    //[Authorize]
    public class BaseController : Controller
    {
        public override JsonResult Json(object obj)
        {

            return new JsonResult(obj, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Include });
        }
    }
}
