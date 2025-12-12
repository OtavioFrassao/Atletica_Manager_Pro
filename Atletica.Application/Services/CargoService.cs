using Atletica.Application.DTOs;
using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Application.Services
{
    public class CargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<CargoDto>> GetAllCargosAsync()
        {
            var cargos = await _cargoRepository.GetAllAsync();
            return cargos.Select(c => new CargoDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            });
        }

        public async Task<CargoDto> GetCargoByIdAsync(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            if (cargo == null)
                return null;

            return new CargoDto
            {
                Id = cargo.Id,
                Nome = cargo.Nome,
                Descricao = cargo.Descricao
            };
        }

        public async Task<CargoDto> CreateCargoAsync(CreateCargoDto createDto)
        {
            // Validar se já existe um cargo com o mesmo nome
            var cargosExistentes = await _cargoRepository.GetAllAsync();
            if (cargosExistentes.Any(c => c.Nome.Equals(createDto.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Já existe um cargo com o nome '{createDto.Nome}'.");
            }

            var cargo = new Cargo(createDto.Nome, createDto.Descricao);
            var createdCargo = await _cargoRepository.AddAsync(cargo);

            return new CargoDto
            {
                Id = createdCargo.Id,
                Nome = createdCargo.Nome,
                Descricao = createdCargo.Descricao
            };
        }

        public async Task<bool> UpdateCargoAsync(UpdateCargoDto updateDto)
        {
            var cargo = await _cargoRepository.GetByIdAsync(updateDto.Id);
            if (cargo == null)
                return false;

            // Validar se já existe outro cargo com o mesmo nome
            var cargosExistentes = await _cargoRepository.GetAllAsync();
            if (cargosExistentes.Any(c => c.Id != updateDto.Id && c.Nome.Equals(updateDto.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Já existe outro cargo com o nome '{updateDto.Nome}'.");
            }

            cargo.AtualizarDados(updateDto.Nome, updateDto.Descricao);
            await _cargoRepository.UpdateAsync(cargo);
            return true;
        }

        public async Task<bool> DeleteCargoAsync(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            if (cargo == null)
                return false;

            // Verifica se há membros associados
            if (cargo.Membros.Any())
                throw new InvalidOperationException("Não é possível excluir um cargo que possui membros associados.");

            await _cargoRepository.DeleteAsync(id);
            return true;
        }
    }
}
