using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Resume();

            foreach (Page page in document.Pages)
            {
                Console.WriteLine(" " + page.GetType().Name);
            }
        }
        abstract class Page { }

        class SkillPage : Page { }

        class EducationPage : Page { }

        class ExperiencePage : Page { }

        abstract class Document
        {
            private List<Page> _pages = new List<Page>();

            public abstract void CreatePages();

            public Document()
            {
                this.CreatePages();
            }

            public List<Page> Pages => _pages;
        }

        class Resume : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new EducationPage());
                Pages.Add(new SkillPage());
                Pages.Add(new ExperiencePage());
            }
        }
    }
}
