using System;
using System.Threading.Tasks;
using NServiceBus;

namespace NSBSagaTest.FolderTwo
{
    public class MySagaTwo :
        Saga<MySagaTwoData>,
        IAmStartedByMessages<StartSagaTwo>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MySagaTwoData> mapper)
        {
            mapper.ConfigureMapping<StartSagaTwo>(m => m.Id).ToSaga(s => s.MessageId);
        }

        public async Task Handle(StartSagaTwo message, IMessageHandlerContext context)
        {
            var worker = new Worker();
            await worker.DoWork(1500);

            MarkAsComplete();
        }
    }

    public class StartSagaTwo : ICommand
    {
        public int Id { get; }

        public StartSagaTwo(int id)
        {
            Id = id;
        }
    }

    public class MySagaTwoData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        public int MessageId { get; set; }
    }
}
