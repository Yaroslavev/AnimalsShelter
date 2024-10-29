﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AnimalsShelterDbContext))]
    [Migration("20241022022944_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Enteties.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("GenderId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeId = 1,
                            Description = "Likes to sleep",
                            GenderId = 2,
                            ImageUrl = "https://image.petmd.com/files/inline-images/black-cat-breeds-american-shorthair.jpeg?VersionId=FHXiYOmOykNtIdlZ.V5LQC_E8wXzlgyG",
                            Months = 27,
                            Name = "Charlie"
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeId = 2,
                            Description = "Doesn't like silence",
                            GenderId = 1,
                            ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/best-small-dog-breeds-chihuahua-1598967884.jpg",
                            Months = 13,
                            Name = "Pakky"
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeId = 2,
                            Description = "Needs a lot of walking",
                            GenderId = 1,
                            ImageUrl = "https://www.nylabone.com/-/media/project/oneweb/nylabone/images/dog101/10-intelligent-dog-breeds/golden-retriever-tongue-out.jpg",
                            Months = 45,
                            Name = "Rik"
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeId = 3,
                            Description = "Likes to eat and sleep",
                            GenderId = 2,
                            ImageUrl = "https://blog.omlet.us/wp-content/uploads/sites/6/2023/08/Hamster-laying-down-on-the-counter-scaled.jpg",
                            Months = 4,
                            Name = "Sherry"
                        },
                        new
                        {
                            Id = 5,
                            AnimalTypeId = 1,
                            Description = "Likes attention",
                            GenderId = 2,
                            ImageUrl = "https://www.zooplus.ie/magazine/wp-content/uploads/2021/07/Outdoor-kitten-explores-the-garden-768x512.jpeg",
                            Months = 9,
                            Name = "Yoru"
                        });
                });

            modelBuilder.Entity("Data.Enteties.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dog"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hamster"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Turtle"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Data.Enteties.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("Data.Enteties.Animal", b =>
                {
                    b.HasOne("Data.Enteties.AnimalType", "AnimalType")
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Enteties.Gender", "Gender")
                        .WithMany("Animals")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalType");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Data.Enteties.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Data.Enteties.Gender", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
