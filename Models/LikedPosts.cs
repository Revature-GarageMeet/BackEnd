using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    
    public class LikedPosts
    {
        
        /// <summary>
        /// User's Id
        /// </summary>
        /// <value>User's Id</value>
        
        public int userid { get; set; }

        /// <summary>
        ///  Post ID that the user has liked
        /// </summary>
        /// <value>Post's ID</value>
        public int postid { get; set; }
        /// <summary>
        /// The column's ID for the liked post in relation to the user
        /// </summary>
        /// <value></value>
        public int id{get; set;}
    }
}