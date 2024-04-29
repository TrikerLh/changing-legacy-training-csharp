using NUnit.Framework;

namespace KataTirePressureVariation.Test
{
    public class AlarmShould
    {
        [Test]
        public void AlarmActivateWhenPressureIsLowerThanLowPressureThreshold()
        {
            var alarm = new AlarmForTesting(16);
            
            alarm.Check();
            
            Assert.That(alarm._message, Is.EqualTo("Alarm activated!"));
        }
    }

    public class AlarmForTesting : Alarm
    {
        public double _pressure;
        public string _message;

        public AlarmForTesting(double pressure)
        {
            _pressure = pressure;
        }

        protected override double GetPsiPressure()
        {
            return _pressure;
        }

        protected override void WriteMessage(string message)
        {
            _message = message;
        }
    }
}