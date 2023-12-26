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

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Validate_nameNull()
        {
            string name = null;
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Validate_nameEmpty()
        {
            string name = "";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Validate_nameOnlySpaces()
        {
            string name = " ";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Validate_nameFirstCharacterNotString()
        {
            string name = "7";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Validate_nameSecondCharacterNotString()
        {
            string name = "a7";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
