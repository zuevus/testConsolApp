using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void Task();
    public delegate void TaskProgress();

    internal class TaskManager
    {

        private Queue<Task> Queue { get; set; } = new Queue<Task>();
        public void AddTask(Task task) => Queue.Enqueue(task);
        List<Thread> threads = new List<Thread>();
        public TaskManager() { }
        public void RunTasks()
        {
            if (Queue.Count == 0) return;
            Task? task;
            while (Queue.Count > 0)
            {
                task = Queue.Dequeue();
                threads.Add(new Thread(task.Invoke));
                threads.Last().Start();
            }
        }
        public void RunNextTask()
        {
            if (Queue.Count == 0) return;
            var task = Queue.Dequeue();
            threads.Add(new Thread(task.Invoke));
            threads.Last().Start();
        }
        public void Awaiter()
        {
            Console.WriteLine("We are waiting for threads");
            while (threads.Any(t => t.IsAlive))
                {
                Console.Write(".");
                }
        }
    }
}
