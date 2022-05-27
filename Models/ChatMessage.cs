namespace Models;

public class ChatMessage
{
    public string uniqueId {get; set;}
    public string username {get; set;}
    public string type {get; set;}
    public string message {get; set;}
    public DateTime dateCreated {get; set;}
}