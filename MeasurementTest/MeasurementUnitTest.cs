using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherLibrary;

namespace MeasurementTest
{
    [TestClass]
    public class MeasurementUnitTest
    {
        [TestMethod]
        public void MethodTest()
        {
            Weather weather=new Weather("Raspberry-pi","D3-14",DateTime.Now,28.5,950,30);
        }
    }
}
