using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Presentation
{
    public class StringAllRecordsIntoOneCreatorTests
    {
        [Test]
        public void Create_CreateStringFromNoRecords()
        {
            IList<Item> records = new List<Item>();
            IStringAllRecordsIntoOneCreator creator = new StringAllRecordsIntoOneCreator();

            var result = creator.Create(records);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Create_CreateStringFrom1Record()
        {
            Item item = new Item();
            item.Id = Guid.NewGuid();
            item.Name = "Name";

            IList<Item> records = new List<Item>
            {
                item
            };

            IStringAllRecordsIntoOneCreator creator = new StringAllRecordsIntoOneCreator();

            var result = creator.Create(records);

            Assert.That(result, Is.EqualTo(records[0].Id.ToString().PadRight(45, '\u00A0') + records[0].Name + "\n"));
        }

        [Test]
        public void Create_CreateStringFrom2Records()
        {
            Item item1 = new Item();
            item1.Id = Guid.NewGuid();
            item1.Name = "Name";

            Item item2 = new Item();
            item2.Id = Guid.NewGuid();
            item2.Name = "test";

            IList<Item> records = new List<Item>
            {
                item1, item2
            };

            IStringAllRecordsIntoOneCreator creator = new StringAllRecordsIntoOneCreator();

            var result = creator.Create(records);

            Assert.That(result, Is.EqualTo(records[0].Id.ToString().PadRight(45, '\u00A0') + records[0].Name + "\n" + records[1].Id.ToString().PadRight(45, '\u00A0') + records[1].Name + "\n"));
        }
    }
}
