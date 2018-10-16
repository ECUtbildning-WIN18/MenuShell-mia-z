using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShell
{
    abstract class BaseView
    {
        public string Title { get; }

        public BaseView(string title)
        {
            Title = title;
            Console.Title = title;
        }
    }
}
