using Interfaces;
using DTOs;
using Repositories;
using Entities;
using Mappers;

namespace Services
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemRepository _itemRepository;

        public ItemAppService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentException(nameof(itemRepository));
        }

        public async Task<List<ItemDTO>> GetItemsAsync()
        {
            List<Item> items = await _itemRepository.GetItemsAsync();
            return ItemMapper.ToDTOList(items).ToList();
        }

        public async Task<ItemDTO?> GetItemByIdAsync(Guid id)
        {
            Item item = await _itemRepository.GetItemByIdAsync(id);
            return ItemMapper.ToDTO(item);
        }

        public async Task<ItemDTO> CreateItemAsync(ItemDTO itemDTO)
        {
            Item itemEntity = ItemMapper.ToEntity(itemDTO);
            Item itemCreated = await _itemRepository.CreateItemAsync(itemEntity);
            return ItemMapper.ToDTO(itemCreated);
        }

        public async Task<ItemDTO?> UpdateItemAsync(Guid id, ItemDTO itemDto)
        {
            Item itemEntity = ItemMapper.ToEntity(itemDto);
            Item itemUpdated = await _itemRepository.UpdateItemAsync(id, itemEntity);
            return ItemMapper.ToDTO(itemUpdated);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            bool result = await _itemRepository.DeleteItemAsync(id);
            return result;
        }
    }
}
