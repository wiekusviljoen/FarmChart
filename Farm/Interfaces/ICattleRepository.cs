using Farm.Models;

namespace Farm.Interfaces
{
    public interface ICattleRepository
    {
        IEnumerable<Cattle> GetAll();

        Cattle GetById(int id);

        void Insert(Cattle cattle);

        void Update(Cattle cattle);

        void Delete(Cattle cattle);

        void Save();

    }
}
