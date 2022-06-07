using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRM_CUS.Models
{
    public partial class CustomersContext : DbContext
    {
        public CustomersContext()
        {
        }

        public CustomersContext(DbContextOptions<CustomersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AddressType> AddressTypes { get; set; } = null!;
        public virtual DbSet<GetCu> GetCus { get; set; } = null!;
        public virtual DbSet<Passport> Passports { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.55.31.89,1401;Database=Customers;user id=sa;password=*New_123#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressTypeId).HasColumnName("addressType_id");

                entity.Property(e => e.Apartment)
                    .HasMaxLength(50)
                    .HasColumnName("apartment");

                entity.Property(e => e.Building)
                    .HasMaxLength(50)
                    .HasColumnName("building");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .HasColumnName("house");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasColumnName("region");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .HasConstraintName("FK_Addresses_AddressType");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Addresses_Person");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .HasColumnName("nameType");
            });

            modelBuilder.Entity<GetCu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetCus");

                entity.Property(e => e.Apartment)
                    .HasMaxLength(50)
                    .HasColumnName("apartment");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(150)
                    .HasColumnName("birthplace");

                entity.Property(e => e.Building)
                    .HasMaxLength(50)
                    .HasColumnName("building");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CodeCountryDocument)
                    .HasMaxLength(20)
                    .HasColumnName("codeCountryDocument");

                entity.Property(e => e.CodeDocument)
                    .HasMaxLength(15)
                    .HasColumnName("codeDocument");

                entity.Property(e => e.CodeNumber)
                    .HasMaxLength(10)
                    .HasColumnName("codeNumber");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.CountryDocument)
                    .HasMaxLength(50)
                    .HasColumnName("countryDocument");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(50)
                    .HasColumnName("countryOfOrigin");

                entity.Property(e => e.DecriptionEn)
                    .HasMaxLength(100)
                    .HasColumnName("DecriptionEN");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.DescriptionRu)
                    .HasMaxLength(100)
                    .HasColumnName("DescriptionRU");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.FormattedPhone)
                    .HasMaxLength(50)
                    .HasColumnName("formattedPhone");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .HasColumnName("house");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.IdDate)
                    .HasColumnType("date")
                    .HasColumnName("idDate");

                entity.Property(e => e.IdWhom)
                    .HasMaxLength(150)
                    .HasColumnName("idWhom");

                entity.Property(e => e.IdWhomCode)
                    .HasMaxLength(15)
                    .HasColumnName("idWhomCode");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .HasColumnName("nameType");

                entity.Property(e => e.Number)
                    .HasMaxLength(15)
                    .HasColumnName("number");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasColumnName("region");

                entity.Property(e => e.Serial)
                    .HasMaxLength(15)
                    .HasColumnName("serial");

                entity.Property(e => e.StPersDescription).HasMaxLength(500);

                entity.Property(e => e.StatusStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("statusStamp");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdDate)
                    .HasColumnType("date")
                    .HasColumnName("idDate");

                entity.Property(e => e.IdWhom)
                    .HasMaxLength(150)
                    .HasColumnName("idWhom");

                entity.Property(e => e.IdWhomCode)
                    .HasMaxLength(15)
                    .HasColumnName("idWhomCode");

                entity.Property(e => e.Number)
                    .HasMaxLength(15)
                    .HasColumnName("number");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Serial)
                    .HasMaxLength(15)
                    .HasColumnName("serial");

                entity.Property(e => e.TypeDocumentId).HasColumnName("typeDocument_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Passports)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Passport_Person");

                entity.HasOne(d => d.TypeDocument)
                    .WithMany(p => p.Passports)
                    .HasForeignKey(d => d.TypeDocumentId)
                    .HasConstraintName("FK_Passport_TypeDocument");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(150)
                    .HasColumnName("birthplace");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullName)
                    .HasMaxLength(152)
                    .HasColumnName("fullName")
                    .HasComputedColumnSql("(((([firstName]+' ')+[lastName])+' ')+[surName])", false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CodeNumber)
                    .HasMaxLength(10)
                    .HasColumnName("codeNumber");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(50)
                    .HasColumnName("countryOfOrigin");

                entity.Property(e => e.FormattedPhone)
                    .HasMaxLength(50)
                    .HasColumnName("formattedPhone");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Phone1)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Phones_Person");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("createStamp");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.SourceId).HasColumnName("source_id");

                entity.Property(e => e.SourceTab).HasColumnName("source_tab");

                entity.Property(e => e.StatusStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("statusStamp");
            });

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.ToTable("TypeDocument");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CodeCountryDocument)
                    .HasMaxLength(20)
                    .HasColumnName("codeCountryDocument");

                entity.Property(e => e.CodeDocument)
                    .HasMaxLength(15)
                    .HasColumnName("codeDocument");

                entity.Property(e => e.CountryDocument)
                    .HasMaxLength(50)
                    .HasColumnName("countryDocument");

                entity.Property(e => e.DecriptionEn)
                    .HasMaxLength(100)
                    .HasColumnName("DecriptionEN");

                entity.Property(e => e.DescriptionRu)
                    .HasMaxLength(100)
                    .HasColumnName("DescriptionRU");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
