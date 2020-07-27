// using ControleSocial.Domain.Contexts;
// using ControleSocial.Domain.Models.ControleSocial;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using WorkflowApi.Core.Workflows;

// namespace ControleSocial.Workflows.Autenticacao
// {
// 	public class Refresh : Workflow
// 	{
// 		private readonly TokenValidationParameters TokenValidationParameters;
// 		public string Token { get; set; }
// 		public string RefreshToken { get; set; }

// 		public Refresh(string token, string refreshToken, TokenValidationParameters tokenValidationParameters)
// 		{
// 			Token = token;
// 			RefreshToken = refreshToken;
// 			TokenValidationParameters = tokenValidationParameters;
// 		}

// 		public override object Execute(object entryData)
// 		{
// 			var validatedToken = GetPrincipalFromToken(Token);

// 			if (validatedToken == default)
// 			{
// 				throw new InvalidOperationException("Token inválido");
// 			}

// 			var expiryDateUnix =
// 					long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

// 			var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
// 					.AddSeconds(expiryDateUnix);

// 			if (expiryDateTimeUtc > DateTime.UtcNow)
// 			{
// 				throw new InvalidOperationException("Token não expirou ainda");
// 			}

// 			var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

// 			var query = entryData.AsQueryable<UsuarioRefreshToken>(DbContext);
// 			var storedRefreshToken = query.SingleOrDefault(x => x.Token == RefreshToken);

// 			if (storedRefreshToken == null)
// 			{
// 				throw new InvalidOperationException("Refresh token não existe");
// 			}

// 			if (DateTime.UtcNow > storedRefreshToken.DataExpiracao)
// 			{
// 				throw new InvalidOperationException("Token expirado");
// 			}

// 			if (storedRefreshToken.Invalido)
// 			{
// 				throw new InvalidOperationException("Token foi invalidado");
// 			}

// 			if (storedRefreshToken.Usado)
// 			{
// 				throw new InvalidOperationException("Token já foi utilizado");
// 			}

// 			if (storedRefreshToken.JwtId != jti)
// 			{
// 				throw new InvalidOperationException("Token inválido");
// 			}

// 			storedRefreshToken.Usado = true;

// 			var dbContext = DbContext.As<ControleSocialContext>();
// 			dbContext.Update(storedRefreshToken);
// 			dbContext.SaveChanges();

// 			var idUsuarioString = validatedToken.Claims.Single(o => o.Type == nameof(Usuario.Id)).Value;
// 			var idUsuario = default(long);

// 			if (idUsuarioString != default)
// 			{
// 				idUsuario = long.Parse(idUsuarioString);
// 			}

// 			var usuario = query.FirstOrDefault(o => o.Id == idUsuario);
// 			//return await GenerateAuthenticationResultForUserAsync(usuario);
// 			return true;
// 		}

// 		private ClaimsPrincipal GetPrincipalFromToken(string token)
// 		{
// 			var tokenHandler = new JwtSecurityTokenHandler();

// 			try
// 			{
// 				var tokenValidationParameters = TokenValidationParameters.Clone();
// 				tokenValidationParameters.ValidateLifetime = false;
// 				var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
// 				if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
// 				{
// 					return null;
// 				}

// 				return principal;
// 			}
// 			catch
// 			{
// 				return null;
// 			}
// 		}

// 		private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
// 		{
// 			return (validatedToken is JwtSecurityToken jwtSecurityToken)
// 					&& jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
// 		}


// 		private void GenerateAuthenticationResultForUserAsync(Usuario usuario)
// 		{
// 			var tokenHandler = new JwtSecurityTokenHandler();
// 			var key = Encoding.ASCII.GetBytes(Settings.Secret);

// 			var claims = new List<Claim>
// 						{
// 								new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
// 								new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
// 								new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
// 								new Claim(nameof(Usuario.Id), usuario.Id.ToString())
// 						};

// 			claims.Add(new Claim(ClaimTypes.Role, "Admin"));
// 			//var userClaims = await _userManager.GetClaimsAsync(usuario);
// 			//claims.AddRange(userClaims);

// 			//var userRoles = await _userManager.GetRolesAsync(usuario);
// 			//foreach (var userRole in userRoles)
// 			//{
// 			//    claims.Add(new Claim(ClaimTypes.Role, userRole));
// 			//    var role = await _roleManager.FindByNameAsync(userRole);
// 			//    if (role == null) continue;
// 			//    var roleClaims = await _roleManager.GetClaimsAsync(role);

// 			//    foreach (var roleClaim in roleClaims)
// 			//    {
// 			//        if (claims.Contains(roleClaim))
// 			//            continue;

// 			//        claims.Add(roleClaim);
// 			//    }
// 			//}

// 			var tokenDescriptor = new SecurityTokenDescriptor
// 			{
// 				Subject = new ClaimsIdentity(claims),
// 				Expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(30)),
// 				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
// 			};

// 			var token = tokenHandler.CreateToken(tokenDescriptor);

// 			var refreshToken = new UsuarioRefreshToken
// 			{
// 				JwtId = token.Id,
// 				IdUsuario = usuario.Id,
// 				DataCriacao = DateTime.UtcNow,
// 				DataExpiracao = DateTime.UtcNow.AddMinutes(2)
// 			};

// 			//await _context.RefreshTokens.AddAsync(refreshToken);
// 			//await _context.SaveChangesAsync();

// 			//return new AuthenticationResult
// 			//{
// 			//    Success = true,
// 			//    Token = tokenHandler.WriteToken(token),
// 			//    RefreshToken = refreshToken.Token
// 			//};
// 		}
// 	}
// }
