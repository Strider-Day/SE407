using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathmatics.Test
{
    public class BasicMathTestFixture : IDisposable
    {
        private BasicMath _testObject;

        public BasicMath TestObject { get => TestObject; }
        public BasicMathTestFixture()
        {
            _testObject = new BasicMath();
        }
        public void Dispose() 
        {

        }
    }
}
