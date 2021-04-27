using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonDB.Models;

#nullable disable

namespace PersonDB.Data
{
    public partial class PersonTestDBContext : DbContext
    {
        public PersonTestDBContext()
        {
        }
        public PersonTestDBContext(DbContextOptions<PersonTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<person> People { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhoneOwner> PhoneOwners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source
                optionsBuilder.UseSqlServer("Server=Localhost;Database=PersonTestDB;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collection", "Finnis_Swedish_CI_AS");

            modelBuilder.Entity<person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EyeColor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NotUsed).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhoneOwner>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PhoneOwners");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
            
                
        

        
    

