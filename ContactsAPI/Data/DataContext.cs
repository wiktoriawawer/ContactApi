using ContactsAPI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ContactsAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
