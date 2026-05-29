using System.Text.Json;

namespace task_manager;

public static class TaskService
{
    private static string DATABASE_URL = "/home/michal/Private/task-manager/db.json";
    private static char[] CHARS_TO_TRIM = { ' ', ',' };

    public static List<Task> GetAllTasks()
    {
        var jsonStringTasks = File.ReadAllLines(DATABASE_URL);

        var result = jsonStringTasks.Where(line => !IsFirstOrLastLine(line)).Select(line => line.Trim(CHARS_TO_TRIM))
            .Select(line => JsonSerializer.Deserialize<Task>(line)).ToList();
        
        return result;
    }

    private static bool IsFirstOrLastLine(string line)
    {
        return line.Equals("[") || line.Equals("]");
    }
}