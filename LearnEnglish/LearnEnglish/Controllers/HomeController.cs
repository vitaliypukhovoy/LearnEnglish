using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnEnglish.Models;

namespace LearnEnglish.Controllers
{
    //[HttpGet]    
    public class HomeController : Controller
    {


        public ActionResult Index2()
        {
            return View();
        }
        public ContextDB db = new ContextDB();
        
      //  [HttpGet]
        public ActionResult Index()
        {
            //db.ContextOptions.LazyLoadingEnabled = false
            this.ViewBag.flag = this.TempData["flag"];
            //ViewBag.Data = db.NewWords.Include("Topic")
            //.Where(c => c.IdTopic == 1);

            ViewBag.IdTopic =  new SelectList(db.Topics, "IdTopic", "TopicName");
            return View();
        }

      //  [HttpPost]
        public ActionResult TableWords(int IdTopic=1)
        {
            var data = db.NewWords.Include("Topic")
               .Where(c => c.IdTopic == IdTopic);
             //if (Request.IsAjaxRequest() && data != null)
           // {
                
                return PartialView(data);
            //}

          //    return View("Index");
        }




         [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateWord(NewWord world)
        {
            if (ModelState.IsValid)
            {
                db.NewWords.Add(world);
                db.SaveChanges();
                TempData["flag"] = 1;
                return RedirectToAction("Index");
            }
            this.TempData["flag"] = 2;
            return RedirectToAction("Index");
        }
         [HttpPost]
         public ActionResult CreateTopic(string topicName )
         {
              if (ModelState.IsValid)
              {
               db.Topics.Add(new Topic{ TopicName=topicName});
               db.SaveChanges();
              return RedirectToAction("Index");             
              }         
             return RedirectToAction("Index");
         }
         [System.Web.Mvc.HttpPost]
         public ActionResult ModalView()
         {
             ViewBag.IdTopic = new SelectList(db.Topics,"IdTopic","TopicName");
             return PartialView();         
         }

         public ActionResult ModalTopic()
         {
             return PartialView();
         }
      
         public ActionResult Remove(List<int> id)
         {
             foreach (var item in id)
             {
                 NewWord wds = db.NewWords.Find(item);
                 if (wds != null)
                 {
                     db.Entry(wds).State = System.Data.Entity.EntityState.Deleted;
                 }
             }
                 db.SaveChanges();
                // return RedirectToAction("Index");
             
             //return RedirectToAction("Index");
             return Json(id, JsonRequestBehavior.AllowGet);
         }

       

    
    }
}
