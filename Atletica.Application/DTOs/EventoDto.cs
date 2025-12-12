using System;

namespace Atletica.Application.DTOs
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Local { get; set; }
        public int? MembroResponsavelId { get; set; }
        public string? MembroResponsavelNome { get; set; }
    }

    public class CreateEventoDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Local { get; set; }
        public int? MembroResponsavelId { get; set; }
    }

    public class UpdateEventoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Local { get; set; }
        public int? MembroResponsavelId { get; set; }
    }
}
