using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace IGAv2._0.com.godder.animal
{
    [Serializable()]
    public class Goat : GoatAbstrast
    {
        public Goat(int id)
        {
            this.id = id;
            this.byteArgumentNum = 9;
            this.integerArgumentNum = 1;
            this.doubleArgumentNum = 14;
            this.boolArgumentNum = 3;
            this.stringArgumentNum = 2;
        }


        public static Goat load(string url)
        {
            FileStream fs = new FileStream(url, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Goat goat = (Goat)readBaseArgument(br);
            try
            {
                // read byte datas
                goat.sex = br.ReadByte();
                goat.cavel = br.ReadByte();
                goat.headType = br.ReadByte();
                goat.foreheadType = br.ReadByte();
                goat.earType = br.ReadByte();
                goat.nose = br.ReadByte();
                goat.limbs = br.ReadByte();
                goat.neck = br.ReadByte();
                goat.tailType = br.ReadByte();

                // read integer data
                goat.createNum = br.ReadInt32();

                // read double data
                goat.age = br.ReadDouble();
                goat.headLength = br.ReadDouble();
                goat.headWidth = br.ReadDouble();
                goat.earLength = br.ReadDouble();
                goat.earWidth = br.ReadDouble();
                goat.bodyLength = br.ReadDouble();
                goat.bodyHeight = br.ReadDouble();
                goat.bodyObliqueLength = br.ReadDouble();
                goat.weight = br.ReadDouble();
                goat.chestCircumference = br.ReadDouble();
                goat.bustWidth = br.ReadDouble();
                goat.bustDepth = br.ReadDouble();
                goat.tailLength = br.ReadDouble();
                goat.tailWidth = br.ReadDouble();

                // read bool datas
                goat.isMeat = br.ReadBoolean();
                goat.isWrinkle = br.ReadBoolean();
                goat.isBeard = br.ReadBoolean();

                // read string datas
                goat.coatColor = br.ReadString();
                goat.skinColor = br.ReadString();

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
            return goat;
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
                bw.Write(this.sex);
                bw.Write(this.cavel);
                bw.Write(this.headType);
                bw.Write(this.foreheadType);
                bw.Write(this.earType);
                bw.Write(this.nose);
                bw.Write(this.limbs);
                bw.Write(this.neck);
                bw.Write(this.tailType);

                // integer data
                bw.Write(this.createNum);

                // double data
                bw.Write(this.age);
                bw.Write(this.headLength);
                bw.Write(this.headWidth);
                bw.Write(this.earLength);
                bw.Write(this.earWidth);
                bw.Write(this.bodyLength);
                bw.Write(this.bodyHeight);
                bw.Write(this.bodyObliqueLength);
                bw.Write(this.weight);
                bw.Write(this.chestCircumference);
                bw.Write(this.bustWidth);
                bw.Write(this.bustDepth);
                bw.Write(this.tailLength);
                bw.Write(this.tailWidth);

                // bool data
                bw.Write(this.isMeat);
                bw.Write(this.isWrinkle);
                bw.Write(this.isBeard);

                // string data;
                bw.Write(this.coatColor);
                bw.Write(this.skinColor);

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
            headLength *= Math.Pow(10, change);
            headWidth *= Math.Pow(10, change);
            earLength *= Math.Pow(10, change);
            earWidth *= Math.Pow(10, change);
            tailLength *= Math.Pow(10, change);
            tailWidth *= Math.Pow(10, change);
            bodyLength *= Math.Pow(10, change);
            bodyHeight *= Math.Pow(10, change);
            bodyObliqueLength *= Math.Pow(10, change);
            chestCircumference *= Math.Pow(10, change);
            bustDepth *= Math.Pow(10, change);
            bustWidth *= Math.Pow(10, change);
            this.lengthUnit = unit;
        }

        public void changeWeightUnit(byte unit)
        {
            int change = Convert.ToInt32(this.weightUnit - unit);
            weight *= Math.Pow(1000, change);
            this.weightUnit = unit;
        }
    }
}
