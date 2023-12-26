using MVCPractice.Controllers;
using MVCPractice.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Mappers
{
    public class RecordPosterMapperTests
    {
        [Test]
        public void Map_Successful()
        {
            Guid id = Guid.NewGuid();
            string name = "Alex";

            IRecordPosterMapper recordPosterMapper = new RecordPosterMapper();

            var result = recordPosterMapper.Map(id, name);

            Assert.That(id, Is.EqualTo(result.Id));
            Assert.That(name, Is.EqualTo(result.Name));
        }

        [Test]
        public void Map_NameIsNull()
        {
            Guid id = Guid.NewGuid();
            string name = null;

            IRecordPosterMapper recordPosterMapper = new RecordPosterMapper();

            var ex = Assert.Throws<ArgumentException>(() => recordPosterMapper.Map(id, name));

            Assert.That(ex.Message, Is.EqualTo("name cannot be null"));
        }
    }
}
