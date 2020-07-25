using System.Threading.Tasks;
using CentralDeErros.Dados.Repositorio;
using CentralDeErros.Dominio.Servicos;
using CentralDeErros.Dominio.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repo;
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioRepositorio repo, IUsuarioService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] UsuarioViewModel usuario)
        {
            return await _repo.Incluir(usuario.Nome, usuario.Email, usuario.Senha);
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginViewModel login)
        {
            var usu = await _repo.Login(login.Email, login.Senha);
            return _service.GerarToken(usu);
        }
    }
}
