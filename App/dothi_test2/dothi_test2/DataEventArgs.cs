using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dothi_test2
{
    public class DataEventArgs : EventArgs
    {
        public int Laser { get; }
        public int Velocity { get; }
        public double[] TP { get; }



        public DataEventArgs(int laser, int velocity, double[] tp)
        {
            Laser = laser;
            Velocity = velocity;
            TP = tp;
        }
    }
}
