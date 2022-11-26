using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_KPZ.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_KPZ.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;
        public HotelRepository(HotelContext context)
        {
            this._context = context;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
            return hotel;
        }

        public async Task Delete(int id)
        {
            var hotelToDelete = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotelToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> Get()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> Get(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
