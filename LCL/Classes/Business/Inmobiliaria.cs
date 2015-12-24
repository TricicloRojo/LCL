using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCL.Classes.Business
{
    public class Inmobiliaria : IInmob
    {
        private String name { get; set; }
        private String email { get; set; }

        //Process Excel
        public void process()
        {
            throw new NotImplementedException();
        }

        //Send processed Excel by mail
        public void sendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
