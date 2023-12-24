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
        public void TestValidate_validId()
        {
            string id = "1";

            ByIdRecordGetterValidator byIdRecordGetterValidator = new ByIdRecordGetterValidator();

            var result = byIdRecordGetterValidator.Validate(id);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestValidate_idNotNumber()
        {
            string id = "a";

            ByIdRecordGetterValidator byIdRecordGetterValidator = new ByIdRecordGetterValidator();

            var result = byIdRecordGetterValidator.Validate(id);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
