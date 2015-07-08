using System;
using System.Web.Mvc;

namespace MVCWithDatatables.Models.DataTables
{
    public class DataTablesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }

            DataTableParamModel dataTable = new DataTableParamModel();
            var valueProvider = bindingContext.ValueProvider;
            string draw = GetValue<string>(valueProvider, "draw");
            if (string.IsNullOrEmpty(draw))
            {
                throw new ArgumentException("draw must always be provided");
            }
            dataTable.Draw = int.Parse(draw);
            dataTable.Length = GetValue<int>(valueProvider, "length");
            dataTable.Start = GetValue<int>(valueProvider, "start");
            dataTable.Search = new Search
                                    (GetValue<string>(valueProvider, "search[value]"), GetValue<bool>(valueProvider, "search[regex]"));

            int i = 0;
            while (true)
            {
                string col = string.Format("columns[{0}]", i);
                string colData = GetValue<string>(valueProvider, col + "[data]");
                if (colData == null)
                    break;
                string colName = GetValue<string>(valueProvider, col + "[name]");
                bool colSearchable = GetValue<bool>(valueProvider, col + "[searchable]");
                bool colOrderable = GetValue<bool>(valueProvider, col + "[orderable]");
                Search colSearch = new Search
                                    (GetValue<string>(valueProvider, col + "[search][value]"), GetValue<bool>(valueProvider, col + "[search][regex]"));

                dataTable.Columns.Add(new Column(colData, colName, colSearchable, colOrderable, colSearch));
                i++;
            }

            for (int j = 0; j < i; j++)
            {
                string order = string.Format("order[{0}]", j);
                string orderDir = GetValue<string>(valueProvider, order + "[dir]");
                if (orderDir == null)
                    continue;
                int orderCol = GetValue<int>(valueProvider, order + "[column]");
                dataTable.Order.Add(new Order(orderCol, orderDir));
            }
            return dataTable;
        }

        private static T GetValue<T>(IValueProvider valueProvider, string key)
        {
            ValueProviderResult valueResult = valueProvider.GetValue(key);
            return (valueResult == null)
                ? default(T)
                : (T)valueResult.ConvertTo(typeof(T));
        }
    }
}