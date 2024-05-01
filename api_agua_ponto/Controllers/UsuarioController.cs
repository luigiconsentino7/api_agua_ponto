using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_agua_ponto.Models;
using api_agua_ponto.Data;

namespace api_agua_ponto.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : Controller
    {
        readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar todos os Usuários
        /// </summary>
        /// <returns>Todos os Usuário</returns>
        /// <response code = "200">Sucesso</response>
        [HttpGet("GetAllUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var departamento = _context.UsuarioDb.ToList();

            return Ok(departamento);
        }

        /// <summary>
        /// Listar um Usuário específico por ID junto com sua lista de Rotina
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Usuário</returns>
        /// <reponse code="200">Sucesso</reponse>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("GetUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var usuario = _context.UsuarioDb
                .Include(u => u.Rotinas)
                .SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Cadastrar um Usuário
        /// </summary>
        /// <remarks>
        ///
        /// ```json
        /// {
        ///     "email": "string",
        ///     "senha": "string",
        ///     "nome": "string",
        ///     "sobrenome": "string",
        ///     "dataNascimento": "string",
        ///     "peso": double,
        ///     "idade": int,
        ///     "altura": "string",
        ///     "rotinaAcorda": "string",
        ///     "rotinaDorme": "string",
        ///     "mediaAgua": int
        /// }
        /// ```
        /// 
        /// </remarks>
        /// <param name="usuario"></param>
        /// <returns>Usuário Criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost("PostUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.SetSenhaHash();
                _context.UsuarioDb.Add(usuario);
                _context.SaveChanges();


                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }

            return BadRequest();

        }

        /// <summary>
        /// Atualizar um Usuário por ID
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <param name="input">Dados do Usuário</param>
        /// <returns>Nada.</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut("UpdateUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, Usuario input)
        {
            var usuario = _context.UsuarioDb.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            usuario.Email = input.Email;
            usuario.Senha = input.Senha;
            usuario.Nome = input.Nome;
            usuario.Sobrenome = input.Sobrenome;
            usuario.DataNascimento = input.DataNascimento;
            usuario.Peso = input.Peso;
            usuario.Idade = input.Idade;
            usuario.Altura = input.Altura;
            usuario.RotinaAcorda = input.RotinaAcorda;
            usuario.RotinaDorme = input.RotinaDorme;
            usuario.MediaAgua = input.MediaAgua;


            _context.UsuarioDb.Update(usuario);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
