﻿using Sneakers.Models;
using Sneakers.Models.DTO;

namespace Sneakers.Services
{
    public class BrandService
    {

        private AppDbContext _context;
        public BrandService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBrand (BrandVM brand)
        {
            var _brand = new SNEAKERS_BRAND()
            {
                Brand = brand.Brand
            };
            _context.SNEAKERS_BRAND.Add(_brand);
            _context.SaveChanges();

        }
       
    }
}
