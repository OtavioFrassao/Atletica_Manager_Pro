using System;

namespace Atletica.Application.DTOs
{
    public class TarefaLimpezaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public int MembroResponsavelId { get; set; }
        public string MembroResponsavelNome { get; set; }
        public string MembroResponsavelCargo { get; set; }
    }

    public class CreateTarefaLimpezaDto
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int MembroResponsavelId { get; set; }
    }

    public class UpdateTarefaLimpezaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int MembroResponsavelId { get; set; }
        public bool Concluido { get; set; }
    }
}
