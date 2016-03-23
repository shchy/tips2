using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using tips2.Models;

namespace test
{
    using A = tips2.Models.Test;

    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html
    public class SampleTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.NotEqual(5, Add(2, 2));
        }

        [Fact]
        public void TestTest()
        {
            var t = new A();
            t.Name = "unko";
            Assert.Equal("unko", t.Name);
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
