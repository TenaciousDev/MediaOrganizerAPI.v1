﻿// <auto-generated />
using MediaOrganizer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediaOrganizer.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220207214803_InitialCreateWithManyToManyRels")]
    partial class InitialCreateWithManyToManyRels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaCatalogMediaObject", b =>
                {
                    b.Property<int>("CatalogsId")
                        .HasColumnType("int");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.HasKey("CatalogsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("MediaCatalogMediaObject");
                });

            modelBuilder.Entity("MediaOrganizer.Data.Entities.MediaCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MediaCatalogs");
                });

            modelBuilder.Entity("MediaOrganizer.Data.Entities.MediaObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.ToTable("MediaObjects");
                });

            modelBuilder.Entity("MediaOrganizer.Data.Entities.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("MediaCatalogMediaObject", b =>
                {
                    b.HasOne("MediaOrganizer.Data.Entities.MediaCatalog", null)
                        .WithMany()
                        .HasForeignKey("CatalogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaOrganizer.Data.Entities.MediaObject", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaOrganizer.Data.Entities.MediaObject", b =>
                {
                    b.HasOne("MediaOrganizer.Data.Entities.MediaType", "TypeOfMedia")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfMedia");
                });
#pragma warning restore 612, 618
        }
    }
}
