using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_KPZ.Models;
using Lab4_KPZ.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_KPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository1;
        public HotelsController(IHotelRepository hotelRepository)
        {
            hotelRepository1 = hotelRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await hotelRepository1.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotels(int id)
        {
            return await hotelRepository1.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> PostBooks([FromBody] Hotel hotel)
        {
            var newHotel = await hotelRepository1.Create(hotel);
            return CreatedAtAction(nameof(GetHotels), new { id = newHotel.Id }, newHotel);
        }

        [HttpPut]
        public async Task<ActionResult<Hotel>> UpdateBooks(int id,[FromBody] Hotel hotel)
        {
            if(id!=hotel.Id)
            {
                return BadRequest();
            }
            await hotelRepository1.Update(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hoteltoDelete = await hotelRepository1.Get(id);
            if (hoteltoDelete == null)
                return NotFound();
            await hotelRepository1.Delete(hoteltoDelete.Id);
            return NoContent();
        }

    }
}
