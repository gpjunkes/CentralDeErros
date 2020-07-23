using System;

namespace CentralDeErros.Dominio.Modelos
{
    public class Evento
    {
        public int Id { get; set; }
        public int Ambiente { get; set; }
        public int Level { get; set; }
        public string Titulo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Origem { get; set; }
    }
}
