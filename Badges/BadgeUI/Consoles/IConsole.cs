using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgeUI.Consoles
{

    public interface IConsole
    {
        // What do I need the console to do?

        void Clear();
        void WriteLine(string s);

        // Catch all for objects other than strings
        void WriteLine (object o);
        void Write(string s);
        void Write(object o);
        string ReadLine();
        ConsoleKeyInfo ReadKey();

    }
}