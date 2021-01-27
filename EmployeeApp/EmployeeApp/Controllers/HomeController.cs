using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OurDatabase DB = new OurDatabase();
            List<EmployeeModel> Employees;


            if (TempData["Datastore"] == null)
            {

                //Get the list of Employees from the DB
                Employees = DB.Employees;
                //And Store it in TempData
                TempData["Datastore"] = Employees;
            }
            else
            {
                //Get already stored data from TempData
                Employees = (List<EmployeeModel>)TempData["Datastore"];
                //Ask TempData to keep the data till the next request
                TempData.Keep();
            }


            return View(Employees);
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
            //Ask TempData to keep the data till the next request. Otherwise Tempdata will discard it.
            TempData.Keep();

            //Empty Employees Object
            EmployeeModel model = new EmployeeModel();

            //Pass it to the View
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel m)
        {
            //parameter m is filled from the view using ModelBinder

            List<EmployeeModel> Employees;

            if (ModelState.IsValid)
            {
                //Get the Employees collection from TempData
                Employees = (List<EmployeeModel>)TempData["Datastore"];

                //Add the model received from the View to the collection
                Employees.Add(m);

                //Ask TempData to keep the data till the next request
                TempData.Keep();

                //Go to List Action Method
                return RedirectToAction("Index");
            }

            //Error Condition. Ask TempData to keep the data till the next request
            TempData.Keep();
            //Back to Create. Rectify errors and re Post 
            return View(m);
        }
        public ActionResult Edit(int Id)
        {
            List<EmployeeModel> Employees;

            Employees = (List<EmployeeModel>)TempData["Datastore"];
            EmployeeModel model = Employees.FirstOrDefault(x => x.Id == Id);

            TempData.Keep();
            return View(model);

        }


        [HttpPost]
        public ActionResult Edit(EmployeeModel m)
        {
            //parameter m is filled from the view using ModelBinder

            List<EmployeeModel> Employees;

            if (ModelState.IsValid)
            {
                // Get the list of Employees from the datastore
                Employees = (List<EmployeeModel>)TempData["Datastore"];

                //Get the model being edited from the employee collection
                EmployeeModel model = Employees.FirstOrDefault(x => x.Id == m.Id);

                //Update the model
                model.Id = m.Id;
                model.BirthDate = m.BirthDate;
                model.Tin = m.Tin;
                model.EmployeeType = m.EmployeeType;
                model.Salary = m.Salary;
                model.Absences = m.Absences;
                model.WorkDays = m.WorkDays;
                model.FinalSalary = m.FinalSalary;

                //Tempdata to keep the data till the next request
                TempData.Keep();
                return RedirectToAction("Index");
            }

            TempData.Keep();
            return View(m);
        }
        public ActionResult Details(int Id)
        {
            //id of the Employee to Edit

            List<EmployeeModel> Employees;

            //Get Employee Collection
            Employees = (List<EmployeeModel>)TempData["Datastore"];

            //Get the employee with the selected id from the employees collection
            EmployeeModel model = Employees.FirstOrDefault(x => x.Id == Id);

            TempData.Keep();

            //Send it to the view
            return View(model);

        }
        public ActionResult Delete(int Id)
        {
            List<EmployeeModel> Employees;

            //Get Employee Collection
            Employees = (List<EmployeeModel>)TempData["Datastore"];

            //Get the employee with the selected id from the employee collection
            EmployeeModel model = Employees.FirstOrDefault(x => x.Id == Id);

            TempData.Keep();

            //Send it to the view
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(EmployeeModel m)
        {

            List<EmployeeModel> Employees;

            if (ModelState.IsValid)
            {
                // Get the list of Employees from the datastore
                Employees = (List<EmployeeModel>)TempData["Datastore"];

                //Get the model being edited from the employee collection
                EmployeeModel model = Employees.FirstOrDefault(x => x.Id == m.Id);

                //Remove the employee from the collection
                Employees.Remove(model);

                //Tempdata to keep the data till the next request
                TempData.Keep();
                return RedirectToAction("Index");
            }

            TempData.Keep();
            return View(m);
        }
    }
}