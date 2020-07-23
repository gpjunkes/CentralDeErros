using CentralDeErros.Dominio.Modelos;
using System.Collections.Generic;

namespace CentralDeErros.Dados.Repositorio
{
    public interface IEventoRepositorio
    {
        void Incluir(Evento evento);
        List<Evento> SelecionarTodos();
    }
}
