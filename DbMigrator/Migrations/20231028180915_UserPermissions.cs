using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028180915)]
public class UserPermissions : Migration
{
	public override void Up()
	{
        Create.Table("user_permissions")
            .WithColumn("User_id").AsGuid().ForeignKey("users", "User_id").PrimaryKey().NotNullable()
            .WithColumn("Permission_id").AsInt32().ForeignKey("dc_permissions", "Permission_id").PrimaryKey().NotNullable()
            .WithColumn("UName").AsString(50).NotNullable().WithDefaultValue(RawSql.Insert("current_user"))
            .WithColumn("DEdit").AsDateTime().NotNullable().WithDefaultValue(RawSql.Insert("current_timestamp"));
    }

	public override void Down()
	{
	}
}

