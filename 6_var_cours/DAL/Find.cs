using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Find
    {
        string result = "";
        public string found_client(ClientsList clientsList, string control_word)
        {
            result += clientsList.FindN(control_word);
            if (clientsList.FindN(control_word) == null)
                result += clientsList.FindSn(control_word);
            if (clientsList.FindSn(control_word) == null)
                result += clientsList.FindM(Convert.ToInt16(control_word));
            if (clientsList.FindM(Convert.ToInt16(control_word)) == null)
                result += clientsList.FindBa(control_word);
            if (clientsList.FindBa(control_word) == null)
                throw new ClientException("Control word not found in list!");
            return result;
        }
        public string found_buildings(BuildingsList buildingsList, string control_word)
        {
            result += buildingsList.FindAvaible(Convert.ToBoolean(control_word));
            if (buildingsList.FindAvaible(Convert.ToBoolean(control_word)) == null)
                result += buildingsList.FindCost(Convert.ToInt16(control_word));
            if(buildingsList.FindCost(Convert.ToInt16(control_word)) == null)
                result += buildingsList.FindType(control_word);
            if (buildingsList.FindType(control_word) == null)
                throw new BuildingExeption("Control word not found in list!");
            return result;
        }
        public string found_in_all(ClientsList clientsList, BuildingsList buildingsList, string control_word)
        {
            result += clientsList.FindN(control_word);
            if (clientsList.FindN(control_word) == null)
                result += clientsList.FindSn(control_word);
            if (clientsList.FindSn(control_word) == null)
                result += clientsList.FindM(Convert.ToInt16(control_word));
            if (clientsList.FindM(Convert.ToInt16(control_word)) == null)
                result += clientsList.FindBa(control_word);
            if (clientsList.FindBa(control_word) == null)
                result += buildingsList.FindAvaible(Convert.ToBoolean(control_word));
            if (buildingsList.FindAvaible(Convert.ToBoolean(control_word)) == null)
                result += buildingsList.FindCost(Convert.ToInt16(control_word));
            if (buildingsList.FindCost(Convert.ToInt16(control_word)) == null)
                result += buildingsList.FindType(control_word);
            if (buildingsList.FindType(control_word) == null)
                throw new Exception("Control word not found in list!");
            return result;
        }
        public string found_custom(ClientsList clientsList, BuildingsList buildingsList, string control_word,string second_world)
        {
            clientsList.FindN(control_word);
            if (clientsList.FindN(control_word) == null)
                result += clientsList.FindSn(control_word);
            if (clientsList.FindSn(control_word) == null)
                result += clientsList.FindM(Convert.ToInt16(control_word));
            if (clientsList.FindM(Convert.ToInt16(control_word)) == null)
                result += clientsList.FindBa(control_word);
            if (clientsList.FindBa(control_word) == null)
                result += buildingsList.FindAvaible(Convert.ToBoolean(control_word));
            if (buildingsList.FindAvaible(Convert.ToBoolean(control_word)) == null)
                result += buildingsList.FindCost(Convert.ToInt16(control_word));
            if (buildingsList.FindCost(Convert.ToInt16(control_word)) == null)
                result += buildingsList.FindType(control_word);
            if (buildingsList.FindType(control_word) == null)
                result += clientsList.FindN(second_world);
            if (clientsList.FindN(second_world) == null)
                result += clientsList.FindSn(second_world);
            if (clientsList.FindSn(second_world) == null)
                result += clientsList.FindM(Convert.ToInt16(second_world));
            if (clientsList.FindM(Convert.ToInt16(second_world)) == null)
                result += clientsList.FindBa(second_world);
            if (clientsList.FindBa(second_world) == null)
                result += buildingsList.FindAvaible(Convert.ToBoolean(second_world));
            if (buildingsList.FindAvaible(Convert.ToBoolean(second_world)) == null)
                result += buildingsList.FindCost(Convert.ToInt16(second_world));
            if (buildingsList.FindCost(Convert.ToInt16(second_world)) == null)
                result += buildingsList.FindType(second_world);
            if (buildingsList.FindType(second_world) == null)
                throw new Exception("Control word not found in list!");
            return result;
        }
    }
}
