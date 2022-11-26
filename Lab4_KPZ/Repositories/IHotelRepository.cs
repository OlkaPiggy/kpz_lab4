using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_KPZ.Models;

namespace Lab4_KPZ.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> Get();
        Task<Hotel> Get(int id);
        Task<Hotel> Create(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(int id);
    }
}
