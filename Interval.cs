using System;

namespace ZadanieZukova
{
    internal class Interval
    {
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;

        public Interval(string start, string end)
        {
            StartTime = start;
            EndTime = end;
        }

        public TimeSpan GetStartTime()
        {
            return TimeSpan.Parse(StartTime);
        }

        public TimeSpan GetEndTime()
        {
            return TimeSpan.Parse(EndTime);
        }

        public override string ToString()
        {
            return $"{StartTime} - {EndTime}";
        }
    }
}