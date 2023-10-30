using FluentMigrator;
using System.Xml.Linq;

namespace DbMigrator.Migrations;

[Migration(20231030163713)]
public class AddPermissions : Migration
{
	public override void Up()
	{
        Insert.IntoTable("dc_permissions")
            .Row(new { Name = "„астичный просмотр", Description = "¬озможность частичного просмотра (обезличенных) персональных данных" })
			.Row(new { Name = "ѕолный просмотр", Description = "¬озможность полного просмотра (деобезличенных) персональных данных" })
			.Row(new { Name = "–едактирование", Description = "¬озможность редактировани€ персональных данных вне зависимости от их представлени€" });
    }

	public override void Down()
	{
	}
}

