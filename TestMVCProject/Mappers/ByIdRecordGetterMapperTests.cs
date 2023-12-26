using MVCPractice.Mappers;
using MVCPractice.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Mappers
{
    public class ByIdRecordGetterMapperTests
    {
        [Test]
        public void Map_successfullyMapStringToGuid()
        {
            Guid idAsGuid = Guid.NewGuid();

            var idAsString = idAsGuid.ToString();

            IByIdRecordGetterMapper byIdRecordGetterMapper = new ByIdRecordGetterMapper();

            var result = byIdRecordGetterMapper.Map(idAsString);

            Assert.That(result, Is.EqualTo(idAsGuid));
        }

        [Test]
        public void Map_guidNotInStringFormat()
        {
            var idAsString = "1";

            IByIdRecordGetterMapper byIdRecordGetterMapper = new ByIdRecordGetterMapper();

            var ex = Assert.Throws<ArgumentException>(() => byIdRecordGetterMapper.Map(idAsString));

            Assert.That(ex.Message, Is.EqualTo("id is not a guid in string format"));
        }
    }
}
