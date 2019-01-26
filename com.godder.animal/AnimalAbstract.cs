using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IGAv2._0.com.godder.animal
{
    [Serializable()]
    public abstract class AnimalAbstract
    {
        // const parameters
        public const int GOAT_TYPE = 1;
        public const int CATTLE_TYPE = 2;
        public const int HORSE_TYPE = 3;
        public const int PIG_TYPE = 4;
        public const int POULTRY_TYPE = 5;
        public const int BEE_TYPE = 6;

        // base info
        protected int id;
        public bool isEncrypt = false;
        public string key = "";
        public byte lengthUnit = 0;      // cm
        public byte weightUnit = 0;      // g
        public List<string> imgUrl = new List<string>();
        public List<string> imgDepict = new List<string>();
        protected int byteArgumentNum;
        protected int integerArgumentNum;
        protected int doubleArgumentNum;
        protected int boolArgumentNum;
        protected int stringArgumentNum;

        // base argument
        public short year = 1970;
        public short month = 1;
        public short day = 1;
        public string species = "";
        public int country = 0;
        public string region = "";
        public int latitudeDegree = 0;
        public int latitudeMinute = 0;
        public double latitudeSecond = 0;
        public int longitudeDegree = 0;
        public int longitudeMinute = 0;
        public double longitudeSecond = 0;
        public string comment = "";

        // abstract methods
        public abstract Int16 getType();

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        protected static void readImg(BinaryReader br, AnimalAbstract animal)
        {
            int imgNum = br.ReadInt32();
            for (int i = 0; i < imgNum; i++)
            {
                animal.imgUrl.Add(br.ReadString());
            }
            for (int i = 0; i < imgNum; i++)
            {
                animal.imgDepict.Add(br.ReadString());
            }
        }

        protected void saveImg(BinaryWriter bw)
        {
            bw.Write(this.imgUrl.Count);
            foreach (String url in this.imgUrl)
            {
                bw.Write(url);
            }
            foreach (String depict in this.imgDepict)
            {
                bw.Write(depict);
            }
        }

        protected bool saveBaseArgument(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.getType());
                bw.Write(this.id);
                bw.Write(this.isEncrypt);
                bw.Write(this.key);
                bw.Write(this.year);
                bw.Write(this.month);
                bw.Write(this.day);
                bw.Write(this.species);
                bw.Write(this.country);
                bw.Write(this.region);
                bw.Write(this.latitudeDegree);
                bw.Write(this.latitudeMinute);
                bw.Write(this.latitudeSecond);
                bw.Write(this.longitudeDegree);
                bw.Write(this.longitudeMinute);
                bw.Write(this.longitudeSecond);
                bw.Write(this.comment);
                bw.Write(this.lengthUnit);
                bw.Write(this.weightUnit);
                saveImg(bw);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("data output error.");
                Console.WriteLine("error message: " + e.Message);
                Console.WriteLine("error source: " + e.Source);
            }
            return false;
        }

        protected static AnimalAbstract readBaseArgument(BinaryReader br)
        {
            int type = br.ReadInt16();
            int id = br.ReadInt32();
            AnimalAbstract animal;
            switch (type)
            {
                case GOAT_TYPE :
                    animal = new Goat(id);
                    break;
                case CATTLE_TYPE:
                    animal = new Cattle(id);
                    break;
                case HORSE_TYPE:
                    animal = new Horse(id);
                    break;
                case PIG_TYPE:
                    animal = new Pig(id);
                    break;
                case POULTRY_TYPE:
                    animal = new Poultry(id);
                    break;
                case BEE_TYPE:
                    animal = new Bee(id);
                    break;
                default:
                    return null;
            }

            // read base info
            animal.isEncrypt = br.ReadBoolean();
            animal.key = br.ReadString();
            animal.year = br.ReadInt16();
            animal.month = br.ReadInt16();
            animal.day = br.ReadInt16();
            animal.species = br.ReadString();
            animal.country = br.ReadInt32();
            animal.region = br.ReadString();
            animal.latitudeDegree = br.ReadInt32();
            animal.latitudeMinute = br.ReadInt32();
            animal.latitudeSecond = br.ReadDouble();
            animal.longitudeDegree = br.ReadInt32();
            animal.longitudeMinute = br.ReadInt32();
            animal.longitudeSecond = br.ReadDouble();
            animal.comment = br.ReadString();
            animal.lengthUnit = br.ReadByte();
            animal.weightUnit = br.ReadByte();
            readImg(br, animal);
            return animal;
        }


    }
}
