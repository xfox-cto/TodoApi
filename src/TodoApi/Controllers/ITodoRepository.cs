using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);

        IEnumerable<TodoItem> GetAll();

        TodoItem Find(string key);

        void Update(TodoItem item);

        TodoItem Remove(string key);

    }
}
