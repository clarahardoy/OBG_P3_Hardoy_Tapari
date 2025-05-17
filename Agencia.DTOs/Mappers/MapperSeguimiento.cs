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
            dto.Descripcion = comentario.Descripcion;
            dto.Fecha = comentario.Fecha;
            dto.EmpleadoAutor = comentario.EmpleadoAutor?.NombreCompleto.Nombre + " " + comentario.EmpleadoAutor?.NombreCompleto.Apellido;

            ret.Add(dto);
        }
        return ret;
    }
}