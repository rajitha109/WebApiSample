using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSampleModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerSampleModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSampleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSampleModel>>> GetCustomerSampleModel()
        {
            return await _context.CustomerSampleModel.ToListAsync();
        }

        // GET: api/CustomerSampleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSampleModel>> GetCustomerSampleModel(int id)
        {
            var customerSampleModel = await _context.CustomerSampleModel.FindAsync(id);

            if (customerSampleModel == null)
            {
                return NotFound();
            }

            return customerSampleModel;
        }

        // PUT: api/CustomerSampleModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerSampleModel(int id, CustomerSampleModel customerSampleModel)
        {
            if (id != customerSampleModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerSampleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSampleModelExists(id))
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

        // POST: api/CustomerSampleModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerSampleModel>> PostCustomerSampleModel(CustomerSampleModel customerSampleModel)
        {
            _context.CustomerSampleModel.Add(customerSampleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerSampleModel", new { id = customerSampleModel.Id }, customerSampleModel);
        }

        // DELETE: api/CustomerSampleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSampleModel(int id)
        {
            var customerSampleModel = await _context.CustomerSampleModel.FindAsync(id);
            if (customerSampleModel == null)
            {
                return NotFound();
            }

            _context.CustomerSampleModel.Remove(customerSampleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerSampleModelExists(int id)
        {
            return _context.CustomerSampleModel.Any(e => e.Id == id);
        }
    }
}
