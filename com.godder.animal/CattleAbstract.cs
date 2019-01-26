using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public abstract class CattleAbstract : AnimalAbstract
    {
        protected static short type = 2;

        protected static string defaultUrl = "datas/cattle/data/";

        public byte gender = 0;
        public double age = 0;
        public byte horn = 0;
        public byte shoulder = 0;
        public double liveWeight = 0;
        public double carcassWeight = 0;
        public double pureMeat = 0;
        public double skinThickness = 0;
        public double boneWeight = 0;
        public double eyeMuscleArea = 0;
        public double slaughterRate = 0;
        public double meatBoneRatio = 0;
        public double bodyLength = 0;
        public double bodyHeight = 0;
        public double bodyObliqueLength = 0;
        public double chest = 0;
        public double tube = 0;
        public double bodyWeight = 0;
        public string coatColor = "";

        public override short getType()
        {
            return type;
        }

        public abstract bool save(string url);
    }
}
