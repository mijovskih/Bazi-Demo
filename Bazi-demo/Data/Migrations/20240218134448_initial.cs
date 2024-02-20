using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazi_demo.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    EMBG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.EMBG);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberDoors = table.Column<int>(type: "int", nullable: false),
                    NumberSeats = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VIN);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountAdvance = table.Column<int>(type: "int", nullable: false),
                    AmountLeft = table.Column<int>(type: "int", nullable: false),
                    NumberInstallments = table.Column<int>(type: "int", nullable: false),
                    CustomerEMBG = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerEMBG",
                        column: x => x.CustomerEMBG,
                        principalTable: "Customers",
                        principalColumn: "EMBG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EMBG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEmployed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EMBG);
                    table.ForeignKey(
                        name: "FK_Employees_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleVIN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Vehicles_VehicleVIN",
                        column: x => x.VehicleVIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN");
                });

            migrationBuilder.CreateTable(
                name: "BookingVehicle",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    VehiclesVIN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVehicle", x => new { x.BookingsId, x.VehiclesVIN });
                    table.ForeignKey(
                        name: "FK_BookingVehicle_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingVehicle_Vehicles_VehiclesVIN",
                        column: x => x.VehiclesVIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingEmployee",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEMBG = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEmployee", x => new { x.BookingsId, x.EmployeesEMBG });
                    table.ForeignKey(
                        name: "FK_BookingEmployee_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingEmployee_Employees_EmployeesEMBG",
                        column: x => x.EmployeesEMBG,
                        principalTable: "Employees",
                        principalColumn: "EMBG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                columns: table => new
                {
                    EmployeesEMBG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => new { x.EmployeesEMBG, x.ShiftsId });
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Employees_EmployeesEMBG",
                        column: x => x.EmployeesEMBG,
                        principalTable: "Employees",
                        principalColumn: "EMBG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Shifts_ShiftsId",
                        column: x => x.ShiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEmployee_EmployeesEMBG",
                table: "BookingEmployee",
                column: "EmployeesEMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerEMBG",
                table: "Bookings",
                column: "CustomerEMBG");

            migrationBuilder.CreateIndex(
                name: "IX_BookingVehicle_VehiclesVIN",
                table: "BookingVehicle",
                column: "VehiclesVIN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftsId",
                table: "EmployeeShift",
                column: "ShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BookingId",
                table: "Payment",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_VehicleVIN",
                table: "VehicleTypes",
                column: "VehicleVIN",
                unique: true,
                filter: "[VehicleVIN] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEmployee");

            migrationBuilder.DropTable(
                name: "BookingVehicle");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
