using System;
using System.Linq;
using Nancy;
using tips.Models;

namespace tips.Modules
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
                
                return View["Views/Root", t];
            };
        }
    }
}
