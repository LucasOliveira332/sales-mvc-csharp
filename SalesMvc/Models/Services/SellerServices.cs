﻿using Microsoft.EntityFrameworkCore;
using SalesMvc.Data;

namespace SalesMvc.Models.Services
{
    public class SellerServices
    {
        private readonly SalesMvcContext _context;

        public SellerServices(SalesMvcContext context)
        {
            _context = context;
        }

        public  List<Seller> FindAll()
        {
            return  _context.Sellers.OrderBy(x => x.Name).ToList();
        }

        public void AddSaller(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindSeller(int? id)
        {
            Seller x = _context.Sellers.Include(x=> x.Department).FirstOrDefault(x => x.Id == id);
            return x;
        }

        public void EditSeller(Seller seller)
        {
            var editSeller = _context.Sellers.Update(seller);
            _context.SaveChanges();
        }

        public void RemoveSeller(int id)
        {
            var removeSeller = _context.Sellers.FirstOrDefault(x => x.Id == id);
            var listSalesRecords = _context.SalesRecords.Where(x => x.SellerID == id);

            _context.SalesRecords.RemoveRange(listSalesRecords);
            _context.SaveChanges();

            _context.Remove(removeSeller);
            _context.SaveChanges();
        }
    }
}