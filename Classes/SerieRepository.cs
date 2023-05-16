using System;
using System.Collections.Generic;
using Crud.Interfaces;

namespace Crud
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSeries = new List<Serie>();

        public List<Serie> List()
        {
            return listSeries;
        }

        public Serie ReturnById(int id)
        {
            return listSeries[id];
        }

        public void Insert(Serie entity)
        {
            listSeries.Add(entity); 
        }

        public void Remove(int id)
        {
            listSeries[id].Delition(); 
        }

        public void Update(int id, Serie entity)
        {
            listSeries[id] = entity; 
        }

        public int NextId()
        {
            return listSeries.Count;
        }

    }
}