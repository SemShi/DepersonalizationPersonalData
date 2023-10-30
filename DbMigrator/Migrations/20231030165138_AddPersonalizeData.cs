using FluentMigrator;
using System.IO;

namespace DbMigrator.Migrations;

[Migration(20231030165138)]
public class AddPersonalizeData : Migration
{
	public override void Up()
	{
        Insert.IntoTable("personalize_data_tbl1")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", FirstName = "�������", MiddleName = "����������", LastName = "��������", Birthday = "1967-01-01" })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", FirstName = "�����", MiddleName = "����������", LastName = "�������", Birthday = "1977-08-14" })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", FirstName = "�����", MiddleName = "���������", LastName = "�������", Birthday = "2000-01-01" });
        Insert.IntoTable("personalize_data_tbl2")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", Country = "������", Area = "���������� �������", City = "������", Phone = "89999999999" })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", Country = "������", Area = "����������� �������", City = "���������", Phone = "89201331266" })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", Country = "������", Area = "����������� �������", City = "�������", Phone = "89201070055" });
        Insert.IntoTable("personalize_data_tbl3")
            .Row(new { Data_id = "f5cbda48-83bf-4f9a-89fc-248486877501", Street = "���� ��������", Home = 45, Building = "2�", Flat = 55 })
            .Row(new { Data_id = "ea6e7e29-dc2e-4b39-9363-5da837b12a24", Street = "������", Home = 12, Building = "�3", Flat = 12 })
            .Row(new { Data_id = "81316db9-333f-4031-ae6f-ecb79c2c4072", Street = "�������� �������", Home = 4, Building = "�2", Flat = 56 });
    }

	public override void Down()
	{
	}
}

