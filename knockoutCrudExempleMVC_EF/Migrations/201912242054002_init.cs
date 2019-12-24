namespace knockoutCrudExempleMVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        TitleOfCourtesy = c.String(),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        HomePhone = c.String(),
                        Extension = c.String(),
                        Photo = c.Binary(),
                        Notes = c.String(),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        Employee1_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Employees", t => t.Employee1_EmployeeID)
                .Index(t => t.Employee1_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Employee1_EmployeeID", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Employee1_EmployeeID" });
            DropTable("dbo.Employees");
        }
    }
}
