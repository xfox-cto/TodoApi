using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApi.Controllers;
using TodoApi.Models;

namespace TodoApi.Test
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
            ITodoRepository repository = new TodoRepository();
            var len = repository.GetAll().ToArray().Length;
            Assert.AreEqual(1, len);
        }

        [TestMethod]
        public void Find()
        {
            ITodoRepository repository = new TodoRepository();
            var item = repository.Find("1");
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Add()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(new TodoItem()
            {
                Name = "Test",
                IsComplete = true,
            });

            var len = repository.GetAll().ToArray().Length;
            Assert.AreEqual(2, len);
        }

        
    }
}
