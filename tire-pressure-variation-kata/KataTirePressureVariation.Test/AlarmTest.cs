using NUnit.Framework;

namespace KataTirePressureVariation.Test
{
    public class AlarmShould
    {
        [Test]
        public void AlarmActivateWhenPressureIsLowerThanLowPressureThreshold()
        {
            var alarm = new AlarmForTesting(new List<double> { 16 });
            
            alarm.Check();
            
            Assert.That(alarm._lastMessage, Is.EqualTo("Alarm activated!"));
        }

        [Test]
        public void AlarmActivateWhenPressureIsHigherThanHighPressureThreshold() {
            var alarm = new AlarmForTesting(new List<double>{22});

            alarm.Check();

            Assert.That(alarm._lastMessage, Is.EqualTo("Alarm activated!"));
        }

        [Test]
        public void DeactivatedAlarmAfterBeingActivatedIsActivatedAgain() {
            var deactivatedAlarm = CreateDeactivatedAlarmAfterBeingActivated(500);

            deactivatedAlarm.Check();

            Assert.That(deactivatedAlarm._lastMessage, Is.EqualTo("Alarm activated!"));
        }


        [TestCase(17)]
        [TestCase(21)]
        public void ActivatedAlarmDeactivatesWhenPressureInsideSafetyRange(double pressure) {
            var activatedAlarm = CreateActivatedAlarmSensing(pressure);

            activatedAlarm.Check();

            Assert.That(activatedAlarm._lastMessage, Is.EqualTo("Alarm deactivated!"));
        }

        private static AlarmForTesting CreateActivatedAlarmSensing(double pressure)
        {
            var alarm = new AlarmForTesting(new List<double> { 16, pressure });
            alarm.Check();
            return alarm;
        }

        private static AlarmForTesting CreateDeactivatedAlarmAfterBeingActivated(double pressure)
        {
            var alarm = new AlarmForTesting(new List<double> { 16, 20, pressure });
            alarm.Check();
            alarm.Check();
            return alarm;
        }
    }

    public class AlarmForTesting : Alarm
    {
        public List<double> _pressure;
        public string _lastMessage;
        private int _numCheckCalls;

        public AlarmForTesting(List<double> pressure)
        {
            _pressure = pressure;
            _numCheckCalls = 0;
        }

        protected override double GetPsiPressure()
        {
            var psiPressure = _pressure[_numCheckCalls];
            _numCheckCalls++;
            return psiPressure;
        }

        protected override void WriteMessage(string message)
        {
            _lastMessage = message;
        }
    }
}