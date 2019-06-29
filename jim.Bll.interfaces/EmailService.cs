using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.Bll.interfaces
{
    public interface EmailService
    {
        void Send(string cuerpoMensaje, params string[] destinatarios);
    }
}
