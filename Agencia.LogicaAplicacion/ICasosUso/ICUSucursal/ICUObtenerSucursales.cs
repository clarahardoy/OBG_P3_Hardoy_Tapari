using Agencia.DTOs.DTOs.AgenciaDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;

public interface ICUObtenerSucursales
{
    List<DTOSucursal> ListarSucursales();
}