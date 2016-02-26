# google-charts-aspnet-mvc
An example of generating a Google Chart from a collection of simple .NET objects using ASP.NET MVC

Takes a collection of .NET objects...

    new MarketSales[]
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
    }

... and uses it to create this chart:

![Google Chart](https://blog.cinlogic.com/wp-content/uploads/2016/02/GoogleChart.png)
