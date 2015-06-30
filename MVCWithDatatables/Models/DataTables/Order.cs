namespace MVCWithDatatables.Models.DataTables
{
    public class Order
    {
        public Order(int column, string dir)
        {
            this.Column = column;
            this.Dir = dir;
        }

        /// <summary>
        /// Index of column to which ordering should be applied
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Ordering direction for this column
        /// </summary>
        public string Dir { get; set; }

    }
}