using Agencia.LogicaNegocio.Entidades;

namespace Agencia.DTOs.Mappers;

public class MapperSeguimiento
{
    public static Comentario ToComentario(Usuario autor, string descripcion)
    {
        return new Comentario(descripcion, autor);
    }
}