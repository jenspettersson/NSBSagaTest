using NSBSagaTest.FolderTwo;
using NServiceBus.Testing;
using NUnit.Framework;

namespace NSBSagaTest.NUnit.Tests.SagaTwo
{
    [TestFixture]
    public class Another_Test_for_SagaTwo
    {
        [Test]
        public void Saga_should_be_completed()
        {
            var message = new StartSagaTwo(1);

            Test.Saga<MySagaTwo>()
                .ExpectSagaCompleted()
                .WhenHandling(message);
        }
    }
}