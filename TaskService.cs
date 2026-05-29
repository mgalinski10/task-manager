using System.Text.Json;

namespace task_manager;

public static class TaskService
{
    private static string DATABASE_URL = "/home/michal/Private/task-manager/db.json";
    private static char[] CHARS_TO_TRIM = { ' ', ',' };

    public static List<Task> GetAllTasks()
    {
        var jsonStringTasks = File.ReadAllLines(DATABASE_URL);
        var result = new List<Task>();
        
        foreach (var task in jsonStringTasks)
        {
            if (IsFirstOrLastLine(task))
            {
               continue;
            }
            
            var serializedTask = JsonSerializer.Deserialize<Task>(task.Trim(CHARS_TO_TRIM));
            result.Add(serializedTask); 
        }
    
        return result;
    }

    private static bool IsFirstOrLastLine(string line)
    {
        return line.Equals("[") || line.Equals("]");
    }
}