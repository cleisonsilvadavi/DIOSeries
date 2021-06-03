using System;
using System.Collections.Generic;
using DIO.Series.interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> listaserie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaserie[id] = entidade;
        }

        public void Excluir(int Id)
        {
            listaserie[Id].Excluido = true;
        }

        public void insere(Serie entidade)
        {
            listaserie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaserie;
        }

        public int ProximoId()
        {
            return listaserie.Count;
        }

        public Serie RetornaporId(int Id)
        {
            return listaserie[Id];
        }

    }
}