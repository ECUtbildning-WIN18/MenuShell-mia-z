using System;

namespace MenuShell.Domain.Services
{
    abstract class View
    {
        private string Title { get; }

        protected internal View(string title) //Object that doesn't have a menu
        {
            Console.Clear();
            Title = title;
            Console.Title = title;
            DrawBox(Console.WindowWidth, Console.WindowHeight);
            DrawTitle(title);
        }
        
        protected internal View(string title, string[] entries) //Object that has a menu
        {
            Console.Clear();
            Title = title;
            Console.Title = title;
            DrawBox(Console.WindowWidth, Console.WindowHeight);
            DrawEntries(entries);
            DrawTitle(title);
        }

        private void DrawBox(int width, int height)
        {
            for (var x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, height-1);
                Console.Write("#");
            }
            for (var y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(width-1, y);
                Console.Write("#");
            }
        }

        private void DrawEntries(string[] entries)
        {
            var y = 2;
            foreach (string s in entries)
            {
                WriteJustified(s, y);
                y += 2;
            }
        }

        private void DrawTitle(string title)
        {
            string newTitle = " -- " + title + " -- ";
            WriteJustified(newTitle, 0);
        }

        public void ClearInside()
        {
            for (int x = 1; x < Console.WindowWidth-1; x++)
            {
                for (int y = 1; y < Console.WindowHeight-1; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
        }

        public void WriteJustified(string s, int y)
        {
            int justifiedX = Convert.ToInt32(Math.Floor((double)(Console.WindowWidth - s.Length) / 2));
            Console.SetCursorPosition(justifiedX, y);
            Console.Write(s);
        }

        public void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        public void CleanView(string title, string[] entries)
        {
            Console.Clear();
            Console.Title = title;
            DrawBox(Console.WindowWidth, Console.WindowHeight);
            DrawEntries(entries);
            DrawTitle(title);
        }
    }
}
