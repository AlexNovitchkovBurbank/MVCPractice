using MVCPractice.Processors;
using MVCPractice.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCPractice.Utilities
{
    public class UserIdGetterTests
    {
        [Test]
        public void GetUserIdFromPath_pathValid()
        {
            string path = "something/1";

            string userId = "1";

            UserIdGetter userIdGetter = new UserIdGetter();

            var result = userIdGetter.GetUserIdFromPayload(path);

            Assert.That(result, Is.EqualTo(userId));
        }

        [Test]
        public void GetUserIdFromPath_pathNull()
        {
            string path = null;

            UserIdGetter userIdGetter = new UserIdGetter();

            var ex = Assert.Throws<Exception>(() => userIdGetter.GetUserIdFromPayload(path));

            Assert.That(ex.Message, Is.EqualTo("could not parse lookup userId from the path"));
        }

        [Test]
        public void GetUserIdFromPath_pathEmpty()
        {
            string path = "";

            UserIdGetter userIdGetter = new UserIdGetter();

            var ex = Assert.Throws<Exception>(() => userIdGetter.GetUserIdFromPayload(path));

            Assert.That(ex.Message, Is.EqualTo("could not parse lookup userId from the path"));
        }
    }
}
