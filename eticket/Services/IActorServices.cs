using Eticket.Models;

namespace Eticket.Services
{
    public interface IActorServices
    {
       Task<IEnumerable<Actor>> GetAll();

        Task<Actor> Bygetid(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id ,Actor newActor);
        Task DeleteAsync(int id);    
    }
}
