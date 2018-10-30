using System;

namespace MenuShell.Domain.Services
{
    abstract class View
    {
        private string Title { get; }

        protected View(string title)
        {
            Title = title;
            Console.Title = title;
        }
    }
}
