using CentralDeErros.Dados.Repositorio;
using CentralDeErros.Dominio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CentralDeErros.Api.Controllers
{
    [Authorize]
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

        [Route("{id}")]
        [HttpGet]
        public Evento Get(int id)
        {
            return _repositorio.SelecionarPorId(id);
        }

        [Route("")]
        [HttpPost]
        public void Post([FromBody] Evento evento)
        {
            _repositorio.Incluir(evento);
        }

        [Route("/api/Evento/arquivar/{id}")]
        [HttpPut]
        public void Arquivar(int id)
        {
            _repositorio.Arquivar(id);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _repositorio.Excluir(id);
        }
    }
}
