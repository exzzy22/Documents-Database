namespace Services.Service.IService
{
    public interface IItemService
    {
        public IEnumerable<ItemDTO> GetAll();
    }
}
