using System;

namespace Atletica.Application.DTOs
{
    public class MembroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Matricula { get; set; }
        public string Contato { get; set; }
        public DateTime DataEntrada { get; set; }
        public int CargoId { get; set; }
        public string CargoNome { get; set; }
    }

    public class CreateMembroDto
    {
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Matricula { get; set; }
        public string Contato { get; set; }
        public DateTime DataEntrada { get; set; }
        public int CargoId { get; set; }
    }

    public class UpdateMembroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Turma { get; set; }
        public string Matricula { get; set; }
        public string Contato { get; set; }
        public DateTime DataEntrada { get; set; }
        public int CargoId { get; set; }
    }
}
