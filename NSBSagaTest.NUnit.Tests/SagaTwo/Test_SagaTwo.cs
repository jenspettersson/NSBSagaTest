using NSBSagaTest.FolderTwo;
using NUnit.Framework;
using Test = NServiceBus.Testing.Test;

namespace NSBSagaTest.NUnit.Tests.SagaTwo
{
    [TestFixture]
    public class Test_SagaTwo
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