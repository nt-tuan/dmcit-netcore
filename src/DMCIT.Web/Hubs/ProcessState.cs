using System.Collections.Generic;

namespace DMCIT.Web.Hubs
{
    public class ProcessState
    {
        //What your process
        public string Title { get; set; }
        //Whare are you doing
        public string Description { get; set; }
        public float Percent { get; set; }
        public int Error { get; set; }
        public Queue<string> Messages = new Queue<string>();
        readonly int MAX_MESSAGE_COUNT = 20;
        public void OnError(string error)
        {
            Messages.Enqueue(error);
            if (Messages.Count > MAX_MESSAGE_COUNT)
            {
                Messages.Dequeue();
            }
        }
    }
}
