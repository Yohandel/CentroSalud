using CentroSalud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Interfaces
{
    public interface IHorarioRepository
    {
        Task<List<Horario?>> GetAllAsync();
        Task<Horario?> GetByIdAsync(int id);
        Task<Horario?> AddAsync(Horario? horario);
        Task<Horario?> UpdateAsync(Horario? horario);
        Task<Horario?> DeleteAsync(int id);


    }
}
