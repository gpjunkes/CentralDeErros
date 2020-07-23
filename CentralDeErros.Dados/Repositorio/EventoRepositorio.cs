using CentralDeErros.Dominio.Modelos;
using System;
using System.Collections.Generic;

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
            var evento1 = new Evento()
            {
                Id = 1,
                Ambiente = 1,
                Level = 1,
                Titulo = "Teste 001",
                Quantidade = 1,
                Data = new DateTime(),
                Descricao = "Teste 001",
                Origem = "Teste 001"
            };

            var evento2 = new Evento()
            {
                Id = 2,
                Ambiente = 2,
                Level = 2,
                Titulo = "Teste 002",
                Quantidade = 2,
                Data = new DateTime(),
                Descricao = "Teste 002",
                Origem = "Teste 002"
            };

            var eventos = new List<Evento>();
            eventos.Add(evento1);
            eventos.Add(evento2);

            return eventos;
            //return _contexto.Evento.ToList();
        }
    }
}
