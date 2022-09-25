using VentasDale.Core.Interfaces;
using VentasDale.Domain.Dto;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Core.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAll()
        {
            try
            {
                IList<ClienteResponseDto> listado = new List<ClienteResponseDto>();

                var lista = await _repository.GetAll();
                foreach(var c in lista)
                {
                    listado.Add(new ClienteResponseDto
                    {
                        ClienteId = c.ClienteId,
                        Cedula = c.Cedula,
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                        Telefono = c.Telefono,
                        CantidadFacturas = c.Ventas.Count,
                        TotalValorFacturas = c.Ventas.Any() ? c.Ventas.Sum(v => v.VentasDetalle.Sum(vd => vd.Cantidad * vd.ValorUnitario)) : 0
                    });
                }

                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteResponseDto> GetById(int id)
        {
            try
            {
                Cliente? cliente = await _repository.GetById(id);
                ClienteResponseDto clienteDto = new()
                {
                    ClienteId = cliente.ClienteId,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Telefono = cliente.Telefono,
                    CantidadFacturas = cliente.Ventas.Count,
                    TotalValorFacturas = cliente.Ventas.Any() ? cliente.Ventas.Sum(v => v.VentasDetalle.Sum(vd => vd.Cantidad * vd.ValorUnitario)) : 0
                };

                return clienteDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteResponseDto> GetByCedula(string cedula)
        {
            try
            {
                Cliente? cliente = await _repository.GetByCedula(cedula ?? string.Empty);

                if(cliente == null)
                {
                    return new ClienteResponseDto()
                    {
                        ClienteId = 0,
                        Cedula = string.Empty,
                        Nombre = string.Empty,
                        Apellido = string.Empty,
                        Telefono = string.Empty,
                        CantidadFacturas = 0,
                        TotalValorFacturas = 0
                    };
                }

                return new ClienteResponseDto()
                {
                    ClienteId = cliente.ClienteId,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Telefono = cliente.Telefono,
                    CantidadFacturas = cliente.Ventas.Count,
                    TotalValorFacturas = cliente.Ventas.Any() ? cliente.Ventas.Sum(v => v.VentasDetalle.Sum(vd => vd.Cantidad * vd.ValorUnitario)) : 0
                }; ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteRequestDto> Save(ClienteRequestDto request)
        {
            try
            {
                Cliente cliente = new()
                {
                    ClienteId = request.ClienteId,
                    Cedula = request.Cedula,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono
                };

                cliente = await _repository.Save(cliente);

                request = new()
                {
                    ClienteId = cliente.ClienteId,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Telefono = cliente.Telefono
                };

                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteRequestDto> Update(ClienteRequestDto request)
        {
            try
            {
                Cliente cliente = new()
                {
                    ClienteId = request.ClienteId,
                    Cedula = request.Cedula,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono
                };

                cliente = await _repository.Update(cliente);

                request = new()
                {
                    ClienteId = cliente.ClienteId,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Telefono = cliente.Telefono
                };

                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
