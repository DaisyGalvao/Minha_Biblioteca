using System;

namespace CRUD.Models
{
    public class LivroModel
    {
        public int ID { get; set; }
        public int ID_usuario { get; set; }
        public int ID_status { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Data_atualizacao { get; set; }
        public DateTime Data_cadastro { get; set; }

    }
}
