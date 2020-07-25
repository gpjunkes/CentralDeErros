using Microsoft.AspNetCore.Identity;

namespace CentralDeErros.Dominio.Servicos
{
    public interface IUsuarioService
    {
        string GerarToken(IdentityUser usuario);
    }
}
