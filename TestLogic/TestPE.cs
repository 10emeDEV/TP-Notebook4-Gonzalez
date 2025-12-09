using System;
using Xunit;
using Logic;
namespace TestLogic
{
    public class TestPE
    {
        [Fact]
        public void TestName()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Name = ""; });
            element.Name = "toto";
            Assert.Equal("toto", element.Name);
        }

        [Fact]
        public void TestCoef()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Coef = 0; });
            element.Coef = 1.5f;
            Assert.Equal(1.5, element.Coef, 3);
        }

        [Fact]
        public void TestEqual()
        {
            EducationalElement e1 = new EducationalElement() { Coef = 2.5f, Name = "Test" };
            EducationalElement e2 = new EducationalElement() { Coef = 2.5f, Name = "Test" };
            EducationalElement e3 = new EducationalElement() { Coef = 2, Name = "Test" };
            EducationalElement e4 = new EducationalElement() { Coef = 2.5f, Name = "TEST" };

            Assert.Equal(e1, e2);
            Assert.NotEqual(e1, e3);
            Assert.NotEqual(e1, e4);
        }
    }
}
