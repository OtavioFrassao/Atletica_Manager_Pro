using System;
using System.Collections.Generic;

namespace Atletica.Domain.Entities
{
    public class Cargo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        
        // Relacionamento: Um cargo pode ter vários membros
        private readonly List<Membro> _membros = new List<Membro>();
        public IReadOnlyCollection<Membro> Membros => _membros.AsReadOnly();

        // Construtor para criação
        public Cargo(string nome, string descricao)
        {
            ValidarNome(nome);
            Nome = nome;
            Descricao = descricao ?? string.Empty;
        }

        // Construtor para reconstrução (EF Core)
        private Cargo() { }

        public void AtualizarDados(string nome, string descricao)
        {
            ValidarNome(nome);
            Nome = nome;
            Descricao = descricao ?? string.Empty;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cargo é obrigatório.", nameof(nome));
            
            if (nome.Length > 100)
                throw new ArgumentException("O nome do cargo não pode ter mais de 100 caracteres.", nameof(nome));
        }
    }
}
