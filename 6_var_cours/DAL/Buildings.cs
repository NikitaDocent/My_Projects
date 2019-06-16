using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Buildings
    {
        public int Cost { get; set; }
        public bool avaible { get; set; } = true;
        public string type_of_building { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param Cost="c">Cost of your building</param>
        /// <param Available="av">Can or can't bought this Building</param>
        /// <param type_of_building="numb_build">0 -  free Area,1,2,3- one,two,three room's</param>
        public Buildings(int c, string numb_build)
        {
            this.Cost = c;
            if(!Regex.IsMatch(numb_build, "[0 - 3]{1}"))
            throw new BuildingExeption("Wrong type");
            if (Convert.ToInt16(numb_build) == 0)
            {
                this.type_of_building = "0";
            } else if (Convert.ToInt16(numb_build) == 1)
            {
                this.type_of_building = "1";
            }
            else if (Convert.ToInt16(numb_build) == 2)
            {
                this.type_of_building = "2";
            }
            else if (Convert.ToInt16(numb_build) == 3)
            {
                this.type_of_building = "3";
            }
        }
        public Buildings(){      }
    }
}