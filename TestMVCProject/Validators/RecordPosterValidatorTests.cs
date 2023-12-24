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
        public void TestValidate_namePresent()
        {
            string name = "Alex";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestValidate_nameNull()
        {
            string name = null;
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestValidate_nameEmpty()
        {
            string name = "";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestValidate_nameOnlySpaces()
        {
            string name = " ";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestValidate_nameFirstCharacterNotString()
        {
            string name = "7";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestValidate_nameSecondCharacterNotString()
        {
            string name = "a7";
            IRecordPosterValidator recordPosterValidator = new RecordPosterValidator();

            var result = recordPosterValidator.Validate(name);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
