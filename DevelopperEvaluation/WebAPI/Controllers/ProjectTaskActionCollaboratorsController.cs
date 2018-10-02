using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskActionCollaboratorsController : ControllerBase
    {
        private readonly IntegrationCharlesDoukoureDevEvalContext _context;

        public ProjectTaskActionCollaboratorsController(IntegrationCharlesDoukoureDevEvalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTaskActionCollaborators
        [HttpGet]
        public IEnumerable<ProjectTaskActionCollaborator> GetProjectTaskActionCollaborator()
        {
            return _context.ProjectTaskActionCollaborator;
        }

        // GET: api/ProjectTaskActionCollaborators/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectTaskActionCollaborator([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTaskActionCollaborator = await _context.ProjectTaskActionCollaborator.FindAsync(id);

            if (projectTaskActionCollaborator == null)
            {
                return NotFound();
            }

            return Ok(projectTaskActionCollaborator);
        }

        // PUT: api/ProjectTaskActionCollaborators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTaskActionCollaborator([FromRoute] int id, [FromBody] ProjectTaskActionCollaborator projectTaskActionCollaborator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTaskActionCollaborator.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectTaskActionCollaborator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskActionCollaboratorExists(id))
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

        // POST: api/ProjectTaskActionCollaborators
        [HttpPost]
        public async Task<IActionResult> PostProjectTaskActionCollaborator([FromBody] ProjectTaskActionCollaborator projectTaskActionCollaborator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectTaskActionCollaborator.Add(projectTaskActionCollaborator);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectTaskActionCollaboratorExists(projectTaskActionCollaborator.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectTaskActionCollaborator", new { id = projectTaskActionCollaborator.Id }, projectTaskActionCollaborator);
        }

        // DELETE: api/ProjectTaskActionCollaborators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTaskActionCollaborator([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTaskActionCollaborator = await _context.ProjectTaskActionCollaborator.FindAsync(id);
            if (projectTaskActionCollaborator == null)
            {
                return NotFound();
            }

            _context.ProjectTaskActionCollaborator.Remove(projectTaskActionCollaborator);
            await _context.SaveChangesAsync();

            return Ok(projectTaskActionCollaborator);
        }

        private bool ProjectTaskActionCollaboratorExists(int id)
        {
            return _context.ProjectTaskActionCollaborator.Any(e => e.Id == id);
        }
    }
}