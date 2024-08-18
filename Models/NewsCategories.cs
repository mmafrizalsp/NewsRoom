using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsRoom.Models;

public class NewsCategories
{
    public Dictionary<string, string> category_list = new()
    {
        { "everything?domains=wsj.com", "The Wall Street" },
        { "top-headlines?sources=techcrunch", "Tech Crunch" },
        { "top-headlines?country=us&category=business", "Business" },
        { $"everything?q=apple&from={DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")}&to={DateTime.Now.ToString("yyyy-MM-dd")}&sortBy=popularity", "Apple" },
        { $"everything?q=tesla&from={DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")}&sortBy=publishedAt", "Tesla" },
        { $"everything?q=microsoft&from={DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")}&sortBy=publishedAt", "Microsoft" },
    };
}