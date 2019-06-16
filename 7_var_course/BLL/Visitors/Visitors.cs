using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Visitors
    {
        private int academGroup;
        public DocOffers offers { get; set; } = new DocOffers();
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AcademGroup
        {
            get { return academGroup; }
            set
            {
                if (value <= 0)
                    throw new LibraryException("Wrong group");
                else academGroup = value;
            }
        }

        public Visitors(int group, string n, string sn, DocOffers doc)
        {
            AcademGroup = group;
            Name = n;
            Surname = sn;
            offers = doc;
        }
        public Visitors() { }
        public override string ToString() => "AcademGroup:\t" + AcademGroup + "\tName:\t" + Name + "\tSurname:\t" + Surname + $"\tHave a {offers.Offer.Count} books";

    }
}
