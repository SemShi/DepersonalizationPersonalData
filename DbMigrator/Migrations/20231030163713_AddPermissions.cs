using FluentMigrator;
using System.Xml.Linq;

namespace DbMigrator.Migrations;

[Migration(20231030163713)]
public class AddPermissions : Migration
{
	public override void Up()
	{
        Insert.IntoTable("dc_permissions")
            .Row(new { Name = "��������� ��������", Description = "����������� ���������� ��������� (������������) ������������ ������" })
			.Row(new { Name = "������ ��������", Description = "����������� ������� ��������� (��������������) ������������ ������" })
			.Row(new { Name = "��������������", Description = "����������� �������������� ������������ ������ ��� ����������� �� �� �������������" });
    }

	public override void Down()
	{
	}
}

