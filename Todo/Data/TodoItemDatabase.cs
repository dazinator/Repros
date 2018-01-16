using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xamarin.Standard.Hosting;

namespace Todo
{
    // Changes below by @cwrea for adaptation to EF Core.
    public class TodoItemDatabase : DbContext
    {
        private readonly IHostingEnvironment _env;

        public TodoItemDatabase(IHostingEnvironment env) : base()
        {
            _env = env;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Server> Servers { get; set; }


        public async Task<List<TodoItem>> GetItemsAsync()
        {
            return await TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return await TodoItems.Where(item => item.Done).ToListAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await TodoItems.SingleAsync(item => item.ID == id);
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID == 0)
            {
                await TodoItems.AddAsync(item);
            }
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            TodoItems.Remove(item);
            return await SaveChangesAsync();
        }

        #region Private implementation            

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "TodoSQLite.db";
            var path = System.IO.Path.Combine(_env.ContentRootPath, dbName);          
            optionsBuilder.UseSqlite($"Filename={path};");
            //optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        #endregion
    }
}
