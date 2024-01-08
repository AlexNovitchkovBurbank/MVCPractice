using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Utilities
{
    public class OnIdFiltererTests
    {
        [Test]
        public void Filter_NullList()
        {
            Guid id = Guid.NewGuid();

            IList<Item> records = null;

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var ex = Assert.Throws<ArgumentException>(() => onIdFilterer.Filter(records, id));

            Assert.That(ex.Message, Is.EqualTo("list of records cannot be null"));
        }

        [Test]
        public void Filter_0ElementsInList()
        {
            Guid id = Guid.NewGuid();

            IList<Item> records = new List<Item>();

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var result = onIdFilterer.Filter(records, id);

            Assert.IsInstanceOf(typeof(Item), result);

            Assert.That(result.Id, Is.EqualTo(Guid.Empty));
            Assert.That(result.Name, Is.SameAs(string.Empty));
        }

        [Test]
        public void Filter_1ElementInListAndIdInThere()
        {
            Guid id = Guid.NewGuid();

            Item item = new Item();
            item.Id = id;
            item.Name = "Test";

            IList<Item> items = new List<Item>
            {
                item
            };

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var result = onIdFilterer.Filter(items, id);

            Assert.IsInstanceOf(typeof(Item), result);

            Assert.That(result.Id, Is.EqualTo(item.Id));
            Assert.That(result.Name, Is.EqualTo(item.Name));
        }

        [Test]
        public void Filter_2ElementsDifferentIdsAndIdInThere()
        {
            Guid id = Guid.NewGuid();

            Item item1 = new Item();
            item1.Id = id;
            item1.Name = "Item1";

            Item item2 = new Item();
            item2.Id = Guid.NewGuid();
            item2.Name = "Item2";

            IList<Item> items = new List<Item>
            {
                item1, item2
            };

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var result = onIdFilterer.Filter(items, id);

            Assert.IsInstanceOf(typeof(Item), result);

            Assert.That(result.Id, Is.EqualTo(item1.Id));
            Assert.That(result.Name, Is.EqualTo(item1.Name));
        }

        [Test]
        public void Filter_1ElementInListAndIdNotInThere()
        {
            Guid id = Guid.NewGuid();

            Item item = new Item();
            item.Id = Guid.NewGuid();
            item.Name = "Test";

            IList<Item> records = new List<Item>
            {
                item
            };

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var result = onIdFilterer.Filter(records, id);

            Assert.IsInstanceOf(typeof(Item), result);

            Assert.That(result.Id, Is.EqualTo(Guid.Empty));
            Assert.That(result.Name, Is.SameAs(string.Empty));
        }

        [Test]
        public void Filter_2ElementsDifferentIdsAndIdNotInThere()
        {
            Guid id = Guid.NewGuid();

            Item item1 = new Item();
            item1.Id = Guid.NewGuid();
            item1.Name = "Item1";

            Item item2 = new Item();
            item2.Id = Guid.NewGuid();
            item2.Name = "Item2";

            IList<Item> records = new List<Item>
            {
                item1, item2
            };

            string emptyString = string.Empty;

            IOnIdFilterer onIdFilterer = new OnIdFilterer();

            var result = onIdFilterer.Filter(records, id);

            Assert.IsInstanceOf(typeof(Item), result);

            Assert.That(result.Id, Is.EqualTo(Guid.Empty));
            Assert.That(result.Name, Is.SameAs(string.Empty));
        }
    }
}
