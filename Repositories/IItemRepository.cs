using Entities;

namespace Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsAsync();
        Task<Item?> GetItemByIdAsync(Guid id);
        Task<Item> CreateItemAsync(Item item);
        Task<Item?> UpdateItemAsync(Guid id, Item item);
        Task<bool> DeleteItemAsync(Guid id);

    }
}
