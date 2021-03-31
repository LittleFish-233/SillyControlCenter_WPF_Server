using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyControlCenter_WPF_Server.daima
{
    public class Shuju_chuang
    {
        public Shuju_peizhi Kongzhi { get; set; }

        public List<Shuju_Shebei_PC> shuju_Shebei_PCs { get; set; }
        public List<Shuju_Shebei_AD> shuju_Shebei_ADs { get; set; }
    }
}
