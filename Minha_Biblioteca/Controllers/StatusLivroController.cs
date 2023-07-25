using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minha_Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minha_Biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusLivroController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(StatusLivroModel statuslivroModel)
        {
            var query = @"insert into statuslivro values
                        (
                         @Nome
                        )";
            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=Minha_Biblioteca; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = statuslivroModel.Nome
                    }).FirstOrDefault();
            }
        }
    }
}

