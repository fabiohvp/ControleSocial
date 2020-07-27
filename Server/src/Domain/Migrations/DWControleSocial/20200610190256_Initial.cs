using System;
using ControleSocial.Domain.Models.DWControleSocial;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleSocial.Domain.Migrations.DWControleSocial
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.EnsureSchema(
					name: nameof(DWControleSocial));

			migrationBuilder.EnsureSchema(
					name: "__stub");

			migrationBuilder.CreateTable(
					name: "__SeedHistory",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Arquivo = table.Column<string>(maxLength: 60, nullable: false),
						Hash = table.Column<string>(maxLength: 32, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK___SeedHistory", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoDespesaDotacaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoCategoria = table.Column<string>(maxLength: 1, nullable: true),
						CodigoGrupo = table.Column<string>(maxLength: 1, nullable: true),
						CodigoModalidade = table.Column<string>(maxLength: 2, nullable: true),
						CodigoElemento = table.Column<string>(maxLength: 2, nullable: true),
						CodigoSubElemento = table.Column<string>(maxLength: 2, nullable: true),
						NomeCategoria = table.Column<string>(maxLength: 200, nullable: true),
						NomeGrupo = table.Column<string>(maxLength: 200, nullable: true),
						NomeModalidade = table.Column<string>(maxLength: 200, nullable: true),
						NomeElemento = table.Column<string>(maxLength: 200, nullable: true),
						NomeSubElemento = table.Column<string>(maxLength: 200, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 8, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoDespesaDotacaoMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoFonteERecursoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoUnidadeGestora = table.Column<string>(maxLength: 11, nullable: false),
						CodigoGrupo = table.Column<string>(maxLength: 1, nullable: true),
						CodigoFonteReduzida = table.Column<string>(maxLength: 7, nullable: true),
						CodigoDetalhamento = table.Column<string>(maxLength: 7, nullable: true),
						NomeGrupo = table.Column<string>(maxLength: 200, nullable: true),
						NomeFonteReduzida = table.Column<string>(maxLength: 200, nullable: true),
						NomeDetalhamento = table.Column<string>(maxLength: 250, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 15, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoFonteERecursoMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoFuncaoESubFuncaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoFuncao = table.Column<string>(maxLength: 2, nullable: true),
						CodigoSubFuncao = table.Column<string>(maxLength: 3, nullable: true),
						NomeFuncao = table.Column<string>(maxLength: 200, nullable: true),
						NomeSubFuncao = table.Column<string>(maxLength: 200, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 5, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoFuncaoESubFuncaoMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoUnidadeGestora = table.Column<string>(maxLength: 11, nullable: false),
						CodigoOrgao = table.Column<string>(maxLength: 6, nullable: true),
						NomeOrgao = table.Column<string>(maxLength: 60, nullable: true),
						CodigoUnidadeOrcamentaria = table.Column<string>(maxLength: 6, nullable: true),
						NomeUnidadeOrcamentaria = table.Column<string>(maxLength: 60, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 12, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoProgramaEAcaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoUnidadeGestora = table.Column<string>(maxLength: 11, nullable: false),
						CodigoPrograma = table.Column<string>(maxLength: 4, nullable: true),
						CodigoAcao = table.Column<string>(maxLength: 5, nullable: true),
						NomePrograma = table.Column<string>(maxLength: 200, nullable: true),
						NomeAcao = table.Column<string>(maxLength: 200, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 9, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoProgramaEAcaoMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_ClassificacaoReceitaDotacaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						CodigoCategoria = table.Column<string>(maxLength: 1, nullable: true),
						CodigoOrigem = table.Column<string>(maxLength: 1, nullable: true),
						CodigoEspecie = table.Column<string>(maxLength: 1, nullable: true),
						CodigoRubrica = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "-"),
						CodigoAlinea = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "--"),
						CodigoSubAlinea = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "--"),
						CodigoDetalhamentoNivel1 = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "-"),
						CodigoDetalhamentoNivel2 = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "--"),
						CodigoDetalhamentoNivel3 = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "-"),
						CodigoTipoDetalhamento = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "-"),
						NomeCategoria = table.Column<string>(maxLength: 200, nullable: true),
						NomeOrigem = table.Column<string>(maxLength: 200, nullable: true),
						NomeEspecie = table.Column<string>(maxLength: 200, nullable: true),
						NomeRubrica = table.Column<string>(maxLength: 200, nullable: true),
						NomeAlinea = table.Column<string>(maxLength: 200, nullable: true),
						NomeSubAlinea = table.Column<string>(maxLength: 200, nullable: true),
						NomeDetalhamentoNivel1 = table.Column<string>(maxLength: 200, nullable: true),
						NomeDetalhamentoNivel2 = table.Column<string>(maxLength: 200, nullable: true),
						NomeDetalhamentoNivel3 = table.Column<string>(maxLength: 200, nullable: true),
						NomeTipoDetalhamento = table.Column<string>(maxLength: 200, nullable: true),
						CodigoCompleto = table.Column<string>(maxLength: 13, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_ClassificacaoReceitaDotacaoMunicipio", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_EsferaAdministrativa",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Codigo = table.Column<string>(maxLength: 3, nullable: false),
						Nome = table.Column<string>(maxLength: 200, nullable: false),
						CodigoIBGE = table.Column<long>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_EsferaAdministrativa", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_Periodo",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Codigo = table.Column<string>(maxLength: 20, nullable: false),
						Nome = table.Column<string>(maxLength: 20, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_Periodo", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_Tempo",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Ano = table.Column<short>(nullable: false),
						Mes = table.Column<short>(nullable: false),
						Data = table.Column<DateTime>(nullable: false),
						Bimestre = table.Column<short>(nullable: false),
						Trimestre = table.Column<short>(nullable: false),
						Quadrimestre = table.Column<short>(nullable: false),
						Semestre = table.Column<short>(nullable: false),
						NomeMes = table.Column<string>(maxLength: 20, nullable: false),
						NomeBimestre = table.Column<string>(maxLength: 20, nullable: false),
						NomeTrimestre = table.Column<string>(maxLength: 20, nullable: false),
						NomeQuadrimestre = table.Column<string>(maxLength: 20, nullable: false),
						NomeSemestre = table.Column<string>(maxLength: 20, nullable: false),
						AbreviacaoMes = table.Column<string>(maxLength: 20, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_Tempo", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "DIM_UnidadeGestora",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						Nome = table.Column<string>(maxLength: 200, nullable: false),
						Codigo = table.Column<string>(maxLength: 11, nullable: false),
						CodigoOriginal = table.Column<string>(maxLength: 20, nullable: true),
						NomePoder = table.Column<string>(maxLength: 200, nullable: true),
						CodigoPoder = table.Column<string>(maxLength: 1, nullable: true),
						CodigoTipoUnidadeGestora = table.Column<string>(maxLength: 2, nullable: true),
						NomeTipoUnidadeGestora = table.Column<string>(maxLength: 100, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DIM_UnidadeGestora", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "__stub_query_data",
					schema: "__stub",
					columns: table => new
					{
						id = table.Column<int>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						long1 = table.Column<long>(nullable: true),
						long2 = table.Column<long>(nullable: true),
						long3 = table.Column<long>(nullable: true),
						double1 = table.Column<double>(nullable: true),
						double2 = table.Column<double>(nullable: true),
						double3 = table.Column<double>(nullable: true),
						string1 = table.Column<string>(nullable: true),
						string2 = table.Column<string>(nullable: true),
						string3 = table.Column<string>(nullable: true),
						date1 = table.Column<DateTime>(nullable: true),
						date2 = table.Column<DateTime>(nullable: true),
						date3 = table.Column<DateTime>(nullable: true),
						guid1 = table.Column<Guid>(nullable: true),
						guid2 = table.Column<Guid>(nullable: true),
						guid3 = table.Column<Guid>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK___stub_query_data", x => x.id);
					});

			migrationBuilder.CreateTable(
					name: "FT_DespesaDotacaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						IdSeedHistory = table.Column<long>(nullable: false),
						IdOriginal = table.Column<long>(nullable: false),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						IdClassificacaoFonteRecurso = table.Column<long>(nullable: false),
						IdClassificacaoFuncional = table.Column<long>(nullable: false),
						IdClassificacaoNatureza = table.Column<long>(nullable: false),
						IdClassificacaoOrcamentaria = table.Column<long>(nullable: false),
						IdClassificacaoPrograma = table.Column<long>(nullable: false),
						IdEsferaAdministrativa = table.Column<long>(nullable: false),
						IdPeriodo = table.Column<long>(nullable: false),
						IdTempo = table.Column<long>(nullable: false),
						IdUnidadeGestora = table.Column<long>(nullable: false),
						PrevisaoAtualizada = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						PrevisaoInicial = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						Empenhada = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						Liquidada = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						Paga = table.Column<decimal>(type: "decimal(20,2)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FT_DespesaDotacaoMunicipio", x => x.Id);
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_ClassificacaoFonteERecursoMunicipio_IdClassificacaoFonteRecurso",
											column: x => x.IdClassificacaoFonteRecurso,
											principalTable: "DIM_ClassificacaoFonteERecursoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_ClassificacaoFuncaoESubFuncaoMunicipio_IdClassificacaoFuncional",
											column: x => x.IdClassificacaoFuncional,
											principalTable: "DIM_ClassificacaoFuncaoESubFuncaoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_ClassificacaoDespesaDotacaoMunicipio_IdClassificacaoNatureza",
											column: x => x.IdClassificacaoNatureza,
											principalTable: "DIM_ClassificacaoDespesaDotacaoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio_IdClassificacaoOrcamentaria",
											column: x => x.IdClassificacaoOrcamentaria,
											principalTable: "DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_ClassificacaoProgramaEAcaoMunicipio_IdClassificacaoPrograma",
											column: x => x.IdClassificacaoPrograma,
											principalTable: "DIM_ClassificacaoProgramaEAcaoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_EsferaAdministrativa_IdEsferaAdministrativa",
											column: x => x.IdEsferaAdministrativa,
											principalTable: "DIM_EsferaAdministrativa",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_Periodo_IdPeriodo",
											column: x => x.IdPeriodo,
											principalTable: "DIM_Periodo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio___SeedHistory_IdSeedHistory",
											column: x => x.IdSeedHistory,
											principalTable: "__SeedHistory",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_Tempo_IdTempo",
											column: x => x.IdTempo,
											principalTable: "DIM_Tempo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_DespesaDotacaoMunicipio_DIM_UnidadeGestora_IdUnidadeGestora",
											column: x => x.IdUnidadeGestora,
											principalTable: "DIM_UnidadeGestora",
											principalColumn: "Id");
					});

			migrationBuilder.CreateTable(
					name: "FT_PrestacaoContaMensal",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						IdSeedHistory = table.Column<long>(nullable: false),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						IdTempo = table.Column<long>(nullable: false),
						IdEsferaAdministrativa = table.Column<long>(nullable: false),
						IdPeriodo = table.Column<long>(nullable: false),
						IdUnidadeGestora = table.Column<long>(nullable: false),
						DataLimite = table.Column<DateTime>(nullable: false),
						DataHomologacao = table.Column<DateTime>(nullable: true),
						EmAtraso = table.Column<bool>(nullable: false, computedColumnSql: "CASE WHEN DataHomologacao is not null and DataHomologacao > DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END"),
						EmDia = table.Column<bool>(nullable: false, computedColumnSql: "CASE WHEN DataHomologacao is not null and DataHomologacao <= DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END"),
						EmOmissao = table.Column<bool>(nullable: false, computedColumnSql: "CASE WHEN DataHomologacao is null and getdate() >= DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END"),
						EmTempo = table.Column<bool>(nullable: false, computedColumnSql: "CASE WHEN DataHomologacao is null and getdate() < DataLimite THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END")
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FT_PrestacaoContaMensal", x => x.Id);
						table.ForeignKey(
											name: "FK_FT_PrestacaoContaMensal_DIM_EsferaAdministrativa_IdEsferaAdministrativa",
											column: x => x.IdEsferaAdministrativa,
											principalTable: "DIM_EsferaAdministrativa",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_PrestacaoContaMensal_DIM_Periodo_IdPeriodo",
											column: x => x.IdPeriodo,
											principalTable: "DIM_Periodo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_PrestacaoContaMensal___SeedHistory_IdSeedHistory",
											column: x => x.IdSeedHistory,
											principalTable: "__SeedHistory",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_PrestacaoContaMensal_DIM_Tempo_IdTempo",
											column: x => x.IdTempo,
											principalTable: "DIM_Tempo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_PrestacaoContaMensal_DIM_UnidadeGestora_IdUnidadeGestora",
											column: x => x.IdUnidadeGestora,
											principalTable: "DIM_UnidadeGestora",
											principalColumn: "Id");
					});

			migrationBuilder.CreateTable(
					name: "FT_ReceitaDotacaoMunicipio",
					columns: table => new
					{
						Id = table.Column<long>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						IdSeedHistory = table.Column<long>(nullable: false),
						IdOriginal = table.Column<long>(nullable: false),
						DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
						IdClassificacaoFonteRecurso = table.Column<long>(nullable: false),
						IdClassificacaoNatureza = table.Column<long>(nullable: false),
						IdEsferaAdministrativa = table.Column<long>(nullable: false),
						IdPeriodo = table.Column<long>(nullable: false),
						IdTempo = table.Column<long>(nullable: false),
						IdUnidadeGestora = table.Column<long>(nullable: false),
						PrevisaoAtualizada = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						PrevisaoInicial = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						Arrecadada = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						PrevisaoAtualizadaFUNDEB = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						PrevisaoInicialFUNDEB = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
						ArrecadadaFUNDEB = table.Column<decimal>(type: "decimal(20,2)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FT_ReceitaDotacaoMunicipio", x => x.Id);
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_ClassificacaoFonteERecursoMunicipio_IdClassificacaoFonteRecurso",
											column: x => x.IdClassificacaoFonteRecurso,
											principalTable: "DIM_ClassificacaoFonteERecursoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_ClassificacaoReceitaDotacaoMunicipio_IdClassificacaoNatureza",
											column: x => x.IdClassificacaoNatureza,
											principalTable: "DIM_ClassificacaoReceitaDotacaoMunicipio",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_EsferaAdministrativa_IdEsferaAdministrativa",
											column: x => x.IdEsferaAdministrativa,
											principalTable: "DIM_EsferaAdministrativa",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_Periodo_IdPeriodo",
											column: x => x.IdPeriodo,
											principalTable: "DIM_Periodo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio___SeedHistory_IdSeedHistory",
											column: x => x.IdSeedHistory,
											principalTable: "__SeedHistory",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_Tempo_IdTempo",
											column: x => x.IdTempo,
											principalTable: "DIM_Tempo",
											principalColumn: "Id");
						table.ForeignKey(
											name: "FK_FT_ReceitaDotacaoMunicipio_DIM_UnidadeGestora_IdUnidadeGestora",
											column: x => x.IdUnidadeGestora,
											principalTable: "DIM_UnidadeGestora",
											principalColumn: "Id");
					});

			migrationBuilder.CreateIndex(
					name: "IX___SeedHistory_Hash",
					table: "__SeedHistory",
					column: "Hash",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_DIM_ClassificacaoDespesaDotacaoMunicipio_CodigoCategoria_CodigoElemento_CodigoGrupo_CodigoModalidade_CodigoSubElemento_NomeC~",
					table: "DIM_ClassificacaoDespesaDotacaoMunicipio",
					columns: new[] { "CodigoCategoria", "CodigoElemento", "CodigoGrupo", "CodigoModalidade", "CodigoSubElemento", "NomeCategoria", "NomeElemento", "NomeGrupo", "NomeModalidade", "NomeSubElemento" },
					unique: true,
					filter: "[CodigoCategoria] IS NOT NULL AND [CodigoElemento] IS NOT NULL AND [CodigoGrupo] IS NOT NULL AND [CodigoModalidade] IS NOT NULL AND [CodigoSubElemento] IS NOT NULL AND [NomeCategoria] IS NOT NULL AND [NomeElemento] IS NOT NULL AND [NomeGrupo] IS NOT NULL AND [NomeModalidade] IS NOT NULL AND [NomeSubElemento] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_DIM_ClassificacaoFonteERecursoMunicipio_CodigoUnidadeGestora_CodigoDetalhamento_CodigoFonteReduzida_CodigoGrupo_NomeDetalham~",
					table: "DIM_ClassificacaoFonteERecursoMunicipio",
					columns: new[] { "CodigoUnidadeGestora", "CodigoDetalhamento", "CodigoFonteReduzida", "CodigoGrupo", "NomeDetalhamento", "NomeFonteReduzida", "NomeGrupo" },
					unique: true,
					filter: "[CodigoDetalhamento] IS NOT NULL AND [CodigoFonteReduzida] IS NOT NULL AND [CodigoGrupo] IS NOT NULL AND [NomeDetalhamento] IS NOT NULL AND [NomeFonteReduzida] IS NOT NULL AND [NomeGrupo] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_DIM_ClassificacaoFuncaoESubFuncaoMunicipio_CodigoFuncao_CodigoSubFuncao_NomeFuncao_NomeSubFuncao",
					table: "DIM_ClassificacaoFuncaoESubFuncaoMunicipio",
					columns: new[] { "CodigoFuncao", "CodigoSubFuncao", "NomeFuncao", "NomeSubFuncao" },
					unique: true,
					filter: "[CodigoFuncao] IS NOT NULL AND [CodigoSubFuncao] IS NOT NULL AND [NomeFuncao] IS NOT NULL AND [NomeSubFuncao] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio_CodigoOrgao_CodigoUnidadeGestora_CodigoUnidadeOrcamentaria_NomeOrgao_Nom~",
					table: "DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio",
					columns: new[] { "CodigoOrgao", "CodigoUnidadeGestora", "CodigoUnidadeOrcamentaria", "NomeOrgao", "NomeUnidadeOrcamentaria" },
					unique: true,
					filter: "[CodigoOrgao] IS NOT NULL AND [CodigoUnidadeOrcamentaria] IS NOT NULL AND [NomeOrgao] IS NOT NULL AND [NomeUnidadeOrcamentaria] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_DIM_ClassificacaoProgramaEAcaoMunicipio_CodigoUnidadeGestora_CodigoAcao_CodigoPrograma_NomeAcao_NomePrograma",
					table: "DIM_ClassificacaoProgramaEAcaoMunicipio",
					columns: new[] { "CodigoUnidadeGestora", "CodigoAcao", "CodigoPrograma", "NomeAcao", "NomePrograma" },
					unique: true,
					filter: "[CodigoAcao] IS NOT NULL AND [CodigoPrograma] IS NOT NULL AND [NomeAcao] IS NOT NULL AND [NomePrograma] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_DIM_EsferaAdministrativa_Codigo",
					table: "DIM_EsferaAdministrativa",
					column: "Codigo",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_DIM_Periodo_Codigo_Nome",
					table: "DIM_Periodo",
					columns: new[] { "Codigo", "Nome" },
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_DIM_Tempo_Ano_Mes",
					table: "DIM_Tempo",
					columns: new[] { "Ano", "Mes" },
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_DIM_UnidadeGestora_Codigo_CodigoOriginal_Nome_NomePoder_CodigoTipoUnidadeGestora_NomeTipoUnidadeGestora",
					table: "DIM_UnidadeGestora",
					columns: new[] { "Codigo", "CodigoOriginal", "Nome", "NomePoder", "CodigoTipoUnidadeGestora", "NomeTipoUnidadeGestora" },
					unique: true,
					filter: "[CodigoOriginal] IS NOT NULL AND [NomePoder] IS NOT NULL AND [CodigoTipoUnidadeGestora] IS NOT NULL AND [NomeTipoUnidadeGestora] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdClassificacaoFonteRecurso",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdClassificacaoFonteRecurso");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdClassificacaoFuncional",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdClassificacaoFuncional");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdClassificacaoNatureza",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdClassificacaoNatureza");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdClassificacaoOrcamentaria",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdClassificacaoOrcamentaria");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdClassificacaoPrograma",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdClassificacaoPrograma");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdEsferaAdministrativa",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdEsferaAdministrativa");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdOriginal",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdOriginal",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdPeriodo",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdPeriodo");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdSeedHistory",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdSeedHistory");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdTempo",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdTempo");

			migrationBuilder.CreateIndex(
					name: "IX_FT_DespesaDotacaoMunicipio_IdUnidadeGestora",
					table: "FT_DespesaDotacaoMunicipio",
					column: "IdUnidadeGestora");

			migrationBuilder.CreateIndex(
					name: "IX_FT_PrestacaoContaMensal_IdEsferaAdministrativa",
					table: "FT_PrestacaoContaMensal",
					column: "IdEsferaAdministrativa");

			migrationBuilder.CreateIndex(
					name: "IX_FT_PrestacaoContaMensal_IdPeriodo",
					table: "FT_PrestacaoContaMensal",
					column: "IdPeriodo");

			migrationBuilder.CreateIndex(
					name: "IX_FT_PrestacaoContaMensal_IdSeedHistory",
					table: "FT_PrestacaoContaMensal",
					column: "IdSeedHistory");

			migrationBuilder.CreateIndex(
					name: "IX_FT_PrestacaoContaMensal_IdUnidadeGestora",
					table: "FT_PrestacaoContaMensal",
					column: "IdUnidadeGestora");

			migrationBuilder.CreateIndex(
					name: "IX_FT_PrestacaoContaMensal_IdTempo_IdEsferaAdministrativa_IdPeriodo_IdUnidadeGestora",
					table: "FT_PrestacaoContaMensal",
					columns: new[] { "IdTempo", "IdEsferaAdministrativa", "IdPeriodo", "IdUnidadeGestora" },
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdClassificacaoFonteRecurso",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdClassificacaoFonteRecurso");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdClassificacaoNatureza",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdClassificacaoNatureza");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdEsferaAdministrativa",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdEsferaAdministrativa");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdOriginal",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdOriginal",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdPeriodo",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdPeriodo");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdSeedHistory",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdSeedHistory");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdTempo",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdTempo");

			migrationBuilder.CreateIndex(
					name: "IX_FT_ReceitaDotacaoMunicipio_IdUnidadeGestora",
					table: "FT_ReceitaDotacaoMunicipio",
					column: "IdUnidadeGestora");

			migrationBuilder.UpColumnStoreIndex(nameof(FT_ReceitaDotacaoMunicipio));
			migrationBuilder.UpColumnStoreIndex(nameof(FT_PrestacaoContaMensal));
			migrationBuilder.UpColumnStoreIndex(nameof(FT_DespesaDotacaoMunicipio));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DownColumnStoreIndex(nameof(FT_ReceitaDotacaoMunicipio));
			migrationBuilder.DownColumnStoreIndex(nameof(FT_PrestacaoContaMensal));
			migrationBuilder.DownColumnStoreIndex(nameof(FT_DespesaDotacaoMunicipio));

			migrationBuilder.DropTable(
					name: "FT_DespesaDotacaoMunicipio");

			migrationBuilder.DropTable(
					name: "FT_PrestacaoContaMensal");

			migrationBuilder.DropTable(
					name: "FT_ReceitaDotacaoMunicipio");

			migrationBuilder.DropTable(
					name: "__stub_query_data",
					schema: "__stub");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoFuncaoESubFuncaoMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoDespesaDotacaoMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoOrgaoEUnidadeOrcamentariaMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoProgramaEAcaoMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoFonteERecursoMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_ClassificacaoReceitaDotacaoMunicipio");

			migrationBuilder.DropTable(
					name: "DIM_EsferaAdministrativa");

			migrationBuilder.DropTable(
					name: "DIM_Periodo");

			migrationBuilder.DropTable(
					name: "__SeedHistory");

			migrationBuilder.DropTable(
					name: "DIM_Tempo");

			migrationBuilder.DropTable(
					name: "DIM_UnidadeGestora");
		}
	}
}
