using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/item
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemRepository.GetItemsAsync();
            return Ok(items);
        }

        // GET: api/item/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/item
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var createdItem = await _itemRepository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/item/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] Item item)
        {
            if (item == null || id != item.Id)
            {
                return BadRequest();
            }

            var updateItem = await _itemRepository.UpdateItemAsync(id, item);
            if (updateItem == null)
            {
                return NotFound();
            }
            return Ok(updateItem);
        }

        //DELETE: api/item/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItem(Guid id) 
        {
            var result = await _itemRepository.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
