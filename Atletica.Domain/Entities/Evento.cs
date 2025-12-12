using System;

namespace Atletica.Domain.Entities
{
    public class Evento
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public string? Local { get; private set; }
        public int? MembroResponsavelId { get; private set; }
        public Membro? MembroResponsavel { get; private set; }

        public Evento(string titulo, string descricao, DateTime dataInicio, DateTime? dataFim, string? local, int? membroResponsavelId)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Local = local;
            MembroResponsavelId = membroResponsavelId;
        }

        public void AtualizarDados(string titulo, string descricao, DateTime dataInicio, DateTime? dataFim, string? local, int? membroResponsavelId)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Local = local;
            MembroResponsavelId = membroResponsavelId;
        }
    }
}
