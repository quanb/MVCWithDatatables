namespace MVCWithDatatables.Models.DataTables
{
    public class Search
    {
        public Search(string value, bool regex)
        {
            this.Value = value;
            this.Regex = regex;
        }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// True if the global filter should be treated as a regular expression for advanced searching, false otherwise
        /// </summary>
        public bool Regex { get; set; }
    }
}