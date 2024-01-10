using MVCPractice.Controllers;
using MVCPractice.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Validators
{
    public class RecordPosterValidatorTests
    {
        [Test]
        public void Validate_namePresent()
        {
            string name = "Alex";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Message, Is.EqualTo(""));
        }

        [Test]
        public void Validate_nameNull()
        {
            string name = null;
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }

        [Test]
        public void Validate_nameEmpty()
        {
            string name = "";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }

        [Test]
        public void Validate_nameOnlySpaces()
        {
            string name = " ";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }
    }
}
