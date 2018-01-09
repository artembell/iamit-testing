using Xunit;

namespace IamIT.Tests.UI
{
    public class Home : Base
    {
        [Fact]
        public void TestHome() {
            Driver.FindElementsById("courseItem");
            Driver.FindElementById("tagsContainer");
        }
    }
}