using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Serialization;
using BLL.Exeption;
using BLL.Group;
using BLL.Student;
using BLL.Success;

namespace BLL.Group
{
    public class GroupService
    {
        List<Groups> groups { get; set; } = new List<Groups>();
        private Serialize<Groups> Datbase;

        public GroupService()
        {
            Datbase = new Serialize<Groups>("Group");
            try
            {
                var a = Datbase.Load();
                groups = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(groups.ToArray());
            }
        }
        public int Last
        {
            get { return groups.Count; }
        }
        public GroupService(Serialize<Groups> sr)
        {
            Datbase = sr;
            try
            {
                var a = Datbase.Load();
                groups = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(groups.ToArray());
            }
        }
        //Add Group
        public void Add(int ind) => groups.Add(new Groups
        {
            indGroup = ind < 0 ? throw new SuccessExeption("Index out of range") : ind
        });
        //Remove Group
        public void Remove(int ind)
        {
            if (ind < 0 || ind > groups.Count)
                throw new SuccessExeption("Index out of range");
            groups.RemoveAt(ind);
        }
        //Edit Group
        public void Edit(int ind,int numbofgroup)
        {
            if (ind < 0 || ind > groups.Count)
                throw new SuccessExeption("Index out of range");
            var a = groups[ind];
            a.indGroup = numbofgroup;
            groups[ind] = a;
        }
        //Get all groups
        public string GetAll()
        {
            string list = "";
            foreach (var a in groups)
                list += "Nuber:\t\t" + a.indGroup + "\tCount of members:\t\t"+a.Students.Count+";\n";
            return list;
        }
        //get needed group
        public Groups GetInfo(int ind) => ind < 0 || ind >= groups.Count ? null : groups[ind];
        //save
        public void Save()
        {
            Datbase.Save(groups.ToArray());
        }
    }
}
