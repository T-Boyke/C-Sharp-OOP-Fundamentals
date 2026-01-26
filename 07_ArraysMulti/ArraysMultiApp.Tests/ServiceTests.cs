using Xunit;
using ArraysMultiApp;

namespace ArraysMultiApp.Tests
{
    public class ServiceTests
    {
        // --- Matrix Tests ---

        [Fact]
        public void CreateMultiplicationTable_IsCorrect()
        {
            int[,] table = MatrixService.CreateMultiplicationTable(3);
            
            // Expected:
            // 1 2 3
            // 2 4 6
            // 3 6 9
            
            Assert.Equal(1, table[0, 0]);
            Assert.Equal(9, table[2, 2]);
            Assert.Equal(6, table[1, 2]); // 2. Zeile (Index 1), 3. Spalte (Index 2) -> 2*3=6
        }

        [Fact]
        public void FindPositions_ReturnsCorrectCoordinates()
        {
            int[,] matrix = {
                { 1, 5, 2 },
                { 5, 3, 5 }
            };

            var positions = MatrixService.FindPositions(matrix, 5);

            Assert.Equal(3, positions.Count);
            Assert.Contains((0, 1), positions);
            Assert.Contains((1, 0), positions);
            Assert.Contains((1, 2), positions);
        }

        [Fact]
        public void GetDivisibleBy_FiltersCorrectly()
        {
            int[,] matrix = { { 7, 14, 3 }, { 21, 5, 8 } };
            var result = MatrixService.GetDivisibleBy(matrix, 7);

            Assert.Equal(3, result.Count);
            Assert.Contains(7, result);
            Assert.Contains(14, result);
            Assert.Contains(21, result);
        }

        // --- Jagged Tests ---

        [Fact]
        public void CreateTriangleRepetition_StructureIsCorrect()
        {
            int[][] result = JaggedArrayService.CreateTriangleRepetition(3);

            // Row 0: [1]
            Assert.Single(result[0]);
            Assert.Equal(1, result[0][0]);

            // Row 1: [2, 2]
            Assert.Equal(2, result[1].Length);
            Assert.Equal(2, result[1][0]);
            Assert.Equal(2, result[1][1]);
        }

        [Fact]
        public void CreateTriangleCounting_StructureIsCorrect()
        {
            int[][] result = JaggedArrayService.CreateTriangleCounting(3);

            // Row 2: [1, 2, 3]
            Assert.Equal(3, result[2].Length);
            Assert.Equal(1, result[2][0]);
            Assert.Equal(2, result[2][1]);
            Assert.Equal(3, result[2][2]);
        }
    }
}
