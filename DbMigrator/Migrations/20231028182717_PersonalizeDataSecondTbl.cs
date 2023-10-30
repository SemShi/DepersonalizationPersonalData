using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028182717)]
public class PersonalizeDataSecondTbl : Migration
{
	public override void Up()
	{
        Create.Table("personalize_data_tbl2")
            .WithColumn("Data_id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Country").AsString(50).NotNullable()
            .WithColumn("Area").AsString(50).NotNullable()
            .WithColumn("City").AsString(50).NotNullable()
            .WithColumn("Phone").AsString(12).NotNullable();
    }

	public override void Down()
	{
	}
}

