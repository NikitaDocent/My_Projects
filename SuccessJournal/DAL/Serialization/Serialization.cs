using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DAL.Serialization
{
    public class Serialize<T> : ISerialize<T> where T : class
    {
        private string fileName;
        BinaryFormatter binformat = new BinaryFormatter();
        public Serialize(string fileName)
        {
            this.fileName = fileName;
        }

        public void Save(T[] data)
        {
            using (FileStream fstream = new FileStream(fileName + ".dat", FileMode.Create))
            {
                    binformat.Serialize(fstream, data);
            }
        }

        public T[] Load()
        {

            using (FileStream fstream = new FileStream(fileName + ".dat", FileMode.Open))
            {
                return binformat.Deserialize(fstream) as T[];
            }
        }
    }
}
