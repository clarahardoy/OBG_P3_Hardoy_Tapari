using Agencia.DTOs.DTOs.ComentarioDTO;
using Agencia.LogicaNegocio.Entidades;

namespace Agencia.DTOs.Mappers;

public class MapperSeguimiento
{
    public static Comentario ToComentario(Usuario autor, string descripcion)
    {
        return new Comentario(descripcion, autor);
    }

    public static List<DTOComentario> ToListDtoComentario(List<Comentario> comentarios)
    {
        List<DTOComentario> ret = new List<DTOComentario>();
        foreach (Comentario comentario in comentarios)
        {
            DTOComentario dto = new DTOComentario();
            dto.Id = comentario.Id;
            dto.Descripcion = comentario._descripcion;
            dto.Fecha = comentario._fecha;
            dto.EmpleadoAutor = comentario._empleadoAutor._nombreCompleto._nombre + " " + comentario._empleadoAutor._nombreCompleto._apellido;
            ret.Add(dto);
        }
        return ret;
    }
}