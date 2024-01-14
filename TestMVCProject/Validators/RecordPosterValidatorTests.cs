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
        public void ValidateName_namePresent()
        {
            string name = "Alex";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateName(name);

            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Message, Is.EqualTo(""));
        }

        [Test]
        public void ValidateName_nameNull()
        {
            string name = null;
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateName(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }

        [Test]
        public void ValidateName_nameEmpty()
        {
            string name = "";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateName(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }

        [Test]
        public void ValidateName_nameOnlySpaces()
        {
            string name = " ";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateName(name);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("name cannot be null or only have whitespace"));
        }

        [Test]
        public void ValidateName_idIsAGuid()
        {
            var id = Guid.NewGuid();
            var idAsString = id.ToString();

            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateId(idAsString);

            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Message, Is.EqualTo(""));
        }

        [Test]
        public void ValidateId_NotAGuid()
        {
            var id = "1";

            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.ValidateId(id);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("id must be a guid"));
        }
    }
}
