using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    public class Cattle: CattleAbstract
    {
        public Cattle(int id)
        {
            this.id = id;
            this.byteArgumentNum = 3;
            this.integerArgumentNum = 0;
            this.doubleArgumentNum = 15;
            this.boolArgumentNum = 0;
            this.stringArgumentNum = 1;
        }

        public static Cattle load(string url)
        {
            FileStream fs = new FileStream(url, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Cattle cattle = (Cattle)readBaseArgument(br);
            try
            {
                // byte data
                cattle.gender = br.ReadByte();

                // double data
                cattle.age = br.ReadDouble();
                cattle.liveWeight = br.ReadDouble();
                cattle.carcassWeight = br.ReadDouble();
                cattle.pureMeat = br.ReadDouble();
                cattle.skinThickness = br.ReadDouble();
                cattle.boneWeight = br.ReadDouble();
                cattle.eyeMuscleArea = br.ReadDouble();
                cattle.slaughterRate = br.ReadDouble();
                cattle.meatBoneRatio = br.ReadDouble();
                cattle.bodyLength = br.ReadDouble();
                cattle.bodyHeight = br.ReadDouble();
                cattle.bodyObliqueLength = br.ReadDouble();
                cattle.chest = br.ReadDouble();
                cattle.tube = br.ReadDouble();
                cattle.bodyWeight = br.ReadDouble();

                // string data
                cattle.coatColor = br.ReadString();
            }
            catch (Exception e)
            {
                Console.WriteLine("data output error.");
                Console.WriteLine("error message: " + e.Message);
                Console.WriteLine("error source: " + e.Source);
                return null;
            }
            finally
            {
                br.Close();
                fs.Close();
            }
            return cattle;
        }

        public override bool save(string url)
        {
            FileStream fs = new FileStream(url, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);

            if (!this.saveBaseArgument(bw))
            {
                return false;
            }
            try
            {
                // byte data
                bw.Write(gender);

                // double data
                bw.Write(age);
                bw.Write(liveWeight);
                bw.Write(carcassWeight);
                bw.Write(pureMeat);
                bw.Write(skinThickness);
                bw.Write(boneWeight);
                bw.Write(eyeMuscleArea);
                bw.Write(slaughterRate);
                bw.Write(meatBoneRatio);
                bw.Write(bodyLength);
                bw.Write(bodyHeight);
                bw.Write(bodyObliqueLength);
                bw.Write(chest);
                bw.Write(tube);
                bw.Write(bodyWeight);

                // string data
                bw.Write(coatColor);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("data output error.");
                Console.WriteLine("error message: " + e.Message);
                Console.WriteLine("error source: " + e.Source);
            }
            finally
            {
                bw.Close();
                fs.Close();
            }
            return false;
        }

        public void changeLengthUnit(byte unit)
        {
            int change = Convert.ToInt32(this.lengthUnit - unit);
            tube *= Math.Pow(10, change);
            skinThickness *= Math.Pow(10, change);
            bodyLength *= Math.Pow(10, change);
            bodyHeight *= Math.Pow(10, change);
            bodyObliqueLength *= Math.Pow(10, change);
            chest *= Math.Pow(10, change);
            this.lengthUnit = unit;
        }

        public void changeWeightUnit(byte unit)
        {
            int change = Convert.ToInt32(this.weightUnit - unit);
            bodyWeight *= Math.Pow(1000, change);
            carcassWeight *= Math.Pow(1000, change);
            liveWeight *= Math.Pow(1000, change);
            boneWeight *= Math.Pow(1000, change);
            this.weightUnit = unit;
        }

    }
}
