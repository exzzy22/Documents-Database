using Services.Service.IService;
using EFCoreModels;
using AutoMapper;
using System.Linq;

namespace Services.Service
{
    public class ItemService : IItemService
    {
        private readonly BillsContext _db;
        private readonly IMapper _mapper;

        public ItemService(BillsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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

        public IEnumerable<ItemDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
