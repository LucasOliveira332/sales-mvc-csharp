﻿using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models;
using SalesMvc.Models.Services;

namespace SalesMvc
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentServices _departmentServices;

        public DepartmentController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
           var listDepartments =  _departmentServices.FindAll();
            return View(listDepartments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _departmentServices.Add(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var findDepartment = _departmentServices.Find(id);
            return View(findDepartment);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _departmentServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
