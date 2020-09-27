using Microsoft.EntityFrameworkCore;
using SeminarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarsAPI.Context
{
    public class SeminarContext : DbContext
    {
        public SeminarContext(DbContextOptions<SeminarContext> options) : base(options)
        {

        }

        public DbSet<Seminar> SeminarModels { get; set; }
        public DbSet<Attendee> AttendeeModels { get; set; }

    }

}
