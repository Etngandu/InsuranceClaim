﻿// <auto-generated />
using System;
using ENB.InsuranceAndClaims.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    [DbContext(typeof(InsuranceAndClaimsContext))]
    [Migration("20230226122523_ClaimDoc")]
    partial class ClaimDoc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(150)");

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

                    b.Property<string>("SecurityStamp")
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

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount_Claimed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount_Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfClaim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_of_Settlement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<int>("Ref_Claim_Status")
                        .HasColumnType("int");

                    b.Property<int>("Ref_Claim_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("ClaimHeader");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimProcessing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClaimHeaderId")
                        .HasColumnType("int");

                    b.Property<int?>("ClaimProcessingStageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClaimHeaderId");

                    b.HasIndex("ClaimProcessingStageId");

                    b.HasIndex("StaffId");

                    b.ToTable("ClaimProcessing");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimProcessingStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Claim_Status_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Claim_Status_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("ParentClaimStageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentClaimStageId");

                    b.ToTable("ClaimProcessingStage");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_Details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int?>("PolicyTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PolicyTypeId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.PolicyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyTypeDescrition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PolicyType");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasData(
                        new
                        {
                            Id = "4ebe9d0b-3d9e-450d-a07f-145c9c997b8a",
                            ConcurrencyStamp = "571091cf-1895-472c-94d1-d15b5ddeca61",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "307a1cf3-641f-4d02-a29c-82d9c14f0d02",
                            ConcurrencyStamp = "e07a6e4f-7eed-42d4-ab48-fa360c909b67",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "cef0c71c-6c1e-4072-b8fc-a9f2dc79d0a4",
                            ConcurrencyStamp = "c6dbd0e8-3b27-4c9e-b213-24bbdc37cd9d",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "7bf16fb4-289d-4288-825a-3e9818381616",
                            ConcurrencyStamp = "7afbc97b-d1ce-4410-bb7b-257dc1f1aba4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimHeader", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimProcessing", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.ClaimHeader", "ClaimHeader")
                        .WithMany()
                        .HasForeignKey("ClaimHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.InsuranceAndClaims.Entities.ClaimProcessingStage", "ClaimProcessingStage")
                        .WithMany()
                        .HasForeignKey("ClaimProcessingStageId");

                    b.HasOne("ENB.InsuranceAndClaims.Entities.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClaimHeader");

                    b.Navigation("ClaimProcessingStage");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimProcessingStage", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.ClaimProcessingStage", "ParentClaimStage")
                        .WithMany("RepliesProcessingStages")
                        .HasForeignKey("ParentClaimStageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentClaimStage");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Customer", b =>
                {
                    b.OwnsOne("ENB.InsuranceAndClaims.Entities.Address", "AddressCustomer", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("AddressCustomer")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Policy", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.Customer", "Customer")
                        .WithMany("Policies")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.InsuranceAndClaims.Entities.PolicyType", "PolicyType")
                        .WithMany()
                        .HasForeignKey("PolicyTypeId");

                    b.Navigation("Customer");

                    b.Navigation("PolicyType");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Staff", b =>
                {
                    b.OwnsOne("ENB.InsuranceAndClaims.Entities.Address", "AddressStaff", b1 =>
                        {
                            b1.Property<int>("StaffId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("StaffId");

                            b1.ToTable("Staff");

                            b1.WithOwner()
                                .HasForeignKey("StaffId");
                        });

                    b.Navigation("AddressStaff")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.InsuranceAndClaims.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ENB.InsuranceAndClaims.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.ClaimProcessingStage", b =>
                {
                    b.Navigation("RepliesProcessingStages");
                });

            modelBuilder.Entity("ENB.InsuranceAndClaims.Entities.Customer", b =>
                {
                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
