using Hola_mundo.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hola_mundo
{
    static class Program
    {

        static void Main()
        {
            Game game = new Game(800, 600, "Hellow World");
        }
    }
}
