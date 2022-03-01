using EFCoreModels;

namespace Services.Service.IService
{
    public interface IItemService
    {
        public IEnumerable<ItemDTO> GetAll();
        public int Add(Item item);
        public int Delete(Item item);
    }
}
