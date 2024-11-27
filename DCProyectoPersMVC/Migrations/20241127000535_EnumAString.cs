using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCProyectoPersMVC.Migrations
{
   
    public partial class EnumAString : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<string>(
                name: "DC_Tipo_Temp",
                table: "DCBebida",
                type: "nvarchar(20)",
                nullable: true);

            
            migrationBuilder.Sql(@"
        UPDATE DCBebida
        SET DC_Tipo_Temp = CASE DC_Tipo
            WHEN 0 THEN 'RON'
            WHEN 1 THEN 'WHISKY'
            WHEN 2 THEN 'VODKA'
            WHEN 3 THEN 'TEQUILA'
        END");

           
            migrationBuilder.DropColumn(
                name: "DC_Tipo",
                table: "DCBebida");

            
            migrationBuilder.RenameColumn(
                name: "DC_Tipo_Temp",
                table: "DCBebida",
                newName: "DC_Tipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "DC_Tipo_Temp",
                table: "DCBebida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
            migrationBuilder.Sql(@"
        UPDATE DCBebida
        SET DC_Tipo_Temp = CASE DC_Tipo
            WHEN 'RON' THEN 0
            WHEN 'WHISKY' THEN 1
            WHEN 'VODKA' THEN 2
            WHEN 'TEQUILA' THEN 3
        END");

           
            migrationBuilder.DropColumn(
                name: "DC_Tipo",
                table: "DCBebida");

           
            migrationBuilder.RenameColumn(
                name: "DC_Tipo_Temp",
                table: "DCBebida",
                newName: "DC_Tipo");
        }

    }
}
