using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoRepository : ITodoRepository
    {
        private static int IdCreator = 0;

        private ConcurrentDictionary<string, TodoItem> _items = new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem()
            {
                Name = "Test",
                IsComplete = false,
            });
        }

        private string NewId()
        {
            IdCreator++;
            return IdCreator.ToString();
        }

        public void Add(TodoItem item)
        {
            item.Key = NewId();
            _items[item.Key] = item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _items.Values;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _items.TryGetValue(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _items[item.Key] = item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _items.TryRemove(key, out item);
            return item;
        }
    }
}