using NSBSagaTest.FolderOne;
using NServiceBus.Testing;
using Xunit;

namespace NSBSagaTest.Tests.SagaOne
{
    public class Test_SagaOne
    {
        [Fact]
        public void Saga_should_be_completed()
        {
            var message = new StartSagaOne(1);

            Test.Saga<MySagaOne>()
                .ExpectSagaCompleted()
                .WhenHandling(message);
        }
    }
}
