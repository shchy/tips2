using System;
using System.Linq;
using Nancy;
using tips2.Models;

namespace tips2.Modules
{
    public class HomeModule : NancyModule
    {
        private ModelContext context;

        public HomeModule(ModelContext context)
        {
            this.context = context;

            Get["/"] = _ =>
            {
                this.context.Tests.Add(new Test{ Name = DateTime.Now.ToString() });
                this.context.SaveChanges();

                var t = this.context.Tests.Last();
                var result = "Hello World From Docker!" + t.Id;

                return View["Views/Root"];
            };
        }
    }
}
