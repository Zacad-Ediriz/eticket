using Eticket.Data;
using Eticket.Models;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Services
{
    public class ActorServices : IActorServices
    {

        public readonly AppDbContext _context;

        public ActorServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
           await _context.Actor.AddAsync(actor);
           await _context.SaveChangesAsync(); 
        }

        public async Task<Actor> Bygetid(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(n=> n.Id == id);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actor.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<Actor>> GetAll()
        {
            var allactor = await  _context.Actor.ToListAsync();
            return allactor;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {

            _context.Update(newActor);
           await  _context.SaveChangesAsync();
            return newActor;

        }
    }
}
