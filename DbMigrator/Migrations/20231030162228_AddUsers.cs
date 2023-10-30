using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231030162228)]
public class AddUsers : Migration
{
	public override void Up()
	{
		Insert.IntoTable("users")
			.Row(new { User_id = Values.Admin, Login = "supad", Password = "123", FirstName = "Super", LastName = "Admin" })
            .Row(new { User_id = Values.Employee, Login = "employee", Password = "321", FirstName = "Bill", LastName = "Gates" });
    }

	public override void Down()
	{
	}
}

