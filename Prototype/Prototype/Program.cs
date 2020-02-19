using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Color color = new Color(10,20,30);
            Color color2 = color.Clone() as Color;
        }
    }

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        public int _red { get; set; }
        private int _green;
        private int _blue;
        
        public Color(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color Rgb {0},{1},{2}",_red,_blue,_green);
            return this.MemberwiseClone() as ColorPrototype;
        }
    }
}
