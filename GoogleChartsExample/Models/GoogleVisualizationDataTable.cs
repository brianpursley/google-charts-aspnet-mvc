using System.Collections.Generic;
using System.Linq;

namespace GoogleChartsExample.Models
{
    // This class is used to facilitate JSON serialization into the format required by Google to create a DataTable.
    // See https://developers.google.com/chart/interactive/docs/reference#DataTable
    public class GoogleVisualizationDataTable
    {
        public IList<Col> cols { get; } = new List<Col>();
        public IList<Row> rows { get; } = new List<Row>();

        public void AddColumn(string label, string type)
        {
            cols.Add(new Col() { label = label, type = type });
        }

        public void AddRow(IList<object> values)
        {
            rows.Add(new Row() { c = values.Select(x => new Row.RowValue() { v = x }) });
        }

        public class Col
        {
            public string label { get; set; }
            public string type { get; set; }
        }

        public class Row
        {
            public IEnumerable<RowValue> c { get; set; }
            public class RowValue
            {
                public object v;
            }
        }
    }
}