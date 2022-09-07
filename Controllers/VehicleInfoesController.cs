using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarClinicAPI.Repository;
using CarClinicAPI.Repository.Models;

namespace CarClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInfoesController : ControllerBase
    {
        private readonly CrudOperationDbContext _context;

        public VehicleInfoesController(CrudOperationDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerTbVehicleInfo>>> GetSerTbVehicleInfos()
        {
          if (_context.SerTbVehicleInfos == null)
          {
              return NotFound();
          }
            return await _context.SerTbVehicleInfos.ToListAsync();
        }

        // GET: api/VehicleInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SerTbVehicleInfo>> GetSerTbVehicleInfo(long id)
        {
          if (_context.SerTbVehicleInfos == null)
          {
              return NotFound();
          }
            var serTbVehicleInfo = await _context.SerTbVehicleInfos.FindAsync(id);

            if (serTbVehicleInfo == null)
            {
                return NotFound();
            }

            return serTbVehicleInfo;
        }

        // PUT: api/VehicleInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerTbVehicleInfo(long id, SerTbVehicleInfo serTbVehicleInfo)
        {
            if (id != serTbVehicleInfo.VehInfoId)
            {
                return BadRequest();
            }

            _context.Entry(serTbVehicleInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerTbVehicleInfoExists(id))
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

        // POST: api/VehicleInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SerTbVehicleInfo>> PostSerTbVehicleInfo(SerTbVehicleInfo serTbVehicleInfo)
        {
          if (_context.SerTbVehicleInfos == null)
          {
              return Problem("Entity set 'CrudOperationDbContext.SerTbVehicleInfos'  is null.");
          }
            _context.SerTbVehicleInfos.Add(serTbVehicleInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerTbVehicleInfo", new { id = serTbVehicleInfo.VehInfoId }, serTbVehicleInfo);
        }

        // DELETE: api/VehicleInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerTbVehicleInfo(long id)
        {
            if (_context.SerTbVehicleInfos == null)
            {
                return NotFound();
            }
            var serTbVehicleInfo = await _context.SerTbVehicleInfos.FindAsync(id);
            if (serTbVehicleInfo == null)
            {
                return NotFound();
            }

            _context.SerTbVehicleInfos.Remove(serTbVehicleInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerTbVehicleInfoExists(long id)
        {
            return (_context.SerTbVehicleInfos?.Any(e => e.VehInfoId == id)).GetValueOrDefault();
        }
    }
}
