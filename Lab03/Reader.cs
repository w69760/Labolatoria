using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Reader : Person
    {

        protected List<Book> lista;
        public List<Book> Lista
        {
            get
            {
                return lista;
            }
        }

        public Reader(string firstName, string lastName, int wiek) : base(firstName,lastName,wiek)
        {
            lista = new List<Book>();
        }

        public override void View()
        {
            base.View();
            ViewBook();
        }
        public void ViewBook()
        {
            Console.WriteLine($"Ksiazki przeczytane przez {this}");
            foreach(Book ksiazka in lista)
            {
                ksiazka.View();
                Console.WriteLine();
            }
        }
    }
}
