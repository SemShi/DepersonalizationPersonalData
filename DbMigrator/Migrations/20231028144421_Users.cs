using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028144421)]
public class Users : Migration
{
	public override void Up()
	{
        Create.Table("users")
            .WithColumn("User_id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Login").AsString(50).NotNullable()
            .WithColumn("Password").AsString(50).NotNullable()
            .WithColumn("FirstName").AsString(50).NotNullable()
            .WithColumn("LastName").AsString(50).NotNullable()
            .WithColumn("UName").AsString(50).NotNullable().WithDefaultValue(RawSql.Insert("current_user"))
            .WithColumn("DEdit").AsDateTime().NotNullable().WithDefaultValue(RawSql.Insert("current_timestamp"));
    }

	public override void Down()
	{
	}
}

