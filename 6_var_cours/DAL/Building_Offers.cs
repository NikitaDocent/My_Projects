using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Building_Offers
    {
        const int n = 5;
        public List<string> Offer { get; set; }

        public Building_Offers(Buildings[] buildings, Client client)
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (i >= n)
                    break;
                foreach (var a in buildings)
                    if (client.money < a.Cost)
                        a.avaible = false;
                    else { a.avaible = true; }
                Offer.Add("Type " + buildings[i].type_of_building + ",Cost " + buildings[i].Cost + "Avaible " + buildings[i].avaible + ";");
            }
        }
        public void AddOffer(Buildings building,int money)
        {
            if (Offer.Count >= n)
                throw new BuildingExeption("Can't add more Offer's");
                if (money < building.Cost)
                    building.avaible = false;
                else { building.avaible = true; }
            Offer.Add("Type " + building.type_of_building + ",Cost " + building.Cost + "Avaible " + building.avaible + ";");
        }
        public void RemoveOffer(int ind)
        {
            if (ind < 0 || ind >= Offer.Count)
                throw new BuildingExeption("Index out of range");
            Offer.RemoveAt(ind);
        }
        public Building_Offers() { }
    }
}
