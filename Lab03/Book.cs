using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Book
    {
        protected string title;
        protected Person author;
        protected string data;

        public Book(string title, Person author, string data)
        {
            this.title = title;
            this.author = author;
            this.data = data;
        }

        public override string ToString()
        {
            return $"Tytuł: {title}, autor: {author}, data: {data}";
        }

        public virtual void View()
        {
            Console.WriteLine(ToString());
        }
    }
}
