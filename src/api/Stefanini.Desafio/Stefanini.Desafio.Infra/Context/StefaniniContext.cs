using Microsoft.EntityFrameworkCore;
using Stefanini.Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Infra.Context
{
  public class StefaniniContext : DbContext
  {
  
    public StefaniniContext(DbContextOptions<StefaniniContext> options)
      : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<City> Cities { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<City>()
        .HasKey(c => c.CityId);
      modelBuilder.Entity<City>()
        .Property(c => c.CityId).UseIdentityColumn().ValueGeneratedOnAdd();
      modelBuilder.Entity<City>()
        .Property(c => c.Name).IsRequired();


      modelBuilder.Entity<Person>()
       .HasKey(c => c.Id);
      modelBuilder.Entity<Person>()
        .Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd();
      modelBuilder.Entity<Person>()
        .Property(c => c.Name).IsRequired();
      modelBuilder.Entity<Person>()
       .Property(c => c.Age).IsRequired();
      modelBuilder.Entity<Person>()
       .Property(c => c.CityId).IsRequired();




    }



  }
}
