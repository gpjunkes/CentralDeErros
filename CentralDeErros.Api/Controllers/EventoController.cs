using CentralDeErros.Dados.Repositorio;
using CentralDeErros.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventoRepositorio _repositorio;
        public EventoController(IEventoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("")]
        [HttpGet]
        public List<Evento> Get()
        {
            return _repositorio.SelecionarTodos();
        }

        [Route("")]
        [HttpPost]
        public void Post([FromBody] Evento evento)
        {
            _repositorio.Incluir(evento);
        }

        [Route("")]
        [HttpDelete]
        public string Delete()
        {
            return "Hello";
        }
    }
}
