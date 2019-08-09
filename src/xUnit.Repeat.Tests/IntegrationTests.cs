namespace Xunit.Repeat.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Priority;

    [TestCaseOrderer(ordererTypeName: PriorityOrderer.Name, ordererAssemblyName: PriorityOrderer.Assembly)]
    public class IntegrationTests
    {
        private const int REPEAT_COUNT = 10;
        private static int _counter;

        [Theory(DisplayName = "It should repeat the test"), Priority(1)]
        [Repeat(REPEAT_COUNT)]
        public void It_Should_Repeat_The_Test(int interationNumber)
        {
            interationNumber.Should().BeGreaterOrEqualTo(0);
            ++_counter;
        }

        [Fact(DisplayName = "It should have repeated the test"), Priority(2)]
        public void It_Should_Have_Repeated_The_Test()
        {
            _counter
                .Should()
                .Be(REPEAT_COUNT);
        }
    }
}
