using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BuildingExeption : Exception
    {
        private string message;

        public BuildingExeption(string exception)
        {
            message = exception;
        }

        public BuildingExeption() : base()
        {

        }

        public override string Message => message;
    }
}
