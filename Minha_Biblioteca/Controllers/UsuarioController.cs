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
                         GETDATE()
                        )";
            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=Minha_Biblioteca; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = usuarioModel.Nome,
                        Email = usuarioModel.Email,
                        Senha = usuarioModel.Senha
                    }).FirstOrDefault();
            }
        }
        [HttpPut]
        [Route("Update")]
        public void Update(UsuarioModel usuarioModel)
        {
            var query = @"Update usuario set
                            Nome = @Nome,
                            Email = @Email,
                            Senha = @Senha
                        where ID = @ID";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=Minha_Biblioteca; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = usuarioModel.Nome,
                        Email = usuarioModel.Email,
                        Senha = usuarioModel.Senha,
                        ID = usuarioModel.ID
                    }).FirstOrDefault();
            }
        }
    }
}