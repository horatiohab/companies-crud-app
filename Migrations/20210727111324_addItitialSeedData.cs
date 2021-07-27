using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesApp.Migrations
{
    public partial class addItitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Email", "Logo", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "contact@microsoft.com", "\\images\\Microsoft_logo.png", "Microsoft", "microsoft.com" },
                    { 2, "contact@google.com", "\\images\\Google_logo.png", "Google", "google.com" },
                    { 3, "contact@apple.com", "\\images\\Apple_logo.png", "Apple", "apple.com" },
                    { 4, "contact@amazon.com", "\\images\\Amazon_logo.png", "Amazon", "amazon.com" },
                    { 5, "contact@facebook.com", "\\images\\Facebook_logo.png", "Facebook", "facebook.com" },
                    { 6, "contact@netflix.com", "\\images\\Netflix_logo.png", "Netflix", "netflix.com" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "CompanyId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "ringo@star.com", "Ringo", "Star", "001987621" },
                    { 2, 2, "paul@mccartney.com", "Paul", "McCartney", "001987622" },
                    { 3, 3, "george@harrison.com", "George", "Harrison", "001987623" },
                    { 4, 4, "john@lennon.com", "John", "Lennon", "001987624" },
                    { 5, 5, "ozzy@osbourne.com", "Ozzy", "Osbourne", "001987625" },
                    { 6, 6, "benedict@cumberbatch.com", "Benedict", "Cumberbatch", "001987626" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 6);
        }
    }
}
