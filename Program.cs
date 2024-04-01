// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
class Program
{
    private static TaskManager taskManager = new TaskManager();
    private static void Main(string[] args)
    {
        //Issue 1 about async class
        ConsoleApp1.Task task = () =>
        {
            Thread.Sleep(500); Console.WriteLine("some text1");
        };
        taskManager.AddTask(task);
        ConsoleApp1.Task task1 = () => Console.WriteLine("some text2");
        taskManager.AddTask(task1);
        ConsoleApp1.Task task2 = () =>
        {
            Thread.Sleep(500); Console.WriteLine("some text3");
        };
        taskManager.AddTask(task2);
        ConsoleApp1.Task task3 = () => Console.WriteLine("some text4");
        taskManager.AddTask(task3);
        Console.WriteLine("Run one");
        taskManager.RunNextTask();
        taskManager.Awaiter();
        Console.WriteLine("Run all");
        taskManager.RunTasks();

        //Issue 2 about partly sum series of numbers
        double[] a = [1, 2, 3, 4];
        Console.WriteLine(new PartlySeriesOfNumbers(a));
        var partlySeriesOfNumbers = new PartlySeriesOfNumbers();
        Console.WriteLine(String.Join(",", partlySeriesOfNumbers.GetRowSums(a)));
    }
}
