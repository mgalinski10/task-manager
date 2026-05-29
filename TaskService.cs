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
        var jsonStringTasks = File.ReadAllText(DATABASE_URL);
        var parsedTasks = JsonSerializer.Deserialize<List<Task>>(jsonStringTasks);
        
        var newId = new Random().Next();
        var newTask = new Task(newId, name, false);
        parsedTasks.Add(newTask);

        var serializedTasks = JsonSerializer.Serialize(parsedTasks);
        File.WriteAllText(DATABASE_URL, serializedTasks);
        
        return newTask;
    }

    public static void DeleteTask(int id)
    {
        var jsonStringTasks = File.ReadAllText(DATABASE_URL);
        var parsedTasks = JsonSerializer.Deserialize<List<Task>>(jsonStringTasks);

        parsedTasks.RemoveAll(task => task.Id.Equals(id));

        var serializedTasks = JsonSerializer.Serialize(parsedTasks);
        File.WriteAllText(DATABASE_URL, serializedTasks);
    }

    public static void ToggleTaskStatus(int id)
    {
        var jsonStringTasks = File.ReadAllText(DATABASE_URL);
        var parsedTasks = JsonSerializer.Deserialize<List<Task>>(jsonStringTasks); // duplicated code (above also).

        var task = parsedTasks.FirstOrDefault(task => task.Id.Equals(id)); // learn about references!!!!
        task?.Status = !task.Status;
        
        var serializedTasks = JsonSerializer.Serialize(parsedTasks); // think it's not necessary if we modify real object - and not a copy.
        File.WriteAllText(DATABASE_URL, serializedTasks);
    }
}