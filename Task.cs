using System.Text.Json.Serialization;

namespace task_manager;

public class Task
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    public override string ToString()
    {
        return $"{Id}, Name: {Name}, Status: {Status}";
    }
}