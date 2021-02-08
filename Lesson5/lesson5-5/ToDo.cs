using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }

        public ToDo()
        {
            Title = "";
            IsDone = false;
        }

    }
}
