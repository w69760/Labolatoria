using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class DocumentaryBook : Book
    {
        string opis;

        public DocumentaryBook(string title, Person author, string data, string opis) : base(title, author, data)
        {
            this.opis = opis;
        }

        public override void View()
        {
            base.View();
            Opis();
        }
        public void Opis()
        {
            Console.WriteLine($"Opis książki '{title}':\n{opis}");
        }
    }
}
