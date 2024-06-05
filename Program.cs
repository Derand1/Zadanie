using System;
using System.Collections.Generic;
using ZadanieZukova;

namespace ZadanieZukova
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> Hold_intervals = new List<Interval>();

            Hold_intervals.Add(new Interval("12:30", "13:00"));
            Hold_intervals.Add(new Interval("15:50", "16:20"));
            Hold_intervals.Add(new Interval("17:30", "18:00"));
            Hold_intervals.Add(new Interval("18:05", "19:25"));
            Hold_intervals.Add(new Interval("19:30", "20:00"));

            List<Interval> Free_intervals = CalculateFreeIntervals(Hold_intervals);

            Console.WriteLine("Свободные интервалы:");
            foreach (var interval in Free_intervals)
            {
                Console.WriteLine(interval);
            }
        }

        static List<Interval> CalculateFreeIntervals(List<Interval> holdIntervals)
        {
            List<Interval> freeIntervals = new List<Interval>();

            // Добавляем интервал с начала дня до первого занятого интервала
            TimeSpan startOfDay = new TimeSpan(0, 0, 0);
            TimeSpan endOfDay = new TimeSpan(24, 0, 0);
            TimeSpan firstIntervalStart = holdIntervals[0].GetStartTime();

            if (startOfDay < firstIntervalStart)
            {
                freeIntervals.Add(new Interval("00:00", holdIntervals[0].StartTime));
            }

            // Добавляем интервалы между занятыми интервалами
            for (int i = 0; i < holdIntervals.Count - 1; i++)
            {
                TimeSpan currentEnd = holdIntervals[i].GetEndTime();
                TimeSpan nextStart = holdIntervals[i + 1].GetStartTime();

                if (currentEnd < nextStart)
                {
                    freeIntervals.Add(new Interval(holdIntervals[i].EndTime, holdIntervals[i + 1].StartTime));
                }
            }

            // Добавляем интервал от последнего занятого интервала до конца дня
            TimeSpan lastIntervalEnd = holdIntervals[holdIntervals.Count - 1].GetEndTime();

            if (lastIntervalEnd < endOfDay)
            {
                freeIntervals.Add(new Interval(holdIntervals[holdIntervals.Count - 1].EndTime, "24:00"));
            }

            return freeIntervals;
        }
    }
}