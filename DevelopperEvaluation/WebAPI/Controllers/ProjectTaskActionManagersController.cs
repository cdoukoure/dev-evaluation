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
    public class ProjectTaskActionManagersController : ControllerBase
    {
        private readonly IntegrationCharlesDoukoureDevEvalContext _context;

        public ProjectTaskActionManagersController(IntegrationCharlesDoukoureDevEvalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTaskActionManagers
        [HttpGet]
        public IEnumerable<ProjectTaskActionManager> GetProjectTaskActionManager()
        {
            return _context.ProjectTaskActionManager;
        }

        // GET: api/ProjectTaskActionManagers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectTaskActionManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTaskActionManager = await _context.ProjectTaskActionManager.FindAsync(id);

            if (projectTaskActionManager == null)
            {
                return NotFound();
            }

            return Ok(projectTaskActionManager);
        }

        // PUT: api/ProjectTaskActionManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTaskActionManager([FromRoute] int id, [FromBody] ProjectTaskActionManager projectTaskActionManager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTaskActionManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectTaskActionManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskActionManagerExists(id))
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

        // POST: api/ProjectTaskActionManagers
        [HttpPost]
        public async Task<IActionResult> PostProjectTaskActionManager([FromBody] ProjectTaskActionManager projectTaskActionManager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectTaskActionManager.Add(projectTaskActionManager);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectTaskActionManagerExists(projectTaskActionManager.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectTaskActionManager", new { id = projectTaskActionManager.Id }, projectTaskActionManager);
        }

        // DELETE: api/ProjectTaskActionManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTaskActionManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTaskActionManager = await _context.ProjectTaskActionManager.FindAsync(id);
            if (projectTaskActionManager == null)
            {
                return NotFound();
            }

            _context.ProjectTaskActionManager.Remove(projectTaskActionManager);
            await _context.SaveChangesAsync();

            return Ok(projectTaskActionManager);
        }

        private bool ProjectTaskActionManagerExists(int id)
        {
            return _context.ProjectTaskActionManager.Any(e => e.Id == id);
        }
    }
}