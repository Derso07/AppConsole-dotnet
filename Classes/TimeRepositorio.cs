using System.Collections.Generic;
using System;
using DIO.Series.Interfaces;
using DIO.Times;

namespace DIO.Series.Classes
{
    public class TimeRepositorio : IRepositorio<Time>
    {
        private List<Time> listaTime = new List<Time>();
        public void Atualiza(int id, Time objeto)
        {
            listaTime[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaTime[id].Excluir();
        }

        public void Insere(Time objeto)
        {
            listaTime.Add(objeto);
        }

        public List<Time> Lista()
        {
            return listaTime;
        }

        public int ProximoId()
        {
            return listaTime.Count;
        }

        public Time RetornaPorId(int id)
        {
            return listaTime[id];
        }
    }
}