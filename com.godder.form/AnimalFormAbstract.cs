using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IGAv2._0.com.godder.animal;
using System.Xml.Linq;

namespace IGAv2._0.com.godder.form
{
    public class AnimalFormAbstract: Form
    {
        protected Form mainStage;
        public AnimalAbstract animal = null;
        protected ConnectServerForm serverForm;
        public XDocument document;
        public String currentUrl;
        public int formWidth;
        public int formHeight;
        public string language = "en-US";
        public byte lengthUnit = 0;    // cm
        public byte weightUnit = 0;    // g
        public int imgNum = 0;
        public int currentimg = 0;
        public bool fileEncrypt = false;
        public bool autoVerify = false;
        public string defaultKey;
        public string fileKey = "";
        public string openUrl = "../data/goat/";
        public string saveUrl = "../data/goat/";
        public string imgUrl = "";
        public int port;
        public int listen;
        public string socketKey;
        public bool serveripV6 = false;
        public bool clientipV6 = false;
        public string socketUrl; 
        public List<string> connectHistory = new List<string>();
        public string emptyIdWarn = "Id can not be empty";
        public string wrongIdWarn = "Id must be an integer";
        public string overwriteWarn = "The original file will be overwritten";
        public string newFileWarn = "Please make sure you have save current file.";
        public string entorpyWarn = "This file is encrypted, you need input the key to get information";
        public string entorpyTitle = "File is encrypted";
        public string wrongKeyWarn = "key is wrong, you have no permission to open this file";
        public string wrongUrlWarn = "cannot find file by current url, the file has moved.";

        public AnimalFormAbstract()
        {
        }

        protected void readXmlConfig(XElement form)
        {
            XElement shape = form.Element("shape");
            this.formWidth = Convert.ToInt32(shape.Element("width").Value);
            this.formHeight = Convert.ToInt32(shape.Element("height").Value);
            this.language = form.Element("language").Value;
            XElement lengthUnit = form.Element("lengthUnit");
            this.lengthUnit = Convert.ToByte(lengthUnit.Value);
            XElement weightUnit = form.Element("weightUnit");
            this.weightUnit = Convert.ToByte(weightUnit.Value);
            XElement isSaveKey = form.Element("isSaveKey");
            this.fileEncrypt = Convert.ToBoolean(isSaveKey.Value);
            this.autoVerify = Convert.ToBoolean(form.Element("autoVerify").Value);
            this.defaultKey = form.Element("defaultKey").Value;
            if (fileEncrypt)
            {
                XElement saveKey = form.Element("saveKey");
                this.fileKey = saveKey.Value;
            }
            this.openUrl = form.Element("openUrl").Value;
            this.saveUrl = form.Element("saveUrl").Value;
            this.imgUrl = form.Element("imgUrl").Value;
            this.socketUrl = form.Element("socketUrl").Value;
            this.port = Convert.ToInt32(form.Element("port").Value);
            this.listen = Convert.ToInt32(form.Element("listen").Value);
            this.socketKey = form.Element("socketKey").Value;
            this.serveripV6 = Convert.ToBoolean(form.Element("serveripV6").Value);
            this.clientipV6 = Convert.ToBoolean(form.Element("clientipV6").Value);
            this.socketUrl = form.Element("socketUrl").Value;
            XElement connect = form.Element("connectHistory");
            foreach (XElement element in connect.Elements())
            {
                this.connectHistory.Add(element.Value);
            }
        }

        public virtual void loadAnimalInfo() { }
    }
}
