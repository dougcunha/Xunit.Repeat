namespace Xunit.Repeat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Xunit.Sdk;

    /// <summary>
    ///     Says xUnit to run the test for a specific number of times.
    /// </summary>
    public sealed class RepeatAttribute : DataAttribute
    {
        private readonly int _count;

        public RepeatAttribute(int count)
        {
            const int MINIMUM_COUNT = 1;
            if (count < MINIMUM_COUNT)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(count),
                    message: "Repeat count must be greater than 0."
                    );
            }
            _count = count;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return Enumerable.Range(start: 1, count: _count).Select(iterationNumber => new object[] { iterationNumber });
        }
    }
}
