using System;
using System.Collections.Generic;

namespace ControleSocial.Domain.Models.ControleSocial
{
    public class Usuario : IEntity
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Roles { get; set; }

        public virtual ICollection<UsuarioRefreshToken> RefreshTokens { get; }
    }
}
