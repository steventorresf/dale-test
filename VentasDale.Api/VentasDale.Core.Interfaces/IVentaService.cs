using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDale.Domain.Dto;

namespace VentasDale.Core.Interfaces
{
    public interface IVentaService
    {
        Task<IEnumerable<VentaResponseDto>> GetAll();
        Task<VentaResponseDto> GetById(int id);
        Task<VentaRequestDto> Save(VentaRequestDto requestDto);
    }
}
