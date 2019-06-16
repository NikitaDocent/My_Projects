using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exeption
{
    public class SuccessExeption : Exception
    {
        private string message;

        public SuccessExeption(string exception)
        {
            message = exception;
        }

        public SuccessExeption() : base()
        {

        }

        public override string Message => message;
    }
}
