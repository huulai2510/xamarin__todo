using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Todo.Models;

namespace Todo.Data
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GettodosAsync()
        {
            //Get all todos.
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<TodoItem> GetTodoAsync(int id)
        {
            // Get a specific todo.
            return database.Table<TodoItem>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTodoAsync(TodoItem todo)
        {
            if (todo.ID != 0)
            {
                // Update an existing todo.
                return database.UpdateAsync(todo);
            }
            else
            {
                // Save a new todo.
                return database.InsertAsync(todo);
            }
        }

        public Task<int> DeleteTodoAsync(TodoItem todo)
        {
            // Delete a todo.
            return database.DeleteAsync(todo);
        }
    }
}