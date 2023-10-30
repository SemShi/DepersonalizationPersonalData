using FluentMigrator;
using System.IO;

namespace DbMigrator.Migrations;

[Migration(20231030165138)]
public class AddPersonalizeData : Migration
{
	public override void Up()
	{
        Insert.IntoTable("personalize_data_tbl1")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", FirstName = "Евгений", MiddleName = "Викторович", LastName = "Пригожин", Birthday = "1967-01-01" })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", FirstName = "Антон", MiddleName = "Евгеньевич", LastName = "Чупахин", Birthday = "1977-08-14" })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", FirstName = "Артем", MiddleName = "Артемович", LastName = "Артемов", Birthday = "2000-01-01" });
        Insert.IntoTable("personalize_data_tbl2")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", Country = "Россия", Area = "Московская область", City = "Реутов", Phone = "89999999999" })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", Country = "Россия", Area = "Ярославская область", City = "Ярославль", Phone = "89201331266" })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", Country = "Россия", Area = "Ярославская область", City = "Рыбинск", Phone = "89201070055" });
        Insert.IntoTable("personalize_data_tbl3")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", Street = "Бори Новикова", Home = 45, Building = "2б", Flat = 55 })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", Street = "Ленина", Home = 12, Building = "к3", Flat = 12 })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", Street = "Проспект октября", Home = 4, Building = "к2", Flat = 56 });
    }

	public override void Down()
	{
	}
}

