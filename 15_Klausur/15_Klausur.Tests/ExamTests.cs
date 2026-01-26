using _15_Klausur.src;
using _15_Klausur.src.Observer;
using Xunit;

namespace _15_Klausur.Tests
{
    public class ExamTests
    {
        [Fact]
        public void Film_Encapsulation_Works()
        {
            var film = new Film(1, "Matrix", "SciFi", 1999, 136);
            
            // Check Get
            Assert.Equal("Matrix", film.GetTitel());
            
            // Check Set
            film.SetTitel("Matrix Reloaded");
            Assert.Equal("Matrix Reloaded", film.GetTitel());
        }

        // Mock Observer to verify Update call
        class MockObserver : IObserver
        {
            public bool WasUpdated = false;
            public void Update()
            {
                WasUpdated = true;
            }
        }

        [Fact]
        public void ObserverPattern_UpdateIsCalled()
        {
            // Arrange
            var model = new PatientModel();
            var observer = new MockObserver();
            
            // Manually register (normally done by TableView constructor, but testing logic here)
            model.AddObserver(observer);

            // Act
            model.SetData(1, "New Data");

            // Assert
            Assert.True(observer.WasUpdated, "Observer should be notified on change.");
        }

        [Fact]
        public void TableView_RegistersSelf_InConstructor()
        {
            // Arrange
            // We can't easily check internal state of Model without exposing it, 
            // but we can ensure no exception happens and logic runs.
            var model = new PatientModel();
            var view = new TableView(model); // Should register itself

            // Act
            model.SetData(1, "Test Update");
            
            // If TableView runs Display() without crashing, basic integration works. 
            // Real output verification would need IConsoleService (out of scope for this Mock Exam).
        }
    }
}
