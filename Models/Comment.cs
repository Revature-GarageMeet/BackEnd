namespace Models;
public class Comment
{
    /// <summary>
    /// Comment's Id
    /// </summary>
    /// <value>Comment's Id</value>
    public int id { get; set; }
    /// <summary>
    /// User's Id
    /// </summary>
    /// <value>User's Id</value>
    public int userId { get; set; }
    /// <summary>
    /// Post's Id
    /// </summary>
    /// <value>Post's Id</value>
    public int postId { get; set; }
    /// <summary>
    /// Entry, like the actual entry of the comment
    /// </summary>
    /// <value>Entry/value>
    public string entry { get; set; } = "";

    /// <summary>
    /// Number of Likes
    /// </summary>
    /// <value>Number of Likes</value>
    public int likes { get; set; }
    /// <summary>
    /// Date User made the Post
    /// </summary>
    /// <value>Date User joined the Band</value>
    public DateTime dateCreated { get; set; }
}


/*
    int id
    int userid
    int postid
    string entry
    int likes
    DateTime dateCreated
*/