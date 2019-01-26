using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public abstract class PigAbstract: AnimalAbstract
    {
        protected static short type = 4;

        protected static string defaultUrl = "datas/pig/data/";

        public override short getType()
        {
            return type;
        }

    }
}
