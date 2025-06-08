using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANOGRAFIA.clases
{
    public interface IEscritura
    {
        void lista_palabras();
        void registry_achievements_C(string pc);
        void registry_achievements(string ppm);
        void cambiarmodos();
        void iniciar(int inicio);
    }
}
