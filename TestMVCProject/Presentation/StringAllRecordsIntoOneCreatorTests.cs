using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using NuGet.ProjectModel;
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
            Item item = new Item();
            IStringRecordOutCreator creator = new StringRecordOutCreator();

            var result = creator.Create(item);

            Assert.That(result, Is.EqualTo(Guid.Empty.ToString().PadRight(45, '\u00A0') + item.Name + "\n"));
        }

        [Test]
        public void Create_CreateStringFrom1Record()
        {
            Item item = new Item();
            item.Id = Guid.NewGuid();
            item.Name = "Name";

            IStringRecordOutCreator creator = new StringRecordOutCreator();

            var result = creator.Create(item);

            Assert.That(result, Is.EqualTo(item.Id.ToString().PadRight(45, '\u00A0') + item.Name + "\n"));
        }
    }
}
