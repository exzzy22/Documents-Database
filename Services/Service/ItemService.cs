using EFCoreModels;

namespace Services.Service
{
    public interface IItemService
    {
        public IEnumerable<Item> GetAll();
        public int Add(Item item);
        public int Delete(Item item);
    }
    public class ItemService : IItemService
    {
        private readonly BillsContext _db;

        public ItemService(BillsContext db)
        {
            _db = db;
        }

        public int Add(Item item)
        {
            _db.Items.Add(item);
            return  _db.SaveChanges();

        }
        public int Delete(Item item)
        {
            _db.Items.Remove(item);
            return _db.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            return _db.Items.ToList();
        }
    }
}
