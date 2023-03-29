using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPostingBrowser.Api.Models;
using JobPostingBrowser.Core;

namespace JobPostingBrowser.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly JobContext _context;

        public JobDetailsController(JobContext context)
        {
            _context = context;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetails>>> GetJobDetailsSet()
        {
          if (_context.JobDetailsSet == null)
          {
              return NotFound();
          }
            return await _context.JobDetailsSet.ToListAsync();
        }

        // GET: api/JobDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetails>> GetJobDetails(int? id)
        {
          if (_context.JobDetailsSet == null)
          {
              return NotFound();
          }
            var jobDetails = await _context.JobDetailsSet.FindAsync(id);

            if (jobDetails == null)
            {
                return NotFound();
            }

            return jobDetails;
        }

        // PUT: api/JobDetails/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutJobDetails(int? id, JobDetails jobDetails)
        //{
        //    if (id != jobDetails.JobId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(jobDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobDetailsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/JobDetails
        [HttpPost]
        public async Task<ActionResult<JobDetails>> PostJobDetails(JobDetails jobDetails)
        {
          if (_context.JobDetailsSet == null)
          {
              return Problem("Entity set 'JobContext.JobDetailsSet'  is null.");
          }
            _context.JobDetailsSet.Add(jobDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobDetails), new { id = jobDetails.JobId }, jobDetails);
        }

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetails(int? id)
        {
            if (_context.JobDetailsSet == null)
            {
                return NotFound();
            }
            var jobDetails = await _context.JobDetailsSet.FindAsync(id);
            if (jobDetails == null)
            {
                return NotFound();
            }

            _context.JobDetailsSet.Remove(jobDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDetailsExists(int? id)
        {
            return (_context.JobDetailsSet?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}
