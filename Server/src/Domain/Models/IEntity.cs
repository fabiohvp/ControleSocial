using System;

namespace ControleSocial.Domain.Models
{
    public interface IEntity
    {
        public long Id { get; set; }
        DateTime DataCriacao { get; set; }
    }
}
