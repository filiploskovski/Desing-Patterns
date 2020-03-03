using System;
using System.Collections.Generic;

namespace OpenClosedPriciple
{
    public enum Color{
        Red,Green,Blue
    }
    public enum Size
    {
        Small,Medium,Large
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color{ get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> item, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> second, ISpecification<T> first)
        {
            this.second = second;
            this.first = first;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BestFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> item, ISpecification<Product> spec)
        {
            foreach(var i in item)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Large);
            var orange = new Product("Orange", Color.Blue, Size.Medium);
            var tree = new Product("Tree", Color.Blue, Size.Small);

            Product[] products = {apple, orange, tree};

            var bf = new BestFilter();
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"Item: {p.Name}");
            }

            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Medium)))
            {
                Console.WriteLine($"Item: {p.Name}");
            }

            foreach (var p in bf.Filter(products, new 
                AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Medium))))
            {
                Console.WriteLine($"Item: {p.Name}");
            }

            Console.ReadLine();

        }
    }
}
