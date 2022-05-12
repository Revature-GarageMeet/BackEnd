namespace Models
{
    public class Band
    {
        /// <summary>
        /// Band's ID
        /// </summary>
        /// <value>Band's Id</value>
        public int id { get; set; }

        /// <summary>
        /// Band's Title
        /// </summary>
        /// <value>Band's Title</value>
        public string title {get; set;} = "";

        /// <summary>
        /// Band's Description
        /// </summary>
        /// <value>Band's Description</value>
        public string description {get;set;} = "";
        /// <summary>
        /// Max number of Members in Band
        /// </summary>
        /// <value>Max number of Members in Band</value>
        public int memberLimit { get; set; }
    }
}

/*
    int id
    string title
    string description
    int memberLimit
*/