using Xunit;
using ExamApp;
using ExamApp.Observer;
using System.Collections.Generic;

namespace ExamApp.Tests
{
    public class KlausurTests
    {
        [Fact]
        public void Film_GetInfo_ReturnsCorrectString()
        {
            var f = new Film("A", 100, 2000, "B");
            var info = f.GetInfo();
            Assert.Contains("A", info);
            Assert.Contains("2000", info);
            Assert.Contains("100", info);
            Assert.Contains("B", info);
        }

        [Fact]
        public void Observer_NotifiesAttachedObservers()
        {
            var subject = new PatientModel();
            var obs = new MockObserver();
            
            subject.Attach(obs);
            subject.SetDiagnosis("Test");

            Assert.Single(obs.Messages);
            Assert.Contains("Neue Diagnose: Test", obs.Messages[0]);
        }

        [Fact]
        public void Observer_DoesNotNotifyDetachedObservers()
        {
            var subject = new PatientModel();
            var obs = new MockObserver();
            
            subject.Attach(obs);
            subject.Detach(obs);
            subject.SetDiagnosis("Test");

            Assert.Empty(obs.Messages);
        }
    }

    public class MockObserver : IObserver
    {
        public List<string> Messages { get; } = new();
        public void Update(string message) => Messages.Add(message);
    }
}
