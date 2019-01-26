using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGAv2._0.com.godder.animal
{
    [Serializable()]
    public abstract class GoatAbstrast : AnimalAbstract
    {
        private static short type = 1;
        
        protected static string defaultUrl = "datas/goat/data/";

        // special argument
        public byte sex = 0;
        public double age = 0.0;
        public int createNum = 0;
        public byte cavel = 0;
        public byte headType = 0;
        public double headLength = 0.0;
        public double headWidth = 0.0;
        public byte foreheadType = 0;
        public byte earType = 0;
        public double earLength = 0.0;
        public double earWidth = 0.0;
        public byte nose = 0;
        public byte limbs = 0;
        public byte neck = 0;
        public bool isMeat = false;
        public bool isWrinkle = false;
        public bool isBeard = false;
        public double bodyLength = 0.0;
        public double bodyHeight = 0.0;
        public double bodyObliqueLength = 0.0;
        public double weight = 0.0;
        public double chestCircumference = 0.0;
        public double bustWidth = 0.0;
        public double bustDepth = 0.0;
        public string coatColor = "";
        public string skinColor = "";
        public byte tailType = 0;
        public double tailLength = 0.0;
        public double tailWidth = 0.0;

        // methods
        public override Int16 getType()
        {
            return type;
        }

        // abstract methods
        public abstract bool save(string url);
    }
}
