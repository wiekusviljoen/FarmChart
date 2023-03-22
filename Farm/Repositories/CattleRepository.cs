using Farm.Data;
using Farm.Interfaces;
using Farm.Models;

namespace Farm.Repositories
{
    public class CattleRepository : ICattleRepository
    {

        private readonly FarmContext _context;

        public CattleRepository(FarmContext context)
        {
            _context = context;
        }

        public void Insert(Cattle cattle)
        {
            _context.Cattle.Add(cattle);
        }



        public Cattle GetById(int id)
        {
            return _context.Cattle.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Delete(Cattle cattle)
        {
            _context.Cattle.Remove(cattle);
        }

        public Cattle DeleteById(Cattle cattle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cattle> GetAll()
        {
            return _context.Cattle.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Cattle cattle)
        {
            _context.Cattle.Update(cattle);
        }

    }
}
