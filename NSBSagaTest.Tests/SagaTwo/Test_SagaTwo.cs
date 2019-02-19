using NSBSagaTest.FolderTwo;
using NServiceBus.Testing;
using Xunit;

namespace NSBSagaTest.Tests.SagaTwo
{
    public class Test_SagaTwo
    {
        [Fact]
        public void Saga_should_be_completed()
        {
            var message = new StartSagaTwo(1);

            Test.Saga<MySagaTwo>()
                .ExpectSagaCompleted()
                .WhenHandling(message);
        }
    }
}