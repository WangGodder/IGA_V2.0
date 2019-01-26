using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public class BeeAbstract: AnimalAbstract
    {
        protected static short type = 6;

        protected static string defaultUrl = "datas/bee/data/";

        public override short getType()
        {
            return type;
        }

    }
}
