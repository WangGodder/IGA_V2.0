using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public abstract class HorseAbstract: AnimalAbstract
    {
        protected static short type = 3;

        protected static string defaultUrl = "datas/cattle/data/";

        public override short getType()
        {
            return type;
        }

    }
}
