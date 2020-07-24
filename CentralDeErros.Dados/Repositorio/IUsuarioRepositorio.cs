using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CentralDeErros.Dados.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<bool> Incluir(string nome, string email, string senha);
        Task<IdentityUser> Login(string email, string senha);
    }
}
