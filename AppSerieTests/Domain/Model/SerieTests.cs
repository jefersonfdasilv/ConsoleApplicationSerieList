using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppSerie.Domain.Model.Tests
{
    [TestClass()]
    public class SerieTests
    {
        [TestMethod()]
        public void SerieTestNewInstanceWithOutParameters()
        {
            Assert.IsInstanceOfType(new Serie(), typeof(Serie));
        }
    }
}