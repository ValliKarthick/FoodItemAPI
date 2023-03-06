using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api___Scaffolded.Models;

namespace Web_Api___Scaffolded.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemDetailsController : ControllerBase
    {
        private readonly FoodOrderingDbContext _context;

        public FoodItemDetailsController(FoodOrderingDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodItemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItemDetail>>> GetFoodItemDetails()
        {
            return await _context.FoodItemDetails.ToListAsync();
        }

        // GET: api/FoodItemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDetail>> GetFoodItemDetail(string id)
        {
            var foodItemDetail = await _context.FoodItemDetails.FindAsync(id);

            if (foodItemDetail == null)
            {
                return NotFound();
            }

            return foodItemDetail;
        }

        // PUT: api/FoodItemDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItemDetail(string id, FoodItemDetail foodItemDetail)
        {
            if (id != foodItemDetail.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(foodItemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemDetailExists(id))
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

        // POST: api/FoodItemDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItemDetail>> PostFoodItemDetail(FoodItemDetail foodItemDetail)
        {
            _context.FoodItemDetails.Add(foodItemDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FoodItemDetailExists(foodItemDetail.FoodId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFoodItemDetail", new { id = foodItemDetail.FoodId }, foodItemDetail);
        }

        // DELETE: api/FoodItemDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItemDetail(string id)
        {
            var foodItemDetail = await _context.FoodItemDetails.FindAsync(id);
            if (foodItemDetail == null)
            {
                return NotFound();
            }

            _context.FoodItemDetails.Remove(foodItemDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemDetailExists(string id)
        {
            return _context.FoodItemDetails.Any(e => e.FoodId == id);
        }
    }
}
