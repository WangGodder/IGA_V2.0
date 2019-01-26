using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public abstract class PoultryAbstract: AnimalAbstract
    {
        protected static short type = 5;

        protected static string defaultUrl = "datas/poultry/data/";

        public override short getType()
        {
            return type;
        }

    }
}
