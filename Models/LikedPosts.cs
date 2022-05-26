using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class LikedPosts
    {
        /// <summary>
        /// User's Id
        /// </summary>
        /// <value>User's Id</value>
        [Key]        
        public int userid { get; set; }

        /// <summary>
        ///  Post ID that the user has liked
        /// </summary>
        /// <value>Post's ID</value>
        public int postid { get; set; }


    }
}