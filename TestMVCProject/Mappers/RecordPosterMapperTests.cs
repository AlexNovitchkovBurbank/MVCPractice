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
            string name = "Alex";
            Guid id = Guid.NewGuid();

            IRecordPosterMapper recordPosterMapper = new RecordPosterMapper();

            var result = recordPosterMapper.Map(id, name);

            Assert.That(id, Is.EqualTo(result.Id));
            Assert.That(name, Is.EqualTo(result.Name));
        }
    }
}
