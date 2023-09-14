﻿using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GradeBookDbContext _dbContext;

        public UnitOfWork(GradeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditableEntities()
        {
            var entries = _dbContext
                .ChangeTracker
                .Entries<Entity>(); 

            foreach (var entry in entries) 
            {
                if (entry.State==EntityState.Added)
                {
                    entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}
