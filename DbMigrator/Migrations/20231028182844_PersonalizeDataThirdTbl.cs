using FluentMigrator;

namespace DbMigrator.Migrations;

[Migration(20231028182844)]
public class PersonalizeDataThirdTbl : Migration
{
	public override void Up()
	{
        Create.Table("personalize_data_tbl3")
            .WithColumn("Data_id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Street").AsString(100).NotNullable()
            .WithColumn("Home").AsInt32().NotNullable()
            .WithColumn("Building").AsString(50)
            .WithColumn("Flat").AsInt32().NotNullable();
    }

	public override void Down()
	{
	}
}

