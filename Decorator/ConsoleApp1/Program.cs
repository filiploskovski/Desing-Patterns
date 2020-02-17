using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    abstract class LibraryItem
    {
        private int _numCopies;

        public int NumCopies
        {
            get => _numCopies;
            set => _numCopies = value;
        }
        public abstract void Display();
    }

    // ConcreteComponent class - za koj treba da ima dodadtna f-ja ili feature
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        public Book(string author, string title, int numCopies)
        {
            _author = author;
            _title = title;
            this.NumCopies = numCopies;
        }
        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    // ConcreteComponent class - za koj treba da ima dodadtna f-ja ili feature
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        public Video(string director, string title,
            int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    // za koj sve treba da se implemnetira f-jata 
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem item)
        {
            libraryItem = item;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    // f-ja sto treba da se implementira 
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();
        public Borrowable(LibraryItem item) : base(item) { }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }
        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Bill","Net core",100);
            book.Display();

            Video video = new Video("Losko","Goce Delcev",100,98);
            video.Display();

            Borrowable borrowable = new Borrowable(video);
            borrowable.BorrowItem("Customer 1");

            borrowable.Display();

            Console.ReadKey();
        }
    }
}
