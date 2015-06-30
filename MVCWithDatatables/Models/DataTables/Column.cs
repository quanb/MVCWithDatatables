namespace MVCWithDatatables.Models.DataTables
{
    public class Column
    {
        public Column(string data, string name, bool searchable, bool orderable, Search search)
        {
            this.Data = data;
            this.Name = name;
            this.Searchable = searchable;
            this.Orderable = orderable;
            this.Search = search;
        }

        /// <summary>
        /// Column's data source
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Column's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag to indicate if this column is searchable or not
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Flag to indicate if this column is orderable or not
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Search value to apply to this specific column
        /// </summary>
        public Search Search { get; set; }
    }
}