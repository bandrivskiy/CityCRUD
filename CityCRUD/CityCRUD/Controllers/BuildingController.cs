using CityCRUD.DAL;
using CityCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityCRUD.Controllers
{
    public class BuildingController : Controller
    {
        private readonly ICityRepository _repository;
       
        public BuildingController()
        {
            _repository = new CityRepository(new CityDBContext());
        }
        // GET: Building
        public ActionResult Index()
        {
            List<BuildingViewModel> model = new List<BuildingViewModel>();
            var listOfBuildings = _repository.GetBuildings();
            foreach(var item in listOfBuildings)
            {
                model.Add(new BuildingViewModel {
                    Id = item.Id,
                    Address = item.Address,
                    Name = item.Name,
                    Allow = item.Allow });

            }
            return View(model);
        }
        public ActionResult Building(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(CreateBuildingViewModel(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id,Name,Address,Allow")] BuildingViewModel model)
        {
            if (ModelState.IsValid) {
                _repository.Insert(new Building {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    Allow = model.Allow});
               return RedirectToAction("Index");
            }           
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(CreateBuildingViewModel(id));
        }
        [HttpPost]
        public ActionResult Edit(BuildingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var building = _repository.GetBuildingById(model.Id);
                building.Id = model.Id;
                building.Name = model.Name;
                building.Address = model.Address;
                building.Allow = model.Allow;

                _repository.Save();
                return RedirectToAction("Building", new {id = model.Id});
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("Not Found");
            }
            var model = _repository.GetBuildingById(id);
            _repository.Delete(model);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public BuildingViewModel CreateBuildingViewModel(int? id)
        {          
            var building = _repository.GetBuildingById(id);
            BuildingViewModel model = new BuildingViewModel
            {
                Id = building.Id,
                Name = building.Name,
                Address = building.Address,
                Allow = building.Allow
            };
            return model;
        }
    }
}