using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace assignment2
{
    public class Clock
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public Clock(int hour, int minute, int second){
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }
    }
    public class ClockPublisher{
        public delegate void SecondChangeHandler(ClockPublisher clockPublisher, Clock time);

        public event SecondChangeHandler SecondChange;

        public void OnSecondChange(ClockPublisher clockPublisher, Clock time){
            SecondChange(clockPublisher, time);
        }

        public void Run(){
            while(true){
                Thread.Sleep(1000);
                DateTime now = DateTime.Now;
                Clock time = new Clock(now.Hour, now.Minute,now.Second);
                OnSecondChange(this, time);
            }
        }
    }
    public class ClockSubcriber{
        public void Subcribe(ClockPublisher publisher){
            publisher.SecondChange += new ClockPublisher.SecondChangeHandler(TimeHasChanged);
        }
        private void TimeHasChanged(ClockPublisher clockPublisher, Clock time){
            Console.WriteLine($"The current time is {time.Hour}:{time.Minute}:{time.Second}");
        }
    }
    class Program
    {
        static async Task<List<int>> GetPrimeNumberAsync(int min, int max)
        {
            List<int> results = new List<int>();
            var list = await Task.Factory.StartNew(() =>
            {
                for (var i = min; i<= max; i++)
                {
                    if(IsPrimeNumber(i))
                    {
                        results.Add(i);
                    }
                }
                return results;
            });
            return list;
        }
        static bool IsPrimeNumber(int number)
        {
            if (number < 2) return false;
            for(var i = 2; i < number; i++){
                if(number % i == 0 ){
                    return false;
                }
            }
            return true;
        }
        static async Task Main(string[] args)
        {
            //delegate and event
            // ClockPublisher clockPublisher = new ClockPublisher();
            // ClockSubcriber clockSubcriber = new ClockSubcriber();
            // clockSubcriber.Subcribe(clockPublisher);
            // clockPublisher.Run();

            // asynchronous
            int min =1, max =10;
            Task<List<int>>[] primes = new Task<List<int>>[2];
            primes[0] = GetPrimeNumberAsync(min,max/2);
            primes[1] = GetPrimeNumberAsync((max/2) + 1,max);
            var results = await Task.WhenAll(primes);
            foreach(var list in results)
            {
                Console.WriteLine($"{list.Count}");
            }
        }
    }
}
