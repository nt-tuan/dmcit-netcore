﻿// <auto-generated />
using System;
using DMCIT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMCIT.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190801091254_restructure")]
    partial class restructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMCIT.Core.Entities.Accounts.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("BusinessId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<int?>("PersonId");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("BusinessId")
                        .IsUnique()
                        .HasFilter("[BusinessId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Core.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BusinessIdentityNumber");

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("MobilePhone");

                    b.Property<int?>("OriginId");

                    b.Property<string>("Phone");

                    b.Property<string>("ShortName");

                    b.Property<string>("TaxNumber");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Core.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Core.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime?>("Birthday");

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<string>("IdentityNumber");

                    b.Property<string>("LastName");

                    b.Property<int?>("OriginId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("FullName");

                    b.Property<string>("Location");

                    b.Property<string>("Location2");

                    b.Property<string>("Location3");

                    b.Property<int?>("ManagerId");

                    b.Property<int?>("OriginId");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Phone");

                    b.Property<string>("Phone2");

                    b.Property<string>("Phone3");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OriginId");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("DiscriptionNote");

                    b.Property<int>("EmployeeTitleId");

                    b.Property<int?>("OriginId");

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeTitleId");

                    b.HasIndex("OriginId");

                    b.HasIndex("PersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.EmployeeTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("EmployeeTitles");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<int?>("OriginId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OriginId");

                    b.ToTable("AutoMessageConfigs");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<int?>("OriginId");

                    b.Property<string>("Period")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OriginId");

                    b.ToTable("AutoMessageConfigDetails");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigMessageReceiver", b =>
                {
                    b.Property<int>("MessageReceiverId");

                    b.Property<int>("AutoMessageConfigId");

                    b.HasKey("MessageReceiverId", "AutoMessageConfigId");

                    b.HasIndex("AutoMessageConfigId");

                    b.ToTable("AutoMesasgeConfigMessageReceivers");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigMessageReceiverGroup", b =>
                {
                    b.Property<int>("AutoMessageConfigId");

                    b.Property<int>("MessageReceiverGroupId");

                    b.HasKey("AutoMessageConfigId", "MessageReceiverGroupId");

                    b.HasIndex("MessageReceiverGroupId");

                    b.ToTable("AutoMessageConfigMessageReceiverGroups");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigProvider", b =>
                {
                    b.Property<int>("AutoMessageConfigId");

                    b.Property<int>("MessageServiceProviderId");

                    b.HasKey("AutoMessageConfigId", "MessageServiceProviderId");

                    b.HasIndex("MessageServiceProviderId");

                    b.ToTable("AutoMessageConfigProviders");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("FullName");

                    b.Property<int?>("OriginId");

                    b.Property<int?>("ReceiverCategoryId");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReceiverCategoryId");

                    b.ToTable("MessageReceivers");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiverGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("Name");

                    b.Property<int?>("OriginId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("MessageReceiverGroups");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiverGroupMessageReceiver", b =>
                {
                    b.Property<int>("MessageReceiverGroupId");

                    b.Property<int>("MessageReceiverId");

                    b.HasKey("MessageReceiverGroupId", "MessageReceiverId");

                    b.HasIndex("MessageReceiverId");

                    b.ToTable("MessageReceiverGroupMessageReceivers");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageServiceProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLabel");

                    b.Property<string>("AddressRegex");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("Name");

                    b.Property<int?>("OriginId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("MessageServiceProviders");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.ReceiverCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("Name");

                    b.Property<int?>("OriginId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("ReceiverCategories");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.ReceiverProvider", b =>
                {
                    b.Property<int>("MessageReceiverId");

                    b.Property<int>("MessageServiceProviderId");

                    b.Property<string>("ReceiverAddress");

                    b.HasKey("MessageReceiverId", "MessageServiceProviderId");

                    b.HasIndex("MessageServiceProviderId");

                    b.ToTable("ReceiverProviders");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.SentMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutoMessageConfigDetailsId");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("ReceiveTime");

                    b.Property<int>("ReceiverProviderId");

                    b.Property<DateTime>("SendTime");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AutoMessageConfigDetailsId");

                    b.HasIndex("CreatedById");

                    b.ToTable("SentMessages");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Sales.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessId");

                    b.Property<string>("Code");

                    b.Property<float?>("CoordinateX");

                    b.Property<float?>("CoordinateY");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<int?>("DistributorId");

                    b.Property<int?>("OriginId");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DistributorId");

                    b.HasIndex("OriginId");

                    b.HasIndex("PersonId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Sales.Distributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<int>("CountryId");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateReplaced");

                    b.Property<string>("DiscriptionNote");

                    b.Property<string>("Name");

                    b.Property<int?>("OriginId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("CountryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OriginId");

                    b.ToTable("Distributors");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Accounts.AppUser", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Core.Business", "Business")
                        .WithOne("CreatedBy")
                        .HasForeignKey("DMCIT.Core.Entities.Accounts.AppUser", "BusinessId");

                    b.HasOne("DMCIT.Core.Entities.Core.Person", "Person")
                        .WithOne("CreatedBy")
                        .HasForeignKey("DMCIT.Core.Entities.Accounts.AppUser", "PersonId");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Core.Business", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Core.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Core.Person", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Core.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.Department", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.HR.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("DMCIT.Core.Entities.HR.Department", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");

                    b.HasOne("DMCIT.Core.Entities.HR.Department", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.Employee", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.HR.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("DMCIT.Core.Entities.HR.EmployeeTitle", "EmployeeTitle")
                        .WithMany()
                        .HasForeignKey("EmployeeTitleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.HR.Employee", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");

                    b.HasOne("DMCIT.Core.Entities.Core.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.HR.EmployeeTitle", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfig", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfig", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigDetail", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfig", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigMessageReceiver", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfig", "AutoMessageConfig")
                        .WithMany("AutoMessageConfigMessageReceivers")
                        .HasForeignKey("AutoMessageConfigId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageReceiver", "MessageReceiver")
                        .WithMany()
                        .HasForeignKey("MessageReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigMessageReceiverGroup", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfig", "AutoMessageConfig")
                        .WithMany("AutoMessageConfigMessageReceiverGroups")
                        .HasForeignKey("AutoMessageConfigId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageReceiverGroup", "MessageReceiverGroup")
                        .WithMany()
                        .HasForeignKey("MessageReceiverGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.AutoMessageConfigProvider", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfig", "AutoMessageConfig")
                        .WithMany("AutoMessageConfigProviders")
                        .HasForeignKey("AutoMessageConfigId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageServiceProvider", "MessageServiceProvider")
                        .WithMany()
                        .HasForeignKey("MessageServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiver", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.Sales.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("DMCIT.Core.Entities.HR.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DMCIT.Core.Entities.Messaging.ReceiverCategory", "ReceiverCategory")
                        .WithMany("MessageReceivers")
                        .HasForeignKey("ReceiverCategoryId");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiverGroup", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageReceiverGroupMessageReceiver", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageReceiverGroup", "MessageReceiverGroup")
                        .WithMany("MessageReceiverGroupMessageReceivers")
                        .HasForeignKey("MessageReceiverGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageReceiver", "MessageReceiver")
                        .WithMany("MessageReceiverGroupMessageReceivers")
                        .HasForeignKey("MessageReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.MessageServiceProvider", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.ReceiverCategory", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.ReceiverProvider", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageReceiver", "MessageReceiver")
                        .WithMany("ReceiverProviders")
                        .HasForeignKey("MessageReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Messaging.MessageServiceProvider", "MessageServiceProvider")
                        .WithMany("ReceiverProviders")
                        .HasForeignKey("MessageServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Messaging.SentMessage", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Messaging.AutoMessageConfigDetail", "AutoMessageConfigDetails")
                        .WithMany()
                        .HasForeignKey("AutoMessageConfigDetailsId");

                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Sales.Customer", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Core.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId");

                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.Sales.Distributor", "Distributor")
                        .WithMany()
                        .HasForeignKey("DistributorId");

                    b.HasOne("DMCIT.Core.Entities.Sales.Customer", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");

                    b.HasOne("DMCIT.Core.Entities.Core.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DMCIT.Core.Entities.Sales.Distributor", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Core.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("DMCIT.Core.Entities.Sales.Distributor", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DMCIT.Core.Entities.Accounts.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
