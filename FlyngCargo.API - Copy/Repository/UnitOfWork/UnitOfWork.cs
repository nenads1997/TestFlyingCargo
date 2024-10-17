﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProductRepository _products;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

     
        public IProductRepository Products => _products ??= new ProductRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }


}
