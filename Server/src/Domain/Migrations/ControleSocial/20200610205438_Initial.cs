using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleSocial.Domain.Migrations.ControleSocial
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.EnsureSchema(
					name: nameof(ControleSocial));

			migrationBuilder.CreateTable(
					name: "Usuario",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Nome = table.Column<string>(maxLength: 80, nullable: true),
						Email = table.Column<string>(maxLength: 60, nullable: true),
						Senha = table.Column<string>(maxLength: 50, nullable: true),
						Roles = table.Column<string>(maxLength: 4000, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Usuario", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "UsuarioRefreshToken",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						IdUsuario = table.Column<long>(nullable: false),
						Token = table.Column<string>(maxLength: 256, nullable: true),
						JwtId = table.Column<string>(maxLength: 256, nullable: true),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						DataExpiracao = table.Column<DateTime>(nullable: false),
						Usado = table.Column<bool>(nullable: false),
						Invalido = table.Column<bool>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_UsuarioRefreshToken", x => x.Id);
						table.ForeignKey(
											name: "FK_UsuarioRefreshToken_Usuario_IdUsuario",
											column: x => x.IdUsuario,
											principalTable: "Usuario",
											principalColumn: "Id");
					});

			migrationBuilder.InsertData(
					table: "Usuario",
					columns: new[] { "Id", "Email", "Nome", "Roles", "Senha" },
					values: new object[] { 1L, "a", "Fábio Henriques", "Admin", "a" });

			migrationBuilder.CreateIndex(
					name: "IX_UsuarioRefreshToken_IdUsuario",
					table: "UsuarioRefreshToken",
					column: "IdUsuario");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "UsuarioRefreshToken");

			migrationBuilder.DropTable(
					name: "Usuario");
		}
	}
}
