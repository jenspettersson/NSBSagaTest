using System.Threading.Tasks;

namespace NSBSagaTest
{
    public class Worker
    {
        public Task DoWork(int forHowLong)
        {
            return Task.Delay(forHowLong);
        }
    }
}