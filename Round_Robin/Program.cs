using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] processes = {1,2,3, };
            int[] burst_time = { 3, 4, 3 };
            int n = processes.Length;
            int quantum = 1;
            findAverage(processes, n, burst_time, quantum);
            Console.ReadKey();
        }
        public static void  findWaiting(int []processes,int n ,int []bt,int quantim,int []waiting_time)
        {

            //n>>number processes
            //bt>>burst time
            //int []waiting_time >>waiting time each process
            // waiting time each process هنستخدمه فى ايجاد 
            int time = 0;
            int[]remaing_bt = new int[n];
            for (int i = 0; i < n; i++)
            {
                //intialize remaing burst time with >>burst time
                remaing_bt[i] = bt[i];
            }
            while(true)
            {
                //while loop هنستخدمه علشان نطلع من 
                bool flag = true;
                //loop each process
                for (int i = 0; i <n; i++)
                {
                    if(remaing_bt[i]>0)
                    {
                        flag = false;
                        if(remaing_bt[i]>quantim)
                        {
                            time =time+ quantim;
                            remaing_bt[i] = remaing_bt[i] - quantim;

                        }
                        // else >> remaing_bt[i]<=quantim
                        else
                        {
                            time = time + remaing_bt[i];
                            waiting_time[i] = time - bt[i];
                            remaing_bt[i] = 0;
                            
                        }

                     } 
                               
                 }

                // end while loop >>when remaing time each processes=0
                if (flag == true)
                {
                    break;
                }

            }


        }
        public static void findTurnAround(int[] processes, int n, int[] bt, int[] wt, int[] tat)
        {
            //total turnAround=waiting+burst 
            for (int i = 0; i < n; i++)
                tat[i] = bt[i] + wt[i];

        }
        public static void findAverage(int[] processes, int n, int[] bt, int quantum)
        {
            int[] waiting_time = new int[n];
            int[] tat = new int[n];
            int total_wt = 0;
            int total_ta = 0;
            findWaiting(processes, n, bt, quantum, waiting_time);
            findTurnAround(processes, n, bt, waiting_time, tat);

            for (int i = 0; i < n; i++)
            {
                total_wt += waiting_time[i];
                total_ta += tat[i];
            }
            Console.WriteLine("Average waiting time = " +(float)total_wt / (float)n);
            Console.Write("Average turn around time = " +(float)total_ta / (float)n);
        }


        
    }
}
