using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Events
{
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double NewTemperature { get; }

        public TemperatureChangedEventArgs(double newTemperature)
        {
            NewTemperature = newTemperature;
        }
    }
    public class Thermostat
    {
        private double _temperature;
        public Action<TemperatureChangedEventArgs> TemperatureChanged;

        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                if (_temperature != value)
                    TemperatureChanged?.Invoke(new TemperatureChangedEventArgs(_temperature));
                _temperature = value;
            }
        }

    }

    public class Heater
    {
        private readonly double _threshold;

        public Heater(double threshold)
        {
            _threshold = threshold;
        }

        public void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            if (e.NewTemperature < _threshold)
            {
                Console.WriteLine("Heater: Temperature is low! Turning on the heater.");
            }
        }
    }


    public class Cooler
    {
        private readonly double _threshold;

        public Cooler(double threshold)
        {
            _threshold = threshold;
        }

        public void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            if (e.NewTemperature > _threshold)
            {
                Console.WriteLine("Cooler: Temperature is high! Turning on the cooler.");
            }
        }
    }
}