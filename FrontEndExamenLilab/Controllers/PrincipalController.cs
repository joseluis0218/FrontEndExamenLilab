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
    public class PrincipalController : Controller
    {
        private readonly ClientProxy _clientProxy;
        private readonly GenericProxy _genericProxy;

        public PrincipalController()
        {
            _clientProxy = new ClientProxy();
            _genericProxy = new GenericProxy();
        }
        // GET: Principal
        public ActionResult Index()
        {
            var response = Task.Run(() => _genericProxy.GetMonthsAsync());
            List<SelectListItem> items = response.Result.List.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.monthName,
                    Value = d.monthNumber.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public JsonResult GetClientsByFilter(ClientRequest filterRequest)
        {

            var response = Task.Run(() => _clientProxy.GetClientsByFilterAsync(filterRequest));
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View("~/Views/Principal/Create.cshtml");
        }
        [HttpPost]
        public JsonResult CreateClient(ClientModel clientModel)
        {
            var response = Task.Run(() => _clientProxy.CreateClientAsync(clientModel));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }
    }
}
