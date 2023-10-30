using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231030164814)]
public class AddUserPermissions : Migration
{
	public override void Up()
	{
        Insert.IntoTable("user_permissions")
            .Row(new { User_id = Values.Admin, Permission_id = 2 })
            .Row(new { User_id = Values.Admin, Permission_id = 3 })
            .Row(new { User_id = Values.Employee, Permission_id = 1 })
            .Row(new { User_id = Values.Employee, Permission_id = 3 });
    }

	public override void Down()
	{
	}
}

