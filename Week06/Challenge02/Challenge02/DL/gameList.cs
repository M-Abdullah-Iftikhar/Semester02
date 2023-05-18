using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02.DL
{
    public partial class gameList : Component
    {
        public gameList()
        {
            InitializeComponent();
        }

        public gameList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
