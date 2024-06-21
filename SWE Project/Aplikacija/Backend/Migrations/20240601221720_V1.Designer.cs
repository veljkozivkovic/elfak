﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240601221720_V1")]
    partial class V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Backend.Models.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserRole")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserRole")
                        .IsUnique()
                        .HasFilter("[UserRole] IS NOT NULL");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Backend.Models.Dogadjaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("OrganizatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("RezervacijaProstoraFK")
                        .HasColumnType("int");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("OrganizatorId");

                    b.HasIndex("RezervacijaProstoraFK")
                        .IsUnique()
                        .HasFilter("[RezervacijaProstoraFK] IS NOT NULL");

                    b.ToTable("Dogadjaji");
                });

            modelBuilder.Entity("Backend.Models.DraggableItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BrojMesta")
                        .HasColumnType("int");

                    b.Property<string>("FrontID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<double?>("HeightFactor")
                        .HasColumnType("float");

                    b.Property<double>("Left")
                        .HasColumnType("float");

                    b.Property<int?>("PlanProstoraID")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<bool?>("Reserved")
                        .HasColumnType("bit");

                    b.Property<int>("Tip")
                        .HasColumnType("int");

                    b.Property<double>("Top")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("PlanProstoraID");

                    b.ToTable("DraggableItems");
                });

            modelBuilder.Entity("Backend.Models.Korisnik", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaProfila")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Backend.Models.Line", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("PlanProstoraID")
                        .HasColumnType("int");

                    b.Property<double>("X1")
                        .HasColumnType("float");

                    b.Property<double>("X2")
                        .HasColumnType("float");

                    b.Property<double>("Y1")
                        .HasColumnType("float");

                    b.Property<double>("Y2")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("PlanProstoraID");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("Backend.Models.Ocena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DogadjajID")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("KorisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Vrednost")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DogadjajID");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Ocene");
                });

            modelBuilder.Entity("Backend.Models.PlanProstora", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DogadjajID")
                        .HasColumnType("int");

                    b.Property<int?>("ProstorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DogadjajID");

                    b.HasIndex("ProstorID");

                    b.ToTable("PlanoviProstora");
                });

            modelBuilder.Entity("Backend.Models.Prostor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<Guid?>("VlasnikProstoraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("VlasnikProstoraId");

                    b.ToTable("Prostori");
                });

            modelBuilder.Entity("Backend.Models.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrojMesta")
                        .HasColumnType("int");

                    b.Property<int?>("DogadjajID")
                        .HasColumnType("int");

                    b.Property<Guid?>("KorisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("StoFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("VremeRezervacije")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DogadjajID");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("StoFK")
                        .IsUnique()
                        .HasFilter("[StoFK] IS NOT NULL");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("Backend.Models.RezervacijaProstora", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ProstorID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("VremeDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremeOd")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ProstorID");

                    b.ToTable("RezervacijeProstora");
                });

            modelBuilder.Entity("Backend.Models.SurfaceDimension", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int?>("PlanProstoraFK")
                        .HasColumnType("int");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("PlanProstoraFK")
                        .IsUnique()
                        .HasFilter("[PlanProstoraFK] IS NOT NULL");

                    b.ToTable("SurfaceDimensions");
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Tagovi");
                });

            modelBuilder.Entity("DogadjajTag", b =>
                {
                    b.Property<int>("DogadjajiID")
                        .HasColumnType("int");

                    b.Property<int>("TagoviID")
                        .HasColumnType("int");

                    b.HasKey("DogadjajiID", "TagoviID");

                    b.HasIndex("TagoviID");

                    b.ToTable("DogadjajTag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Backend.Models.AppUserRole", b =>
                {
                    b.HasOne("Backend.Models.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Korisnik", "Korisnik")
                        .WithOne("UserRole")
                        .HasForeignKey("Backend.Models.AppUserRole", "UserRole");

                    b.Navigation("Korisnik");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Backend.Models.Dogadjaj", b =>
                {
                    b.HasOne("Backend.Models.Korisnik", "Organizator")
                        .WithMany("OrganizatorDogadjaji")
                        .HasForeignKey("OrganizatorId");

                    b.HasOne("Backend.Models.RezervacijaProstora", "RezervacijaProstora")
                        .WithOne("Dogadjaj")
                        .HasForeignKey("Backend.Models.Dogadjaj", "RezervacijaProstoraFK");

                    b.Navigation("Organizator");

                    b.Navigation("RezervacijaProstora");
                });

            modelBuilder.Entity("Backend.Models.DraggableItem", b =>
                {
                    b.HasOne("Backend.Models.PlanProstora", "PlanProstora")
                        .WithMany("DraggableItems")
                        .HasForeignKey("PlanProstoraID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PlanProstora");
                });

            modelBuilder.Entity("Backend.Models.Line", b =>
                {
                    b.HasOne("Backend.Models.PlanProstora", "PlanProstora")
                        .WithMany("Lines")
                        .HasForeignKey("PlanProstoraID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PlanProstora");
                });

            modelBuilder.Entity("Backend.Models.Ocena", b =>
                {
                    b.HasOne("Backend.Models.Dogadjaj", "Dogadjaj")
                        .WithMany("Ocene")
                        .HasForeignKey("DogadjajID");

                    b.HasOne("Backend.Models.Korisnik", "Korisnik")
                        .WithMany("Ocene")
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Dogadjaj");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("Backend.Models.PlanProstora", b =>
                {
                    b.HasOne("Backend.Models.Dogadjaj", "Dogadjaj")
                        .WithMany()
                        .HasForeignKey("DogadjajID");

                    b.HasOne("Backend.Models.Prostor", "Prostor")
                        .WithMany("PlanoviProstora")
                        .HasForeignKey("ProstorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Dogadjaj");

                    b.Navigation("Prostor");
                });

            modelBuilder.Entity("Backend.Models.Prostor", b =>
                {
                    b.HasOne("Backend.Models.Korisnik", "VlasnikProstora")
                        .WithMany("VlasnikProstori")
                        .HasForeignKey("VlasnikProstoraId");

                    b.Navigation("VlasnikProstora");
                });

            modelBuilder.Entity("Backend.Models.Rezervacija", b =>
                {
                    b.HasOne("Backend.Models.Dogadjaj", "Dogadjaj")
                        .WithMany("Rezervacije")
                        .HasForeignKey("DogadjajID");

                    b.HasOne("Backend.Models.Korisnik", "Korisnik")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("Backend.Models.DraggableItem", "Sto")
                        .WithOne("Rezervacija")
                        .HasForeignKey("Backend.Models.Rezervacija", "StoFK");

                    b.Navigation("Dogadjaj");

                    b.Navigation("Korisnik");

                    b.Navigation("Sto");
                });

            modelBuilder.Entity("Backend.Models.RezervacijaProstora", b =>
                {
                    b.HasOne("Backend.Models.Prostor", "Prostor")
                        .WithMany("Rezervacije")
                        .HasForeignKey("ProstorID");

                    b.Navigation("Prostor");
                });

            modelBuilder.Entity("Backend.Models.SurfaceDimension", b =>
                {
                    b.HasOne("Backend.Models.PlanProstora", "PlanProstora")
                        .WithOne("SurfaceDimension")
                        .HasForeignKey("Backend.Models.SurfaceDimension", "PlanProstoraFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PlanProstora");
                });

            modelBuilder.Entity("DogadjajTag", b =>
                {
                    b.HasOne("Backend.Models.Dogadjaj", null)
                        .WithMany()
                        .HasForeignKey("DogadjajiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagoviID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Backend.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Backend.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Backend.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Backend.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Backend.Models.Dogadjaj", b =>
                {
                    b.Navigation("Ocene");

                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Backend.Models.DraggableItem", b =>
                {
                    b.Navigation("Rezervacija");
                });

            modelBuilder.Entity("Backend.Models.Korisnik", b =>
                {
                    b.Navigation("Ocene");

                    b.Navigation("OrganizatorDogadjaji");

                    b.Navigation("Rezervacije");

                    b.Navigation("UserRole");

                    b.Navigation("VlasnikProstori");
                });

            modelBuilder.Entity("Backend.Models.PlanProstora", b =>
                {
                    b.Navigation("DraggableItems");

                    b.Navigation("Lines");

                    b.Navigation("SurfaceDimension");
                });

            modelBuilder.Entity("Backend.Models.Prostor", b =>
                {
                    b.Navigation("PlanoviProstora");

                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Backend.Models.RezervacijaProstora", b =>
                {
                    b.Navigation("Dogadjaj");
                });
#pragma warning restore 612, 618
        }
    }
}
