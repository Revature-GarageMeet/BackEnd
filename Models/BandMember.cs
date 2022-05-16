namespace Models
{
    public class BandMember
    {
        /// <summary>
        /// Band Member's Id
        /// </summary>
        /// <value>Band Member's Id</value> 
        public int id { get; set; }

        /// <summary>
        /// User's Id
        /// </summary>
        /// <value>User's Id</value>
        public int userId { get; set; }

        /// <summary>
        /// Band's ID
        /// </summary>
        /// <value>Band's Id</value>
        public int bandId { get; set; }

        /// <summary>
        /// Date User joined the Band
        /// </summary>
        /// <value>Date User joined the Band</value>
        public DateTime dateJoined { get; set; }

    }
}

/*
    int id
    user id
    band id
    date datejoined
    ~Leo
*/