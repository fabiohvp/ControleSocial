using ControleSocial.Domain.Models.ControleSocial;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.Autenticacao
{
	public class SignIn : QueryableWorkflow<Usuario, SignIn.Result>
	{
		public string Email { get; set; }
		public string Senha { get; set; }

		public SignIn(string email, string senha)
		{
			Email = email;
			Senha = senha;
		}

		public override Result Execute(IQueryable<Usuario> entryData)
		{
			var usuario = entryData.FirstOrDefault(o => o.Email == Email && o.Senha == Senha);

			if (usuario == default)
			{
				throw new InvalidCredentialException("Credencial inválida");
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
					{
										new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
										new Claim(ClaimTypes.Email, usuario.Email),
										new Claim(ClaimTypes.Role, usuario.Roles),
					}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Result
			{
				Email = Email,
				Roles = usuario.Roles,
				Token = tokenHandler.WriteToken(token),
				Expiration = token.ValidTo,
			};
		}

		public class Result
		{
			public string Email { get; set; }
			public string Roles { get; set; }
			public string Token { get; set; }
			public DateTime Expiration { get; set; }
		}
	}
}
