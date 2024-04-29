using System;

namespace KataTirePressureVariation
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor sensor = new Sensor();

        private bool alarmOn = false;

        public void Check()
        {
            double psiPressureValue = GetPsiPressure();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                if (!IsAlarmOn())
                {
                    alarmOn = true;
                    WriteMessage("Alarm activated!");
                }
            }
            else
            {
                if (IsAlarmOn())
                {
                    alarmOn = false;
                    WriteMessage("Alarm deactivated!");
                }
            }
        }

        //protected and virtual for testing
        protected virtual double GetPsiPressure()
        {
            return sensor.PopNextPressurePsiValue();
        }

        //protected and virtual for testing
        protected virtual void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        private bool IsAlarmOn()
        {
            return alarmOn;
        }
    }
}