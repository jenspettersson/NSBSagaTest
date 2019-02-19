using System;
using System.Threading.Tasks;
using NServiceBus;

namespace NSBSagaTest.FolderOne
{
    public class MySagaOne : 
        Saga<MySagaOneData>, 
        IAmStartedByMessages<StartSagaOne>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MySagaOneData> mapper)
        {
            mapper.ConfigureMapping<StartSagaOne>(m => m.Id).ToSaga(s => s.MessageId);
        }

        public async Task Handle(StartSagaOne message, IMessageHandlerContext context)
        {
            var worker = new Worker();
            await worker.DoWork(1000);

            MarkAsComplete();
        }
    }

    public class StartSagaOne : ICommand
    {
        public int Id { get; }

        public StartSagaOne(int id)
        {
            Id = id;
        }
    }

    public class MySagaOneData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        public int MessageId { get; set; }
    }
}