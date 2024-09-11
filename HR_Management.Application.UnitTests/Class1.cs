using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests
{
    public class Class1
    {
        int add(int a, int b)
        {
            return a + b;
        }



        [Fact]
        public void AddTest1()
        {
            Assert.Equal(4,add(2,2));
        }



        [Fact]
        public void AddTest2()
        {
            Assert.Equal(5, add(3, 2));
        }


    }
}
