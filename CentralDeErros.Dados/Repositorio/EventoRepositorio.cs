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

        public Evento SelecionarPorId(int id)
        {
            return _contexto.Evento.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Arquivar(int id)
        {
            var evento = SelecionarPorId(id);

            evento.Status = 1;
            _contexto.Evento.Update(evento);
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var evento = SelecionarPorId(id);
            _contexto.Evento.Remove(evento);
            _contexto.SaveChanges();
        }
    }
}
