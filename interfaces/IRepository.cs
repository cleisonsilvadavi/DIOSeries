    using System.Collections.Generic;

namespace DIO.Series.interfaces
{
    public interface IRepository<T>
    {
      List<T> Lista();
      T RetornaporId(int Id);
      void insere(T entidade);
      void Excluir(int Id);
      void Atualiza(int id, T entidade);
      int ProximoId();
    }
}