namespace Models
{
    public class Post
    {

        /// <summary>
        /// Post's Id
        /// </summary>
        /// <value>Post's Id</value> 
        public int id { get; set; }
        /// <summary>
        /// Entry, like the actual entry of the post
        /// </summary>
        /// <value>Entry/value>
        public string entry { get; set; } = "";
        /// <summary>
        /// User's Id
        /// </summary>
        /// <value>User's Id</value> 
        public int userId { get; set; }
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
        /// <summary>
        /// Band's Id
        /// </summary>
        /// <value>Band's Id</value> 
        public int bandId { get; set; }
        /// <summary>
        /// Type of Post, True for x, False for y
        /// </summary>
        /// <value>Type of Post</value>
        public string type { get; set; } = "";
        ///<summary>
        ///Holds comments tied to the post
        ///</summary>
        /// <value>List of comments</value>
        public List<Comment> postComments {get; set;}
        ///<summary>
        ///Shows comments on homepage
        ///</summary>
        /// <value>List of comments</value>
        public bool showComments {get; set;}
        }
}

/*
    int id
    string dataentry? tf is this
    int userid?
    int likes
    date datecreated
    int bandid 
    Boolean type (use bool for it or maybe int for id type)  
    ~leo
*/