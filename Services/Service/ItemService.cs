using EFCoreModels;
using Microsoft.EntityFrameworkCore;

namespace Services.Service
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> GetAll();
        public Task<int> Add(Item item);
        public Task<int> Delete(Item item);
    }
    public class ItemService : IItemService
    {
        private readonly BillsContext _db;

        public ItemService(BillsContext db)
        {
            _db = db;
        }
        public async Task<int> Add(Item item)
        {
            _db.Items.Add(item);
            return  await _db.SaveChangesAsync();

        }
        public async Task<int> Delete(Item item)
        {
            _db.Items.Remove(item);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _db.Items.ToListAsync();
        }
    }
}
