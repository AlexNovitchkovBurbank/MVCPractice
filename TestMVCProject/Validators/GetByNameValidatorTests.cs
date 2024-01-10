using MVCPractice.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Validators
{
    public class GetByNameValidatorTests
    {
        [Test]
        public void Validate_validId()
        {
            string idAsString = "35147448-DC42-4ADB-8B17-08DC050D8DF9";

            ByIdRecordGetterValidator byIdRecordGetterValidator = new ByIdRecordGetterValidator();

            var result = byIdRecordGetterValidator.Validate(idAsString);

            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Message, Is.EqualTo(""));
        }

        [Test]
        public void Validate_idNotGuid()
        {
            string idAsString = "1";

            ByIdRecordGetterValidator byIdRecordGetterValidator = new ByIdRecordGetterValidator();

            var result = byIdRecordGetterValidator.Validate(idAsString);

            Assert.That(result.Valid, Is.EqualTo(false));
            Assert.That(result.Message, Is.EqualTo("id is not a guid"));
        }
    }
}
