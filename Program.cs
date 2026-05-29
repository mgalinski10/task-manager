using task_manager;
using Task = task_manager.Task;

class Program
{
    
    static void Main(string[] args)
    {
        TaskService.GetAllTasks();

        TaskService.AddNewTask("Testowy task");
        
        TaskService.DeleteTask(2088704504);
        
        TaskService.ToggleTaskStatus(3);
    }
}