using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_de_Series.Interfaces;

namespace Cadastro_de_Series
{
    public class SerieRepository : iRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void delete(int id)
        {
            listSerie[id].Delete();
        }

        public void Insert(Serie entity)
        {
            listSerie.Add(entity);
        }

        public List<Serie> Lista()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }

        public void update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }
    }
}