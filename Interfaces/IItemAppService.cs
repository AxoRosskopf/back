using DTOs;

namespace Interfaces
{
    public interface IItemAppService
    {
        Task<List<ItemDTO>> GetItemsAsync();
        Task<ItemDTO?> GetItemByIdAsync(Guid id);
        Task<ItemDTO> CreateItemAsync(ItemDTO itemDto);
        Task<ItemDTO?> UpdateItemAsync(Guid id, ItemDTO itemDto);
        Task<bool> DeleteItemAsync(Guid id);
    }
}
