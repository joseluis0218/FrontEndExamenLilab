using FrontEndExamenLilab.Models;
using FrontEndExamenLilab.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontEndExamenLilab.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ActivityProxy _activityProxy;
        private readonly ClientProxy _clientyProxy;

        public ActivityController()
        {
            _activityProxy = new ActivityProxy();
            _clientyProxy = new ClientProxy();
        }
        // GET: Activity
        public ActionResult Index()
        {
            var response = Task.Run(() => _activityProxy.GetActiviesAsync());
            //var response2 = Task.Run(() => _clientyProxy.GetClientsAsync());

            //List<SelectListItem> items = response2.Result.List.ConvertAll(d => {
            //    return new SelectListItem()
            //    {
            //        Text = d.firstName + " " +  d.lastName,
            //        Value = d.id.ToString(),
            //        Selected = false
            //    };
            //});

            //ViewBag.clients = items;
            return View(response.Result.List);
        }

        public ActionResult Create()
        {
            var response = Task.Run(() => _clientyProxy.GetClientsAsync());

            List<SelectListItem> items = response.Result.List.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.firstName + " " + d.lastName,
                    Value = d.id.ToString(),
                    Selected = false
                };
            });

            ViewBag.clients = items;


            return View("~/Views/Activity/Create.cshtml");
        }

        [HttpPost]
        public JsonResult CrateActivity(ActivityModel activityModel)
        {
            var response = Task.Run(() => _activityProxy.CreateActivityAsync(activityModel));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);

        }
    }
}