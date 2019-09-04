using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;

namespace QueueManager
{
    public class ShoppingQueue
    {        
        public static int _shopperCounter = 0;
        public static ConcurrentQueue<Shopper> _shoppers = new ConcurrentQueue<Shopper>();
        public static Random random = new Random();
        public static Timer t;

        public static void Enqueue(object State)
        {
            int id = _shopperCounter;
            _shoppers.Enqueue(new Shopper(id));
            _shopperCounter++;
            Console.WriteLine("New Shopper in line. Id: {0}.", id);
        }

        public static void Dequeue(Cashier cashier)
        {
            _shoppers.TryDequeue(out Shopper shopper1);
            if (shopper1 != null)
            {
                Console.WriteLine("Shopper with id: {0} is being served by cashier {1}. Waiting time: {2} seconds.", shopper1.Id, cashier.Id, DateTime.Now.Subtract(shopper1.joinTime).TotalSeconds);
                Thread.Sleep(random.Next(1000, 5000));
            }
        }        
        public static void Work(Cashier cashier)
        {
            while(true)
            {
                Dequeue(cashier);
            }                                   
        }     
        static void Main(string[] args)
        {
            Console.WriteLine("Press 's' to start, press 'q' to quit at any point.");
            while (true)
            {                
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 's')
                {
                    ShoppingQueue queue = new ShoppingQueue();
                    t = new Timer(new TimerCallback(Enqueue), null, 0, 1000);
                    
                    Thread cashierLine = new Thread(() => Work(new Cashier(1)));
                    cashierLine.Start();
                    Thread cashierLine2 = new Thread(() => Work(new Cashier(2)));
                    cashierLine2.Start();
                    Thread cashierLine3 = new Thread(() => Work(new Cashier(3)));
                    cashierLine3.Start();
                    Thread cashierLine4 = new Thread(() => Work(new Cashier(4)));
                    cashierLine4.Start();
                    Thread cashierLine5 = new Thread(() => Work(new Cashier(5)));
                    cashierLine5.Start();
                }
                else if(key.KeyChar == 'q')
                {
                    Environment.Exit(0);                    
                }
            }
        }        

        
    }
}
