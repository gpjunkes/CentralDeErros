using CentralDeErros.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Dados.Repositorio
{
    public class EventoRepositorio : IEventoRepositorio
    {
        protected readonly Contexto _contexto;

        public EventoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Incluir(Evento evento)
        {
            _contexto.Evento.Add(evento);
            _contexto.SaveChanges();
        }
        public List<Evento> SelecionarTodos()
        {
            return _contexto.Evento.ToList();
        }
    }
}
