using Farm.Models;

namespace Farm.Interfaces
{
    public interface IRainRepository
    {
        IEnumerable<RainModel> GetAll();

        RainModel GetById(int id);

        void Insert(RainModel rainModel);

        void Update(RainModel rainModel);

        void Delete(RainModel rainModel);

        void Save();
    }
}
