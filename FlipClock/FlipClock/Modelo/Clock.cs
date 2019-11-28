using System;
using System.Collections.Generic;
using System.Text;

namespace FlipClock.Modelo
{
    class Clock
    {
        private int _second_unit, _second_tenth,
            _minute_unit, _minute_tenth, _hour_unit, _hour_tenth;

        private string _up_image_second_unit, _up_image_second_tenth,
            _up_image_minute_unit, _up_image_minute_tenth,
            _up_image_hour_unit, _up_image_hour_tenth;

        private string _down_image_second_unit, _down_image_second_tenth,
            _down_image_minute_unit, _down_image_minute_tenth,
            _down_image_hour_unit, _down_image_hour_tenth;

        public Clock(int hour_tenth, int hour_unit,
            int minute_tenth, int minute_unit, int second_tenth, int second_unit)
        {
            setHours(hour_tenth, hour_unit);
            setMinutes(minute_tenth, minute_unit);
            setSeconds(second_tenth, second_unit);
        }

        public void setHours(int hour_tenth, int hour_unit)
        {
            _hour_tenth = hour_tenth;
            _up_image_hour_tenth = $"up_{hour_tenth}.png";
            _down_image_hour_tenth = $"down_{hour_tenth}.png";

            _hour_unit = hour_unit;
            _up_image_hour_unit = $"up_{hour_unit}.png";
            _down_image_hour_unit = $"down_{hour_unit}.png";
        }

        public void setMinutes(int minute_tenth, int minute_unit)
        {
            _minute_tenth = minute_tenth;
            _up_image_minute_tenth = $"up_{minute_tenth}.png";
            _down_image_minute_tenth = $"down_{minute_tenth}.png";

            _minute_unit = minute_unit;
            _up_image_minute_unit = $"up_{minute_unit}.png";
            _down_image_minute_unit = $"down_{minute_unit}.png";
        }

        public void setSeconds(int second_tenth, int second_unit)
        {
            _second_tenth = second_tenth;
            _up_image_second_tenth = $"up_{second_tenth}.png";
            _down_image_second_tenth = $"down_{second_tenth}.png";

            _second_unit = second_unit;
            _up_image_second_unit = $"up_{second_unit}.png";
            _down_image_second_unit = $"down_{second_unit}.png";

        }

        public void stepClock()
        {
            _second_unit++;

            if(_second_unit == 10)
            {
                _second_unit = 0;
                _second_tenth++;

                if(_second_tenth == 6)
                {
                    ResetSecondMeter();
                    minutesControl();
                }
            }

            setSeconds(_second_tenth,_second_unit);
        }

        private void minutesControl()
        {

            _minute_unit++;

            if (_minute_unit == 10)
            {
                _minute_unit = 0;
                _minute_tenth++;

                if (_minute_tenth == 6)
                {
                    ResetMinuteMeter();
                    hoursControl();
                }
            }

            setMinutes(_minute_tenth, _minute_unit);
        }

        private void hoursControl()
        {
            _hour_unit++;

            if (_hour_tenth == 2 && _hour_unit == 4)
                ResetClock();

            if(_hour_unit == 10)
            {
                _hour_unit = 0;
                _hour_tenth++;
            }

            setHours(_hour_tenth, _hour_unit);
        }

        private void ResetClock()
        {
            _hour_tenth = 0;
            _hour_unit = 0;

            _minute_tenth = 0;
            _minute_unit = 0;

            _second_tenth = 0;
            _second_unit = 0;
        }

        private void ResetSecondMeter()
        {
            _second_unit = 0;
            _second_tenth = 0;
        }

        private void ResetMinuteMeter()
        {
            _minute_unit = 0;
            _minute_tenth = 0;
        }

        public int getHourTenth()
        {
            return _hour_tenth;
        }

        public int getHourUnit()
        {
            return _hour_unit;
        }

        public int getMinuteTenth()
        {
            return _minute_tenth;
        }

        public int getMinuteUnit()
        {
            return _minute_unit;
        }

        public int getSecondTenth()
        {
            return _second_tenth;
        }

        public int getSecondUnit()
        {
            return _second_unit;
        }

        public string getUpImageSecondTenth()
        {
            return _up_image_second_tenth;
        }

        public string getDownImageSecondUnit()
        {
            return _down_image_second_unit;
        }

        public string getUpImageMinuteTenth()
        {
            return _up_image_minute_tenth;
        }

        public string getDownImageMinuteUnit()
        {
            return _down_image_minute_unit;
        }

        public string getUpImageHourTenth()
        {
            return _up_image_hour_tenth;
        }

        public string getDownImageHourUnit()
        {
            return _down_image_hour_unit;
        }
    }
}
