using GoogleChartsExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GoogleChartsExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Get the chart data from the database.  At this point it is just an array of MarketSales objects.
            var data = GetMarketSalesFromDatabase();

            return View(new SalesChartModel()
            {
                Title = "Total Sales By Market and Year",
                Subtitle = "Cincinnati, Cleveland, Columbus, and Dayton",
                DataTable = ConstructDataTable(data)
            });
        }

        private GoogleVisualizationDataTable ConstructDataTable(MarketSales[] data)
        {
            var dataTable = new GoogleVisualizationDataTable();

            // Get distinct markets from the data
            var markets = data.Select(x => x.Market).Distinct().OrderBy(x => x);

            // Get distinct years from the data
            var years = data.Select(x => x.Year).Distinct().OrderBy(x => x);

            // Specify the columns for the DataTable.
            // In this example, it is Market and then a column for each year.
            dataTable.AddColumn("Market", "string");
            foreach (var year in years)
            {
                dataTable.AddColumn(year.ToString(), "number");
            }

            // Specify the rows for the DataTable.
            // Each Market will be its own row, containing the total sales for each year.
            foreach (var market in markets)
            {
                var values = new List<object>(new[] { market });
                foreach (var year in years)
                {
                    var totalSales = data
                        .Where(x => x.Market == market && x.Year == year)
                        .Select(x => x.TotalSales)
                        .SingleOrDefault();
                    values.Add(totalSales);
                }
                dataTable.AddRow(values);
            }

            return dataTable;
        }

        private MarketSales[] GetMarketSalesFromDatabase()
        {
            // Let's pretend this came from a database, via EF, Dapper, or something like that...
            return new MarketSales[]
            {
                new MarketSales() { Market = "Cincinnati", Year = 2013, TotalSales = 723898 },
                new MarketSales() { Market = "Cincinnati", Year = 2014, TotalSales = 898132 },
                new MarketSales() { Market = "Cincinnati", Year = 2015, TotalSales = 941823 },

                new MarketSales() { Market = "Columbus", Year = 2013, TotalSales = 509132 },
                new MarketSales() { Market = "Columbus", Year = 2014, TotalSales = 570913 },
                new MarketSales() { Market = "Columbus", Year = 2015, TotalSales = 460923 },

                new MarketSales() { Market = "Cleveland", Year = 2013, TotalSales = 753939 },
                new MarketSales() { Market = "Cleveland", Year = 2014, TotalSales = 830923 },
                new MarketSales() { Market = "Cleveland", Year = 2015, TotalSales = 910302 },

                new MarketSales() { Market = "Dayton", Year = 2013, TotalSales = 109012 },
                new MarketSales() { Market = "Dayton", Year = 2014, TotalSales = 400302 },
                new MarketSales() { Market = "Dayton", Year = 2015, TotalSales = 492901 }
            };
        }
        
    }
}
 