using ControleSocial.Attributes;

namespace ControleSocial.Domain.Models
{
	public enum TipoModulo
	{
		MunicipioDespesa = 1,
		MunicipioEducacao = 2,
		MunicipioPessoalConsolidado = 3,
		MunicipioPessoalExecutivo = 4,
		MunicipioPessoalLegislativo = 5,
		MunicipioReceita = 6,
		MunicipioSaude = 7,
		MunicipioObrigacaoEnvio = 20,
		MunicipioVisaoGeral = 21,
		MunicipioAlertaLRF = 22,
		MunicipioPrevidencia = 23,

		EstadoDespesa = 501,
		EstadoEducacao = 502,

		[TipoModuloPessoal(CodigoPoder = "C")]
		EstadoPessoalConsolidado = 503,

		[TipoModuloPessoal(CodigoPoder = "E")]
		EstadoPessoalExecutivo = 504,

		[TipoModuloPessoal(CodigoPoder = "J")]
		EstadoPessoalJudiciario = 505,

		[TipoModuloPessoal(CodigoPoder = "L")]
		EstadoPessoalLegislativo = 506,

		[TipoModuloPessoal(CodigoPoder = "M")]
		EstadoPessoalMinisterioPublico = 507,

		[TipoModuloPessoal(CodigoPoder = "T")]
		EstadoPessoalTribunalDeContas = 508,
		EstadoReceita = 509,
		EstadoSaude = 510,

		[TipoModuloPessoal(CodigoPoder = "D")]
		EstadoPessoalDefensoriaPublica = 511,

		EstadoObrigacaoEnvio = 520,

		EsferaAdministrativaTransparenciaPassiva = 1001,
		EsferaAdministrativaTransparenciaPortal = 1002,
		EsferaAdministrativaPrestacaoConta = 1003,
		EsferaAdministrativaIEGM = 1004,
		EsferaAdministrativaTransparenciaControleInterno = 1005,

		Obras = 10000,
		UnidadeGestora = 10001,
		Paineis = 10002,

		MunicipioEducacaoMagisterio = 2001,
		MunicipioCapag = 5000,
		MunicipioAtosPessoal = 8000,
		FolhaDePagamento = 9000
	}
}
