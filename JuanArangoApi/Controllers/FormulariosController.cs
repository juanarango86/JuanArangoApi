using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuanArangoApi.Data;
using JuanArangoApi.Data.Models;
using JuanArangoApi.Data.Dto;

namespace JuanArangoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulariosController : ControllerBase
    {
        private readonly JuanArangoApiContext _context;

        public FormulariosController(JuanArangoApiContext context)
        {
            _context = context;
        }

        // GET: api/Formularios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formularios>>> GetFormularios()
        {
          if (_context.Formularios == null)
          {
              return NotFound();
          }
            return await _context.Formularios.Include(x=>x.User).ToListAsync();
        }

        // GET: api/Formularios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formularios>> GetFormularios(long id)
        {
          if (_context.Formularios == null)
          {
              return NotFound();
          }
            var formularios = await _context.Formularios.FindAsync(id);

            if (formularios == null)
            {
                return NotFound();
            }

            return formularios;
        }

        // PUT: api/Formularios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormularios(long id, Formularios formularios)
        {
            if (id != formularios.IdFormulario)
            {
                return BadRequest();
            }

            _context.Entry(formularios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormulariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Formularios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Formularios>> PostFormularios(FormularioDto formularios)
        {
          if (_context.Formularios == null)
          {
              return Problem("Entity set 'JuanArangoApiContext.Formularios'  is null.");
          }

            Formularios ObjForm = new Formularios()
            {
                Pregunta_1 = formularios.Pregunta_1,
                Pregunta_2 = formularios.Pregunta_2,
                Pregunta_3 = formularios.Pregunta_3,
                Respuesta_1 = formularios.Respuesta_1,
                Respuesta_2 = formularios.Respuesta_2,
                Respuesta_3 = formularios.Respuesta_3,
                Longitud = formularios.Longitud,
                Latitud = formularios.Latitud,
                UserId = formularios.UserId,
                User = _context.User.Where(x=>x.Id==formularios.UserId).FirstOrDefault()

            };
            _context.Formularios.Add(ObjForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormularios", new { id = ObjForm.IdFormulario }, ObjForm);
        }

        // DELETE: api/Formularios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormularios(long id)
        {
            if (_context.Formularios == null)
            {
                return NotFound();
            }
            var formularios = await _context.Formularios.FindAsync(id);
            if (formularios == null)
            {
                return NotFound();
            }

            _context.Formularios.Remove(formularios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormulariosExists(long id)
        {
            return (_context.Formularios?.Any(e => e.IdFormulario == id)).GetValueOrDefault();
        }
    }
}
