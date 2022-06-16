﻿using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Models.Services
{

    public class DepartmentServices
    {

        private readonly SalesMvcContext _context;
        public DepartmentServices(SalesMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Departments!.OrderBy(x => x.Name).ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public Department FindDepartment(int? id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            return department;
        }

        public void RemoveDepartment(int id)
        {
            var removeSeller = _context.Sellers?.Where(x => x.DepartmentID == id).ToList();

            foreach (var item in removeSeller)
            {
                var salesRecord = _context.SalesRecords?.Where(x => x.SellerID == item.Id);
                _context.SalesRecords.RemoveRange(salesRecord);
                _context.SaveChanges();
            }
            
            _context.Sellers.RemoveRange(removeSeller);
            _context.SaveChanges();

            var removeDepartment = _context.Departments?.FirstOrDefault(x => x.Id == id);
            _context.Departments.Remove(removeDepartment);
            _context.SaveChanges();
        }
    }
}
