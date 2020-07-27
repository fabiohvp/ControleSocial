using System;

namespace ControleSocial.Domain.Models.ControleSocial
{
    public class UsuarioRefreshToken : IEntity
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }

        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Usado { get; set; }
        public bool Invalido { get; set; }

        public Usuario Usuario { get; set; }
    }
}
