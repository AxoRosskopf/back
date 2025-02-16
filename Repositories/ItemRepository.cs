using Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;
        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            return await _dbContext.Items
                .ToListAsync();
        }
        public async Task<Item> GetItemByIdAsync(Guid id)
        {
            return await _dbContext.Items
                .FirstOrDefaultAsync(i => i.Id == id) ?? throw new KeyNotFoundException();
        }
        public async Task<Item> CreateItemAsync(Item item)
        {
            Console.WriteLine(item);
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Item?> UpdateItemAsync(Guid id, Item item)
        {
            var existingItem = await _dbContext.Items.FindAsync(id);
            if (existingItem == null) return null;

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Image = item.Image;
            existingItem.Status = item.Status;
            existingItem.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return existingItem;
        }
        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var item = await _dbContext.Items.FindAsync(id);
            if (item == null) return false;

            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
