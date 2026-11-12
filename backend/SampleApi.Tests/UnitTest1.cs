//namespace SampleApi.Tests;
//
//public class UnitTest1
//{
//    [Fact]
//    public void Test1()
//    {
//
//    }
//}


using Xunit;

namespace SampleApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BasicEvaluationTest()
        {
            // Arrange
            bool evaluationIsReady = true;

            // Act & Assert
            Assert.True(evaluationIsReady);
        }
    }
}