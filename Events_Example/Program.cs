using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Monitor();
            m.onLowData += GetData;
            m.onHighData += GetData;
            m.readData();
            // m.onLowData += GetData;
            //m.readData();
            Console.ReadKey();
        }

        public static void GetData(int data)
        {
            Console.WriteLine($"Tempurature at {DateTime.Now} is ' {data} ' ");
           // return data;
        }
    }

    public class Monitor
    {
        public delegate void Warning(int d);
        public event Warning onLowData;
        public event Warning onHighData;

        public void readData()
        {
            var r = new Random();
            int data;
            while (true)
            {
                data = r.Next(-10,30);
                if (data < 0)
                {
                    if (onLowData != null)
                    {
                        onLowData(data);
                    }
                }
                if (data > 20)
                {
                    if (onHighData != null)
                    {
                        onHighData(data);
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
