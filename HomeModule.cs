using System;
using System.Linq;
using tips2.Models;

namespace tips2
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule(ModelContext context)
        {
            context.Tests.Add(new Test{ Name = DateTime.Now.ToString() });
            context.SaveChanges();

            Get["/"] = _ =>
            {
              var t = context.Tests.First();
              return "Hello World" + t.Id;
            };
        }
    }
}
