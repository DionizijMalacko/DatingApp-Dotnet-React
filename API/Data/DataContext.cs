using System.Diagnostics.CodeAnalysis;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //nasledjujemo DbContext koja vec postoji negde
    public class DataContext : DbContext
    {
        //moramo napraviti konstruktor, sam ga izgenerise sa Ctrl + . 
        public DataContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        //kreira tabelu Users u bazi
        public DbSet<AppUser> Users { get; set; }
    }
}