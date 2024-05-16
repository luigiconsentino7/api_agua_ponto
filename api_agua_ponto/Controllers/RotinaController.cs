using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_agua_ponto.Models;
using api_agua_ponto.Data;

namespace api_agua_ponto.Controllers
{
    [Route("api/rotina")]
    [ApiController]
    public class RotinaController : Controller
    {
        readonly AppDbContext _context;

        private readonly TimeZoneInfo _brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public RotinaController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar uma Rotina pelo ID do Usuário
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Rotina</returns>
        /// <reponse code="200">Sucesso</reponse>
        /// <response code="404">Rotina não encontrado</response>
        [HttpGet("GetRotinaByUsuarioId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var rotina = _context.RotinaDb
                .Where(r => r.UsuarioId == id).ToList();

            if (rotina == null)
            {
                return NotFound("Rotina não encontrada.");
            }
            return Ok(rotina);
        }

        /// <summary>
        /// Cadastrar uma Rotina
        /// </summary>
        /// <remarks>
        ///
        /// ```json
        /// {
        ///     "mlIngerido": int,
        ///     "usuarioId": int
        /// }
        /// ```
        /// 
        /// </remarks>
        /// <param name="rotina"></param>
        /// <returns>Rotina Criada</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost("PostRotina")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Rotina rotina)
        {
            if (ModelState.IsValid)
            {
                rotina.Ingestao = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _brasiliaTimeZone); ;
                _context.RotinaDb.Add(rotina);
                _context.SaveChanges();


                return CreatedAtAction(nameof(GetById), new { id = rotina.Id }, rotina);
            }

            return BadRequest();

        }

        /// <summary>
        /// Deletar uma Rotina por ID
        /// </summary>
        /// <param name="id">Identificador da Rotina</param>
        /// <returns>Nada.</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("DeleteRotina/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var rotina = _context.RotinaDb.SingleOrDefault(r => r.Id == id);

            if (rotina == null)
            {
                return NotFound("Rotina não encontrada.");
            }

            _context.RotinaDb.Remove(rotina);

            _context.SaveChanges();

            return NoContent();
        }

        /*
        /// <summary>
        /// Atualizar uma Rotina por ID
        /// </summary>
        /// <param name="id">Identificador da Rotina</param>
        /// <param name="input">Dados da Rotina</param>
        /// <returns>Nada.</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut("UpdateRotina/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, Rotina input)
        {
            var rotina = _context.RotinaDb.SingleOrDefault(r => r.Id == id);

            if (rotina == null)
            {
                return NotFound("Rotina não encontrada.");
            }

            rotina.PrimeiraIngestao = input.PrimeiraIngestao;


            _context.RotinaDb.Update(rotina);
            _context.SaveChanges();

            return NoContent();
        }
        */
    }
}
