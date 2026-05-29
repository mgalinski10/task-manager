using System.Text.Json;

namespace task_manager;

public static class TaskService
{
    private static string DATABASE_URL = "/home/michal/Private/task-manager/db.json";

    public static List<Task> GetAllTasks()
    {
        var jsonStringTasks = File.ReadAllText(DATABASE_URL);
        var result = JsonSerializer.Deserialize<List<Task>>(jsonStringTasks);

        return result;
    }

    public static Task AddNewTask(string name)
    {
        var newId = new Random().Next();
        var newTask = new Task(newId, name, false);

        return newTask;
    }
}