using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Node
    {
        public Citizen Citizen
        {
            get; set;
        }
        public Node Next
        {
            get; set;
        }
        public Node Previous
        {
            get; set;
        }
        public int Index
        {
            get; set;
        }

    }
}
