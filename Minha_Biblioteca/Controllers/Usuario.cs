using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minha_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Minha_Biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(UsuarioModel usuarioModel)
        {
            var query = @"insert into usuario values
                        (
                         @Nome,
                         @Email,
                         @Senha,
                         @Data_cadastro
                        )";
            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = usuarioModel.nome,
                        Email = usuarioModel.email,
                        Senha = usuarioModel.senha,
                        Data_cadastro = usuarioModel.data_cadastro
                    }).FirstOrDefault();
            }
        }
    }
}