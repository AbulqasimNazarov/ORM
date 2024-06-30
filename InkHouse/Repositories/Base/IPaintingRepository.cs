using InkHouse.Models;

namespace InkHouse.Repositories.Base;

public interface IPaintingRepository : IGetAsync<Painting>, IDeleteAsync, ICreateAsync<Painting>, IChangeAsync<Painting>
{
        
}
