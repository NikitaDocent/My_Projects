using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class DocOffers
    {
        const int n = 5;
        public List<string> Offer { get; set; } = new List<string>();

        public DocOffers(Docs[] docs)
        {
            int i = 0;
            while (i < 5)
            {
                Offer.Add("Title:\t\t" + docs[i].Title + "\tAuthor:\t\t" + docs[i].Author);
                docs[i].InLib = false;
                i++;
            }
        }
        //возможность вернуть книгу
        public void ReturnBook(int ind)
        {
            if (ind < 0 || ind >= Offer.Count)
                throw new LibraryException("Index out of range");
            Offer.RemoveAt(ind);
        }
        //возможность взять книгу
        public void AddBook(Docs docs)
        {
            if (Offer.Count >= n)
                throw new LibraryException("Can't add more Offer's");
            else if (docs.InLib == true)
                Offer.Add("Title:\t\t" + docs.Title + "\tAuthor:\t\t" + docs.Author);
            else
                throw new LibraryException("Book take Visitor!!");
        }
        public override string ToString()
        {
            string a = "";
            for (int i = 0; i < Offer.Count; i++)
                a += Offer[i] + "\n";
            return a;
        }
        public DocOffers() { }
    }

}