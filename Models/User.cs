namespace Models
{
    public class User
    {
    /// <summary>
    /// User's Id
    /// </summary>
    /// <value>Comment's Id</value>
    public int id { get; set; }
    /// <summary>
    /// Username
    /// </summary>
    /// <value>Username/value>
    public string username { get; set; } = "";
    /// <summary>
    /// Password
    /// </summary>
    /// <value>Password/value>
    public string password { get; set; } = "";
    /// <summary>
    /// First Name
    /// </summary>
    /// <value>First Name/value>
    public string firstname { get; set; } = "";
    /// <summary>
    /// Last Name
    /// </summary>
    /// <value>Last Name/value>
    public string lastname { get; set; } = "";
    /// <summary>
    /// Email
    /// </summary>
    /// <value>Email/value>
    public string email { get; set; } = "";
    /// <summary>
    /// User Bio
    /// </summary>
    /// <value>User Bio/value>
    public string bio { get; set; } = "";
    }
}

/*
    int id
    string username
    string password
    string firstname
    string lastname
    string email
    string bio
*/