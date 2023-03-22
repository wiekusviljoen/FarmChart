using Farm.Data;
using Farm.Interfaces;
using Farm.Models;

namespace Farm.Repositories
{
    public class RainRepository : IRainRepository
    {
        private readonly FarmContext _context;

        public RainRepository(FarmContext context)
        {
            _context = context;
        }

        public void Insert(RainModel rainModel)
        {
            _context.RainModel.Add(rainModel);
        }



        public RainModel GetById(int id)
        {
            return _context.RainModel.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Delete(RainModel rainModel)
        {
            _context.RainModel.Remove(rainModel);
        }

        public RainModel DeleteById(RainModel rainModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RainModel> GetAll()
        {
            return _context.RainModel.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RainModel rainModel)
        {
            _context.RainModel.Update(rainModel);
        }
    }
}
