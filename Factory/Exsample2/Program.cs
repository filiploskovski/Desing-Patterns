using System;

namespace Exsample2
{
    class Program
    {
        public class Point
        {
            private double x;
            private double y;

            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static PointFactory Factory => new PointFactory();

            public class PointFactory
            {
                public Point NewCartesianPoint(double x, double y)
                {
                    return new Point(x,y);
                }

                public Point NewPolarPoint(double rho, double theta)
                {
                    return new Point(rho*Math.Cos(theta),rho*Math.Sin(theta));
                }
            }
        }

        static void Main(string[] args)
        {
            var xx = Point.Factory.NewCartesianPoint(1, 2);
        }
    }
}
