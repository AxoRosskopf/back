using DTOs;
using Entities;

namespace Mappers
{
    public class ItemMapper
    {
        public static ItemDTO ToDTO(Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Image = item.Image,
                Status = item.Status,
                Stock = item.Stock,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };

        }

        public static Item ToEntity(ItemDTO itemDTO)
        {
            return new Item
            {
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Image = itemDTO.Image,
                Status = itemDTO.Status,
                Stock = itemDTO.Stock,
                CreatedAt = itemDTO.CreatedAt,
                UpdatedAt = itemDTO.UpdatedAt,
            };
        }

        public static IEnumerable<ItemDTO> ToDTOList(IEnumerable<Item> items)
        {
            return items.Select(ToDTO);
        }

        public static IEnumerable<Item> ToEntityList(IEnumerable<ItemDTO> itemDTOs)
        {
            return itemDTOs.Select(ToEntity);
        }
    }
}
