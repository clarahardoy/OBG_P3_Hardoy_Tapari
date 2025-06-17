using Agencia.DTOs.DTOs.AgenciaDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;

public interface ICUObtenerSucursal
{
    DTOSucursal Ejecutar(int id);
}