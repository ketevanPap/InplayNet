using Inplaynet.Model.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inplaynet.Data
{
    public class InplaynetDbContext : DbContext
    {
        public InplaynetDbContext(DbContextOptions<InplaynetDbContext> options) : base(options)
        {}

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
