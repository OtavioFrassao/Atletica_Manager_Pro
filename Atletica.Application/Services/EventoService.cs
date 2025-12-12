using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atletica.Application.DTOs;
using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;

namespace Atletica.Application.Services
{
    public class EventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventosAsync()
        {
            var eventos = await _eventoRepository.GetAllAsync();
            return eventos.Select(e => new EventoDto
            {
                Id = e.Id,
                Titulo = e.Titulo,
                Descricao = e.Descricao,
                DataInicio = e.DataInicio,
                DataFim = e.DataFim,
                Local = e.Local,
                MembroResponsavelId = e.MembroResponsavelId,
                MembroResponsavelNome = e.MembroResponsavel?.Nome
            });
        }

        public async Task<EventoDto?> GetEventoByIdAsync(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null) return null;

            return new EventoDto
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Descricao = evento.Descricao,
                DataInicio = evento.DataInicio,
                DataFim = evento.DataFim,
                Local = evento.Local,
                MembroResponsavelId = evento.MembroResponsavelId,
                MembroResponsavelNome = evento.MembroResponsavel?.Nome
            };
        }

        public async Task CreateEventoAsync(CreateEventoDto dto)
        {
            var evento = new Evento(
                dto.Titulo,
                dto.Descricao,
                dto.DataInicio,
                dto.DataFim,
                dto.Local,
                dto.MembroResponsavelId
            );

            await _eventoRepository.AddAsync(evento);
        }

        public async Task UpdateEventoAsync(UpdateEventoDto dto)
        {
            var evento = await _eventoRepository.GetByIdAsync(dto.Id);
            if (evento == null)
                throw new Exception("Evento não encontrado.");

            evento.AtualizarDados(
                dto.Titulo,
                dto.Descricao,
                dto.DataInicio,
                dto.DataFim,
                dto.Local,
                dto.MembroResponsavelId
            );

            await _eventoRepository.UpdateAsync(evento);
        }

        public async Task DeleteEventoAsync(int id)
        {
            await _eventoRepository.DeleteAsync(id);
        }
    }
}
