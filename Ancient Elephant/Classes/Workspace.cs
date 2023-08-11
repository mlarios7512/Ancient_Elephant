using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Ancient_Elephant.Classes
{
    public class Workspace
    {
        private Process[] Executables = null;


        public Workspace(Process[] processesToStart) 
        {
            Executables = processesToStart;
        }
    }
}
