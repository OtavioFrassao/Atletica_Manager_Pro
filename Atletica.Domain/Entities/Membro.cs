using System;

namespace Atletica.Domain.Entities
{
    public class Membro
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Curso { get; private set; }
        public string Turma { get; private set; }
        public string Matricula { get; private set; }
        public string Contato { get; private set; }
        public DateTime DataEntrada { get; private set; }
        
        // Relacionamento: Muitos membros para um cargo
        public int CargoId { get; private set; }
        public Cargo Cargo { get; private set; }

        // Construtor para criação
        public Membro(string nome, string curso, string turma, string matricula, int cargoId, string contato = null)
        {
            ValidarDados(nome, curso, matricula);
            
            Nome = nome;
            Curso = curso;
            Turma = turma ?? string.Empty;
            Matricula = matricula;
            CargoId = cargoId;
            Contato = contato ?? string.Empty;
            DataEntrada = DateTime.Now;
        }

        // Construtor para reconstrução (EF Core)
        private Membro() { }

        public void AtualizarDados(string nome, string curso, string turma, string matricula, int cargoId, string contato)
        {
            ValidarDados(nome, curso, matricula);
            
            Nome = nome;
            Curso = curso;
            Turma = turma ?? string.Empty;
            Matricula = matricula;
            CargoId = cargoId;
            Contato = contato ?? string.Empty;
        }

        public void AlterarCargo(int novoCargoId)
        {
            if (novoCargoId <= 0)
                throw new ArgumentException("Cargo inválido.", nameof(novoCargoId));
            
            CargoId = novoCargoId;
        }

        private void ValidarDados(string nome, string curso, string matricula)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do membro é obrigatório.", nameof(nome));
            
            if (nome.Length > 150)
                throw new ArgumentException("O nome não pode ter mais de 150 caracteres.", nameof(nome));
            
            if (string.IsNullOrWhiteSpace(curso))
                throw new ArgumentException("O curso é obrigatório.", nameof(curso));
            
            if (curso.Length > 100)
                throw new ArgumentException("O curso não pode ter mais de 100 caracteres.", nameof(curso));
            
            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("A matrícula é obrigatória.", nameof(matricula));
        }
    }
}
