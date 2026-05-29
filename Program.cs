using task_manager;
using Task = task_manager.Task;

class Program
{
    
    static void Main(string[] args)
    {
        // TaskService.GetAllTasks();

        // TaskService.AddNewTask("Testowy task");
        
        TaskService.DeleteTask(6);
        TaskService.DeleteTask(5);
        TaskService.DeleteTask(4);
        TaskService.DeleteTask(3);
    }
}