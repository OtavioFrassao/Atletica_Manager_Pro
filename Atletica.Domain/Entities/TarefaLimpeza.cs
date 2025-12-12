using System;

namespace Atletica.Domain.Entities
{
    public class TarefaLimpeza
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluido { get; private set; }
        
        // Relacionamento: Uma tarefa é atribuída a um membro
        public int MembroResponsavelId { get; private set; }
        public Membro MembroResponsavel { get; private set; }

        // Construtor para criação
        public TarefaLimpeza(DateTime data, string descricao, int membroResponsavelId)
        {
            ValidarDados(data, descricao, membroResponsavelId);
            
            Data = data;
            Descricao = descricao;
            MembroResponsavelId = membroResponsavelId;
            Concluido = false;
        }

        // Construtor para reconstrução (EF Core)
        private TarefaLimpeza() { }

        public void AtualizarDados(DateTime data, string descricao, int membroResponsavelId, bool concluido)
        {
            ValidarDados(data, descricao, membroResponsavelId);
            
            Data = data;
            Descricao = descricao;
            MembroResponsavelId = membroResponsavelId;
            Concluido = concluido;
        }

        public void MarcarComoConcluido()
        {
            if (Concluido)
                throw new InvalidOperationException("Esta tarefa já está marcada como concluída.");
            
            Concluido = true;
        }

        public void MarcarComoPendente()
        {
            if (!Concluido)
                throw new InvalidOperationException("Esta tarefa já está marcada como pendente.");
            
            Concluido = false;
        }

        private void ValidarDados(DateTime data, string descricao, int membroResponsavelId)
        {
            if (data == default(DateTime))
                throw new ArgumentException("A data é obrigatória.", nameof(data));
            
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição é obrigatória.", nameof(descricao));
            
            if (membroResponsavelId <= 0)
                throw new ArgumentException("Deve ser atribuído um membro responsável.", nameof(membroResponsavelId));
        }
    }
}
