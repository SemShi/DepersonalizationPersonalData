using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028180601)]
public class DcPermissions : Migration
{
	public override void Up()
	{
        Create.Table("dc_permissions")
            .WithColumn("Permission_id").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Description").AsString(255)
            .WithColumn("UName").AsString(50).NotNullable().WithDefaultValue(RawSql.Insert("current_user"))
            .WithColumn("DEdit").AsDateTime().NotNullable().WithDefaultValue(RawSql.Insert("current_timestamp"));
    }

	public override void Down()
	{
	}
}

