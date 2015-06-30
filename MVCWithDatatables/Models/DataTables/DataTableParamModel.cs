using System.Collections.Generic;

namespace MVCWithDatatables.Models.DataTables
{
    public class DataTableParamModel
    {
        public DataTableParamModel()
        {
            Columns = new List<Column>();
            Order = new List<Order>();
        }

        /// <summary>
        /// Request sequence number sent by DataTable, same value must be returned in response
        /// </summary>       
        public int Draw { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Global search 
        /// </summary>
        public Search Search { get; set; }

        /// <summary>
        /// An array defining all columns in the table
        /// </summary>
        public IList<Column> Columns { get; set; }

        /// <summary>
        /// An array defining how many columns are being ordered upon
        /// </summary>
        public IList<Order> Order { get; set; }
    }
}