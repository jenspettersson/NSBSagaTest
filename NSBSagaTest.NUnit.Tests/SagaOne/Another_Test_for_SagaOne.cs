using NSBSagaTest.FolderOne;
using NServiceBus.Testing;
using NUnit.Framework;

namespace NSBSagaTest.NUnit.Tests.SagaOne
{
    [TestFixture]
    public class Another_Test_for_SagaOne
    {
        [Test]
        public void Saga_should_be_completed()
        {
            var message = new StartSagaOne(1);

            Test.Saga<MySagaOne>()
                .ExpectSagaCompleted()
                .WhenHandling(message);
        }
    }
}
