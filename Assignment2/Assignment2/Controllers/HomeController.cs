using Assignment2.Models;
using Assignment2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private IExerciseRepository<Exercise> exRepository;
        private const int pageSize = 10;
        private static int flag = 0;
        public HomeController()
        {
            this.exRepository = new ExerciseRepository<Exercise>();
            if (flag == 0)
            {
                SampleDataLoad();
                flag = 1;
            }
            
        }
        private void SampleDataLoad()
        {
            
            for(var i = 11; i >1; i--)
            {
                var ex = new Exercise();
                ex.ExerciseName = "Assignment " + i;
                ex.ExerciseDate = DateTime.Today.AddDays(-i);
                ex.DurationInMinutes = 23 + i;
                exRepository.Create(ex);
            }
        }
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var exresult = exRepository.GetAll().ToPagedList(pageNumber, pageSize);
            return View(exresult);
        }
       [HttpPost]
        public ActionResult Index(int? page,string searchString)
        {
            int pageNumber = (page ?? 1);
            var exresult = exRepository.GetByName(searchString).ToPagedList(pageNumber, pageSize);
            return View(exresult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            return PartialView("Create",new ExerciseViewModel());
        }
        [HttpPost]
        public ActionResult ValidateCreate(ExerciseViewModel exviewModel)
        {

            var exresult = exRepository.GetAll().ToList().Where(x => x.ExerciseName.Equals(exviewModel.ExerciseName) && x.ExerciseDate.Equals(exviewModel.ExerciseDate));
            if (exresult.Any())
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            else
            {

                if (ModelState.IsValid)
                {
                    ViewBag.MyMessage = "Data is correct! Save it!";
                    return PartialView("Create", exviewModel);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            return PartialView("Create", exviewModel);
        }

        [HttpPost]
        public ActionResult Create(ExerciseViewModel exviewModel)
        {
                    var ex = new Exercise();
                    ex.ExerciseName = exviewModel.ExerciseName;
                    ex.ExerciseDate = exviewModel.ExerciseDate;
                    ex.DurationInMinutes = exviewModel.DurationInMinutes;
                    ViewBag.MyMessage = "Saved successfully";
                    exRepository.Create(ex);
                    return RedirectToAction("Index");
        }
    }
}