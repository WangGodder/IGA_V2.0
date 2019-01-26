using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public class Horse: HorseAbstract
    {
        public Horse(int id)
        {
            this.id = id;
            this.byteArgumentNum = 9;
            this.integerArgumentNum = 1;
            this.doubleArgumentNum = 14;
            this.boolArgumentNum = 3;
            this.stringArgumentNum = 2;
        }
    }
}
