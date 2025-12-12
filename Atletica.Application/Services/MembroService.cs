using Atletica.Application.DTOs;
using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Application.Services
{
    public class MembroService
    {
        private readonly IMembroRepository _membroRepository;
        private readonly ICargoRepository _cargoRepository;

        public MembroService(IMembroRepository membroRepository, ICargoRepository cargoRepository)
        {
            _membroRepository = membroRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<MembroDto>> GetAllMembrosAsync()
        {
            var membros = await _membroRepository.GetAllAsync();
            return membros.Select(m => new MembroDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Curso = m.Curso,
                Matricula = m.Matricula,
                Contato = m.Contato,
                DataEntrada = m.DataEntrada,
                CargoId = m.CargoId,
                CargoNome = m.Cargo?.Nome ?? ""
            });
        }

        public async Task<MembroDto> GetMembroByIdAsync(int id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            if (membro == null)
                return null;

            return new MembroDto
            {
                Id = membro.Id,
                Nome = membro.Nome,
                Curso = membro.Curso,
                Turma = membro.Turma,
                Matricula = membro.Matricula,
                Contato = membro.Contato,
                DataEntrada = membro.DataEntrada,
                CargoId = membro.CargoId,
                CargoNome = membro.Cargo?.Nome ?? ""
            };
        }

        public async Task<IEnumerable<MembroDto>> GetMembrosByCargoAsync(int cargoId)
        {
            var membros = await _membroRepository.GetByCargoIdAsync(cargoId);
            return membros.Select(m => new MembroDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Curso = m.Curso,
                Turma = m.Turma,
                Matricula = m.Matricula,
                Contato = m.Contato,
                DataEntrada = m.DataEntrada,
                CargoId = m.CargoId,
                CargoNome = m.Cargo?.Nome ?? ""
            });
        }

        public async Task<MembroDto> CreateMembroAsync(CreateMembroDto createDto)
        {
            // Valida se o cargo existe
            var cargoExists = await _cargoRepository.ExistsAsync(createDto.CargoId);
            if (!cargoExists)
                throw new InvalidOperationException("O cargo especificado não existe.");

            var membro = new Membro(
                createDto.Nome,
                createDto.Curso,
                createDto.Turma,
                createDto.Matricula,
                createDto.CargoId,
                createDto.Contato
            );

            var createdMembro = await _membroRepository.AddAsync(membro);
            
            // Recarrega para obter o cargo
            var membroCompleto = await _membroRepository.GetByIdAsync(createdMembro.Id);

            return new MembroDto
            {
                Id = membroCompleto.Id,
                Nome = membroCompleto.Nome,
                Curso = membroCompleto.Curso,
                Turma = membroCompleto.Turma,
                Matricula = membroCompleto.Matricula,
                Contato = membroCompleto.Contato,
                DataEntrada = membroCompleto.DataEntrada,
                CargoId = membroCompleto.CargoId,
                CargoNome = membroCompleto.Cargo?.Nome ?? ""
            };
        }

        public async Task<bool> UpdateMembroAsync(UpdateMembroDto updateDto)
        {
            var membro = await _membroRepository.GetByIdAsync(updateDto.Id);
            if (membro == null)
                return false;

            // Valida se o cargo existe
            var cargoExists = await _cargoRepository.ExistsAsync(updateDto.CargoId);
            if (!cargoExists)
                throw new InvalidOperationException("O cargo especificado não existe.");

            membro.AtualizarDados(
                updateDto.Nome,
                updateDto.Curso,
                updateDto.Turma,
                updateDto.Matricula,
                updateDto.CargoId,
                updateDto.Contato
            );

            await _membroRepository.UpdateAsync(membro);
            return true;
        }

        public async Task<bool> DeleteMembroAsync(int id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            if (membro == null)
                return false;

            await _membroRepository.DeleteAsync(id);
            return true;
        }
    }
}
