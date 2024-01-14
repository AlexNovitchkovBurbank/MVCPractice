using MVCPractice.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Utilities
{
    public class StringToGuidConverterTests
    {
        [Test]
        public void Convert_ShouldBeGuid()
        {
            IStringToGuidConverter converter = new StringToGuidConverter();

            var id = Guid.NewGuid();
            var idAsString = id.ToString();

            var actualGuid = converter.Convert(idAsString);

            Assert.That(actualGuid, Is.EqualTo(id));
        }

        [Test]
        public void Convert_ShouldNotBeGuid()
        {
            IStringToGuidConverter converter = new StringToGuidConverter();

            var idAsString = "1";

            var ex = Assert.Throws<ArgumentException>(() => converter.Convert(idAsString));

            Assert.That(ex.Message, Is.EqualTo("id string must be a guid"));
        }
    }
}
