using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add(T nuevo);//Retornamos int para tener el id luego de insertado
        T FindById(int id);
        void Remove(T obj);
        List<T> FindAll();
        int Update(T obj);
    }
}