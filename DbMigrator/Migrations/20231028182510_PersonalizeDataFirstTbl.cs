using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028182510)]
public class PersonalizeDataFirstTbl : Migration
{
	public override void Up()
	{
        Create.Table("personalize_data_tbl1")
            .WithColumn("Data_id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("FirstName").AsString(50).NotNullable()
            .WithColumn("MiddleName").AsString(50)
            .WithColumn("LastName").AsString(50).NotNullable()
            .WithColumn("Birthday").AsDate().NotNullable();
    }

	public override void Down()
	{
	}
}

