using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Ex.1
        [Test]  
        public void SetVertices_isRectangle()
        {
            // arrange
            double[] x = new double[4] {1, 1, 4, 4 };
            double[] y = new double[4] {0, 2, 2, 0 };
            double[] expected = new double[4] { 2, 3, 2, 3 };
            ExerciseClasses.Rectangle rectWithSetter = new ExerciseClasses.Rectangle();           

            // act
            rectWithSetter.SetVertices(x, y);
            double[] actual = rectWithSetter.CalculateEdges();

            // assert
            Assert.AreEqual(expected, actual);
        }

        // Ex.2
        [Test]
        public void ArrayFilterAndSort()
        {
            // arrange
            int[] a = new int[12] { 1, -3, 0, -1, 13, 5, 8, 1, 2, 3, 21, -3 };
            int[] expected = new int[11] { -3, -1, 0, 1, 1, 2, 3, 5, 8, 13, 21 };

            // act
            int[] actual = ExerciseClasses.ArrayProcessor.SortAndFilter(a);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}