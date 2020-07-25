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
    public class SegmentationController : Controller
    {
        private readonly SegmentationProxy _segmentationProxy;
        public SegmentationController()
        {
            _segmentationProxy = new SegmentationProxy();
        }
        // GET: Segmentation
        public ActionResult Index()
        {
            var response = Task.Run(() => _segmentationProxy.GetSegmentsAsync());
            return View("~/Views/Segmentation/List.cshtml",response.Result.List);
        }

        // GET: Segmentation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Segmentation/Create
        public ActionResult Create()
        {
            var response = Task.Run(() => _segmentationProxy.GetSegmentsAsync());
            List<SelectListItem> items = response.Result.List.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.name,
                    Value = d.id.ToString(),
                    Selected = false
                };
            });
            ViewBag.segments = items;
            return View("~/Views/Segmentation/Create.cshtml");
        }

        // POST: Segmentation/Create
        [HttpPost]
        public JsonResult CreateSegmentation(SegmentationRequest segmentationRequest)
        {
            var response = Task.Run(() => _segmentationProxy.CreateSegmentationAsync(segmentationRequest));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);

        }

        // POST: Segmentation/Update
        [HttpPost]
        public ActionResult Update(SegmentationModel segmentationModel)
        {
            var response = Task.Run(() => _segmentationProxy.UpdateSegmentationAsync(segmentationModel));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }


        // POST: Segmentation/Delete
        [HttpPost]
        public ActionResult Delete(SegmentationModel segmentationModel)
        {
            var response = Task.Run(() => _segmentationProxy.DleteSegmentationAsync(segmentationModel));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }
    }
}
