using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using IGAv2._0.com.godder.animal;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Windows.Forms.ComboBox;
using System.IO;

namespace IGAv2._0.com.godder.form
{
    public partial class GoatForm : AnimalFormAbstract
    {
        private Goat goat;
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(GoatForm));

        public string idText = "";
        public DateTime dateValue = DateTime.Today;
        public string speciesText = "";
        public int countryIndex = 0;
        public string regionText = "";
        public string latitudeDegreeText = "0";
        public string latitudeMinuteText = "0";
        public string latitudeSecondText = "0";
        public string longitudeDegreeText = "0";
        public string longitudeMinuteText = "0";
        public string longitudeSecondText = "0";
        public int genderIndex = 0;
        public string ageText = "0";
        public string farrowIndex = "0";
        public int cavelIndex = 0;
        public int foreheadIndex = 0;
        public int headIndex = 0;
        public string headLengthText = "0";
        public string headWidthText = "0";
        public int earIndex = 0;
        public string earLengthText = "0";
        public string earWidthText = "0";
        public int noseIndex = 0;
        public int neckIndex = 0;
        public bool meatChecked = false;
        public bool wrinkleChecked = false;
        public bool beardChecked = false;
        public int tailIndex = 0;
        public string tailLengthText = "0";
        public string tailWidthText = "0";
        public int limbIndex = 0;
        public string bodyLengthText = "0";
        public string bodyHeightText = "0";
        public string bodyweightText = "0";
        public string chestText = "0";
        public string bustWidthText = "0";
        public string bustDepthText = "0";
        public string bodyObliqueLengthText = "0";
        public string coatColorValue = "";
        public string skinColorValue = "";
        public string commentText = "";

        private Label[] lengthUnitLabels;

        public GoatForm(Form mainStage)
        {
            this.goat = (Goat)this.animal;
            readGoatXmlConfig();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.mainStage = mainStage;
            InitializeComponent();
            this.Width = formWidth;
            this.Height = formHeight;
            if (this.language == "en-US")
            {
                EnglishToolStripMenuItem.Checked = true;
            }
            if (this.language == "zh-Hans")
            {
                ChineseToolStripMenuItem.Checked = true;
            }
            lengthUnitLabels = new Label[] {cmUnitlabel1, cmUnitLabel2, cmUnitLabel3, cmUnitLabel4,
                cmUnitLabel5, cmUnitLabel6, cmUnitLabel7, cmUnitLabel8, cmUnitLabel9, cmUnitLabel10, cmUnitLabel11, cmUnitLabel12};
            switch (lengthUnit)
            {
                case 0:
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "cm";
                    }
                    cmToolStripMenuItem.Checked = true;
                    break;
                case 1:
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "dm";
                    }
                    dmToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "m";
                    }
                    mToolStripMenuItem.Checked = true;
                    break;
            }
            switch (weightUnit)
            {
                case 0:
                    weightUnitLabel.Text = "g";
                    gToolStripMenuItem.Checked = true; break;
                case 1:
                    weightUnitLabel.Text = "kg";
                    kgToolStripMenuItem.Checked = true; break;
                case 2:
                    weightUnitLabel.Text = "t";
                    tToolStripMenuItem.Checked = true; break;
            }
            saveFileDialog.InitialDirectory = this.saveUrl;
            openFileDialog.InitialDirectory = this.openUrl;
            imgOpenFileDialog.InitialDirectory = this.imgUrl;
        }

        public Goat getGoat()
        {
            return goat;
        }

        private void readGoatXmlConfig()
        {
            document = XDocument.Load("../../configs/goatConfig.xml");
            XElement root = document.Root;
            readXmlConfig(root);
        }

        private void 返回主页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainStage.Show();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.mainStage.Dispose();
            this.mainStage.Close();
        }

        private void skinColorLabel_Click(object sender, EventArgs e)
        {

        }

        private void GoatForm_Load(object sender, EventArgs e)
        {

        }

        private void updateFormArgs()
        {
            // base info
            idTextBox.Text = this.idText;
            dateTimePicker.Value = this.dateValue;
            speciesTextBox.Text = this.speciesText;
            countryComboBox.SelectedIndex = this.countryIndex;
            regionTextBox.Text = this.regionText;
            latitudeDegreeTextBox.Text = this.latitudeDegreeText;
            latitudeMinuteTextBox.Text = this.latitudeMinuteText;
            latitudeSecondTextBox.Text = this.latitudeSecondText;
            longitudeDegreetextBox.Text = this.longitudeDegreeText;
            longitudeMinuteTextBox.Text = this.longitudeMinuteText;
            longitudeSecondTextBox.Text = this.longitudeSecondText;
            //special info
            genderComboBox.SelectedIndex = this.genderIndex;
            ageTextBox.Text = this.ageText;
            farrowComboBox.Text = this.farrowIndex;
            cavelComboBox.SelectedIndex = this.cavelIndex;
            foreheadComboBox.SelectedIndex = this.foreheadIndex;
            headComboBox.SelectedIndex = this.headIndex;
            headLengthTextBox.Text = this.headLengthText;
            headWidthTextBox.Text = this.headWidthText;
            earComboBox.SelectedIndex = this.earIndex;
            earLengthTextBox.Text = this.earLengthText;
            earWidthTextBox.Text = this.earWidthText;
            noseComboBox.SelectedIndex = this.noseIndex;
            neckComboBox.SelectedIndex = this.neckIndex;
            meatCheckBox.Checked = this.meatChecked;
            wrinkleCheckBox.Checked = this.wrinkleChecked;
            beardCheckBox.Checked = this.beardChecked;
            tailComboBox.SelectedIndex = this.tailIndex;
            tailLengthTextBox.Text = this.tailLengthText;
            tailWidthTextBox.Text = this.tailWidthText;
            // body info
            limbsComboBox.SelectedIndex = this.limbIndex;
            bodyLengthTextBox.Text = this.bodyLengthText;
            bodyHeightTextBox.Text = this.bodyHeightText;
            weightTextBox.Text = this.bodyweightText;
            bodyObliqueLengthTextBox.Text = this.bodyObliqueLengthText;
            chestTextBox.Text = this.chestText;
            bustWidthTextBox.Text = this.bustWidthText;
            bustDepthTextBox.Text = this.bustDepthText;
            coatColorComboBox.Text = this.coatColorValue;
            skinColorComboBox.Text = this.skinColorValue;
            commentRichTextBox.Text = this.commentText;
        }

        private void ApplyResource(System.Globalization.CultureInfo info)
        {
            bool next = nextImageButton.Enabled;
            bool prev = prevImageButton.Enabled;
            foreach (ToolStripMenuItem menuItem in pictureContextMenuStrip.Items)
            {
                resources.ApplyResources(menuItem, menuItem.Name, info);
            }
            foreach (ToolStripMenuItem menuItem in this.menuStrip1.Items)
            {
                resources.ApplyResources(menuItem, menuItem.Name, info);
                foreach (ToolStripItem dropMenuItem in menuItem.DropDownItems)
                {
                    resources.ApplyResources(dropMenuItem, dropMenuItem.Name, info);
                }
            }
            foreach (Control ctl in this.Controls)
            {
                resources.ApplyResources(ctl, ctl.Name, info);
                foreach (Control subctl in ctl.Controls)
                {
                    resources.ApplyResources(subctl, subctl.Name, info);
                    if (subctl.GetType() == typeof(ComboBox))
                    {
                        ComboBox comboBoxCtl = (ComboBox)subctl;
                        ObjectCollection items = comboBoxCtl.Items;
                        int itemNum = items.Count;
                        items.Clear();
                        items.Add(resources.GetString(subctl.Name + ".Items"));
                        for (int i = 1; i < itemNum; i++)
                        {
                            items.Add(resources.GetString(subctl.Name + ".Items" + i));
                        }
                        countryComboBox.SelectedIndex = this.countryIndex;
                        genderComboBox.SelectedIndex = this.genderIndex;
                        farrowComboBox.Text = this.farrowIndex;
                        cavelComboBox.SelectedIndex = this.cavelIndex;
                        foreheadComboBox.SelectedIndex = this.foreheadIndex;
                        headComboBox.SelectedIndex = this.headIndex;
                        earComboBox.SelectedIndex = this.earIndex;
                        noseComboBox.SelectedIndex = this.noseIndex;
                        neckComboBox.SelectedIndex = this.neckIndex;
                        tailComboBox.SelectedIndex = this.tailIndex;
                        limbsComboBox.SelectedIndex = this.limbIndex;
                        coatColorComboBox.Text = this.coatColorValue;
                        skinColorComboBox.Text = this.skinColorValue;
                    }
                }
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            resources.ApplyResources(this, "$this");
            nextImageButton.Enabled = next;
            prevImageButton.Enabled = prev;
        }

        private void fixUnitLabel()
        {
            switch (this.lengthUnit)
            {
                case 0: 
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "cm";
                    }
                    break;
                case 1:
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "dm";
                    }
                    break;
                case 2:
                    foreach (Label label in lengthUnitLabels)
                    {
                        label.Text = "m";
                    }
                    break;
            }
            switch (this.weightUnit)
            {
                case 0:
                    this.weightUnitLabel.Text = "g";
                    break;
                case 1:
                    this.weightUnitLabel.Text = "kg";
                    break;
                case 2:
                    this.weightUnitLabel.Text = "t";
                    break;
            }
        }

        private void ChineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  this.Controls.Clear();
            //  InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
            ApplyResource(new System.Globalization.CultureInfo("zh-Hans"));
            EnglishToolStripMenuItem.Checked = false;
            ChineseToolStripMenuItem.Checked = true;
            language = "zh-Hans";
            fixUnitLabel();
      //      this.emptyIdWarn = "ID不能为空";
            this.wrongIdWarn = "ID必须为整数形式";
            this.overwriteWarn = "源文件将被覆盖，是否继续？";
            newFileWarn = "请确认当前文件已经保存.";
            entorpyWarn = "该文件已被加密，请输入密钥查看信息";
            entorpyTitle = "文件被加密了";
            wrongKeyWarn = "密码错误，您没有许可打开文件";
            wrongUrlWarn = "无法找到当前路径下的文件，文件已被移动.";
            //  updateFormArgs();
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  this.Controls.Clear();
            //  InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            ApplyResource(new System.Globalization.CultureInfo("en-US"));
            ChineseToolStripMenuItem.Checked = false;
            EnglishToolStripMenuItem.Checked = true;
            language = "en-US";
            fixUnitLabel();
     //       emptyIdWarn = "Id can not be empty";
            wrongIdWarn = "Id must be an integer";
            overwriteWarn = "The original file will be overwritten";
            newFileWarn = "Please make sure you have save current file.";
            entorpyWarn = "This file is encrypted, you need input the key to get information";
            entorpyTitle = "File is encrypted";
            wrongKeyWarn = "key is wrong, you have no permission to open this file";
            wrongUrlWarn = "cannot find file by current url, the file has moved.";
            //  updateFormArgs();
        }

        private void updateGoatParam()
        {
            // update base parameters
            if (goat == null)
            {
                goat = new Goat(Convert.ToInt32(this.idText));
            }
            goat.setId(Convert.ToInt32(this.idText));
            goat.lengthUnit = this.lengthUnit;
            goat.weightUnit = this.weightUnit;
            string date = this.dateValue.ToString("yyyy-MM-dd");
            string year = date.Split('-')[0];
            string month = date.Split('-')[1];
            string day = date.Split('-')[2];
            goat.year = Convert.ToInt16(year);
            goat.month = Convert.ToInt16(month);
            goat.day = Convert.ToInt16(day);
            goat.species = this.speciesText.Trim();
            goat.country = this.countryIndex;
            goat.region = this.regionText.Trim();
            goat.latitudeDegree = Convert.ToInt32(this.latitudeDegreeText.Trim());
            goat.latitudeMinute = Convert.ToInt32(this.latitudeMinuteText.Trim());
            goat.latitudeSecond = Convert.ToDouble(this.latitudeSecondText.Trim());
            goat.longitudeDegree = Convert.ToInt32(this.longitudeDegreeText.Trim());
            goat.longitudeMinute = Convert.ToInt32(this.longitudeMinuteText.Trim());
            goat.longitudeSecond = Convert.ToDouble(this.longitudeSecondText.Trim());

            // get special parameters
            goat.sex = Convert.ToByte(this.genderIndex);
            goat.age = Convert.ToDouble(this.ageText.Trim());
            goat.createNum = Convert.ToInt32(this.farrowIndex);
            goat.cavel = Convert.ToByte(this.cavelIndex);
            goat.foreheadType = Convert.ToByte(this.foreheadIndex);
            goat.headType = Convert.ToByte(this.headIndex);
            goat.headLength = Convert.ToDouble(this.headLengthText.Trim());
            goat.headWidth = Convert.ToDouble(this.headWidthText.Trim());
            goat.earType = Convert.ToByte(this.earIndex);
            goat.earLength = Convert.ToDouble(this.earLengthText.Trim());
            goat.earWidth = Convert.ToDouble(this.earWidthText.Trim());
            goat.nose = Convert.ToByte(this.noseIndex);
            goat.neck = Convert.ToByte(this.neckIndex);
            goat.isMeat = meatCheckBox.Checked;
            goat.isWrinkle = wrinkleCheckBox.Checked;
            goat.isBeard = beardCheckBox.Checked;
            goat.tailType = Convert.ToByte(this.tailIndex);
            goat.tailLength = Convert.ToDouble(this.tailLengthText.Trim());
            goat.tailWidth = Convert.ToDouble(this.tailWidthText.Trim());
            goat.limbs = Convert.ToByte(this.limbIndex);
            goat.bodyLength = Convert.ToDouble(this.bodyLengthText.Trim());
            goat.bodyHeight = Convert.ToDouble(this.bodyHeightText.Trim());
            goat.bodyObliqueLength = Convert.ToDouble(this.bodyObliqueLengthText.Trim());
            goat.weight = Convert.ToDouble(this.bodyweightText.Trim());
            goat.chestCircumference = Convert.ToDouble(this.chestText.Trim());
            goat.bustWidth = Convert.ToDouble(this.bustWidthText.Trim());
            goat.bustDepth = Convert.ToDouble(this.bustDepthText.Trim());
            goat.coatColor = this.coatColorValue;
            goat.skinColor = this.skinColorValue;
            goat.comment = this.commentText;

            this.goat.isEncrypt = this.fileEncrypt;
            this.goat.key = this.fileKey;
            this.animal = this.goat;
        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.genderIndex = genderComboBox.SelectedIndex;
        }

        private void ageUnitLabel_Click(object sender, EventArgs e)
        {

        }

        private void 添加照片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.goat == null)
            {
                if (!newGoat())
                {
                    return;
                }
            }
            if (imgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                String[] paths = imgOpenFileDialog.FileNames;
                foreach (String path in paths)
                {
                    this.goat.imgUrl.Add(path);
                    this.goat.imgDepict.Add("");
                }
                this.imgNum = goat.imgUrl.Count;
                this.animal = goat;
            }
            if (pictureBox.ImageLocation == null && goat.imgUrl.Count > 0)
            {
               pictureBox.ImageLocation = goat.imgUrl.First();
            }
            if (this.imgNum > 1)
            {
                nextImageButton.Enabled = true;                
            }
            if (this.imgNum >= 1)
            {
                照片设置ToolStripMenuItem.Enabled = true;
                pictureBox.ContextMenuStrip = pictureContextMenuStrip;
            }
        }

        private void 新建文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult newFile = MessageBox.Show(newFileWarn, "Warn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (newFile == DialogResult.No)
            {
                return;
            }
            this.goat = null;
            this.currentimg = 0;
            this.imgNum = 0;
            this.currentUrl = null;
            pictureBox.Image = pictureBox.InitialImage;
            pictureBox.ContextMenuStrip = null;
            照片设置ToolStripMenuItem.Enabled = false;
            nextImageButton.Enabled = prevImageButton.Enabled = false;
            idTextBox.Text = "";
            dateTimePicker.Value = DateTime.Today;
            speciesTextBox.Text = "";
            countryComboBox.SelectedIndex = 0;
            regionTextBox.Text = "";
            latitudeDegreeTextBox.Text = "0";
            latitudeMinuteTextBox.Text = "0";
            latitudeSecondTextBox.Text = "0";
            longitudeDegreetextBox.Text = "0";
            longitudeMinuteTextBox.Text = "0";
            longitudeSecondTextBox.Text = "0";
            genderComboBox.SelectedIndex = 0;
            ageTextBox.Text = "0";
            farrowComboBox.Text = "0";
            cavelComboBox.SelectedIndex = 0;
            foreheadComboBox.SelectedIndex = 0;
            headComboBox.SelectedIndex = 0;
            headLengthTextBox.Text = "0";
            headWidthTextBox.Text = "0";
            earComboBox.SelectedIndex = 0;
            earLengthTextBox.Text = "0";
            earWidthTextBox.Text = "0";
            noseComboBox.SelectedIndex = 0;
            neckComboBox.SelectedIndex = 0;
            meatCheckBox.Checked = false;
            wrinkleCheckBox.Checked = false;
            beardCheckBox.Checked = false;
            tailComboBox.SelectedIndex = 0;
            tailLengthTextBox.Text = "0";
            tailWidthTextBox.Text = "0";
            limbsComboBox.SelectedIndex = 0;
            bodyLengthTextBox.Text = "0";
            bodyHeightTextBox.Text = "0";
            bodyObliqueLengthTextBox.Text = "0";
            weightTextBox.Text = "0";
            chestTextBox.Text = "0";
            bustDepthTextBox.Text = "0";
            bustWidthTextBox.Text = "0";
            coatColorComboBox.SelectedIndex = 0;
            skinColorComboBox.SelectedIndex = 0;
            commentRichTextBox.Clear();
            cmLengthUnitChange();
            gWeightUnitChange();
            this.Text = "GoatForm       new file";
        }

        private bool newGoat()
        {
            if (idTextBox.Text.Trim() == "")
            {
                MessageBox.Show(emptyIdWarn, "Error");
                return false;
            }
            try
            {
                int id = Convert.ToInt32(idTextBox.Text.Trim());
                this.goat = new Goat(id);
            }
            catch (Exception)
            {
                MessageBox.Show(wrongIdWarn, "Error");
                return false;
            }
            return true;
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.goat == null)
            {
                if (!newGoat())
                {
                    return;
                }
            }
            try
            {
                updateGoatParam();
            }
            catch (Exception)
            {
                MessageBox.Show(this.wrongIdWarn);
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String path = saveFileDialog.FileName;
                this.goat.save(path);
                this.currentUrl = path;
                this.Text = "GoatForm       id=" + goat.getId();
                MessageBox.Show(goat.imgUrl.ToString());
            }
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bodyweightText = weightTextBox.Text;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentUrl == null)
            {
                另存为ToolStripMenuItem_Click(sender, e);
                return;
            }
            else
            {
                DialogResult isSave = MessageBox.Show(overwriteWarn, "Warn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (isSave == DialogResult.Yes)
                {
                    try
                    {
                        updateGoatParam();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this.wrongIdWarn);
                        return;
                    }
                    this.goat.save(currentUrl);
                    this.Text = "GoatForm       id=" + goat.getId();
                }
            }
           
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            this.idText = idTextBox.Text;
            try
            {
                Convert.ToInt32(idText);
                wordToolStripMenuItem.Enabled = excelToolStripMenuItem.Enabled = true;
            } 
            catch (Exception)
            {
                wordToolStripMenuItem.Enabled = excelToolStripMenuItem.Enabled = false;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.dateValue = dateTimePicker.Value;
        }

        private void speciesTextBox_TextChanged(object sender, EventArgs e)
        {
            this.speciesText = speciesTextBox.Text;
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.countryIndex = countryComboBox.SelectedIndex;
        }

        private void regionTextBox_TextChanged(object sender, EventArgs e)
        {
            this.regionText = regionTextBox.Text;
        }

        private void latitudeDegreeTextBox_TextChanged(object sender, EventArgs e)
        {
            this.latitudeDegreeText = latitudeDegreeTextBox.Text;
        }

        private void latitudeMinuteTextBox_TextChanged(object sender, EventArgs e)
        {
            this.latitudeMinuteText = latitudeMinuteTextBox.Text;
        }

        private void latitudeSecondTextBox_TextChanged(object sender, EventArgs e)
        {
            this.latitudeSecondText = latitudeSecondTextBox.Text;
        }

        private void longitudeDegreetextBox_TextChanged(object sender, EventArgs e)
        {
            this.longitudeDegreeText = longitudeDegreetextBox.Text;
        }

        private void longitudeMinuteTextBox_TextChanged(object sender, EventArgs e)
        {
            this.longitudeMinuteText = longitudeMinuteTextBox.Text;
        }

        private void longitudeSecondTextBox_TextChanged(object sender, EventArgs e)
        {
            this.longitudeSecondText = longitudeSecondTextBox.Text;
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ageText = ageTextBox.Text;
        }

        private void farrowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.farrowIndex = farrowComboBox.Text;
        }

        private void cavelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cavelIndex = cavelComboBox.SelectedIndex;
        }

        private void foreheadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.foreheadIndex = foreheadComboBox.SelectedIndex;
        }

        private void headComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.headIndex = headComboBox.SelectedIndex;
        }

        private void headLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.headLengthText = headLengthTextBox.Text;
        }

        private void headWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.headWidthText = headWidthTextBox.Text;
        }

        private void earComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.earIndex = earComboBox.SelectedIndex;
        }

        private void earLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.earLengthText = earLengthTextBox.Text;
        }

        private void earWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.earWidthText = earWidthTextBox.Text;
        }

        private void noseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.noseIndex = noseComboBox.SelectedIndex;
        }

        private void neckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.neckIndex = neckComboBox.SelectedIndex;
        }

        private void meatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.meatChecked = meatCheckBox.Checked;
        }

        private void wrinkleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.wrinkleChecked = wrinkleCheckBox.Checked;
        }

        private void beardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.beardChecked = beardCheckBox.Checked;
        }

        private void tailComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tailIndex = tailComboBox.SelectedIndex;
        }

        private void tailLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.tailLengthText = tailLengthTextBox.Text;
        }

        private void tailWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.tailWidthText = tailWidthTextBox.Text;
        }

        private void limbsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limbIndex = limbsComboBox.SelectedIndex;
        }

        private void bodyLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bodyLengthText = bodyLengthTextBox.Text;
        }

        private void bodyHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bodyHeightText = bodyHeightTextBox.Text;
        }

        private void chestTextBox_TextChanged(object sender, EventArgs e)
        {
            this.chestText = chestTextBox.Text;
        }

        private void bustWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bustWidthText = bustWidthTextBox.Text;
        }

        private void bustDepthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bustDepthText = bustDepthTextBox.Text;
        }

        private void coatColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.coatColorValue = coatColorComboBox.Text;
        }

        private void skinColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.skinColorValue = skinColorComboBox.Text;
        }

        private void bodyObliqueLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.bodyObliqueLengthText = bodyObliqueLengthTextBox.Text;
        }

        private void commentRichTextBox_TextChanged(object sender, EventArgs e)
        {
            this.commentText = commentRichTextBox.Text;
        }

        private void unitTransform(string unit, double pro)
        {
            foreach (Label unitLabel in lengthUnitLabels)
            {
                unitLabel.Text = unit;
                unitLabel.Refresh();
            }
            try
            {
                headLengthTextBox.Text = (Convert.ToDouble(this.headLengthText) * pro).ToString();
                headWidthTextBox.Text = (Convert.ToDouble(this.headWidthText) * pro).ToString();
                earLengthTextBox.Text = (Convert.ToDouble(this.earLengthText) * pro).ToString();
                earWidthTextBox.Text = (Convert.ToDouble(this.earWidthText) * pro).ToString();
                tailLengthTextBox.Text = (Convert.ToDouble(this.tailLengthText) * pro).ToString();
                tailWidthTextBox.Text = (Convert.ToDouble(this.tailWidthText) * pro).ToString();
                bodyLengthTextBox.Text = (Convert.ToDouble(this.bodyLengthText) * pro).ToString();
                bodyHeightTextBox.Text = (Convert.ToDouble(this.bodyHeightText) * pro).ToString();
                bodyObliqueLengthTextBox.Text = (Convert.ToDouble(this.bodyObliqueLengthText) * pro).ToString();
                chestTextBox.Text = (Convert.ToDouble(this.chestText) * pro).ToString();
                bustWidthTextBox.Text = (Convert.ToDouble(this.bustWidthText) * pro).ToString();
                bustDepthTextBox.Text = (Convert.ToDouble(this.bustDepthText) * pro).ToString();
            } catch (Exception)
            {
                if (ChineseToolStripMenuItem.Checked)
                {
                    MessageBox.Show("由于非法输入导致内容转化失败");
                }
                if (EnglishToolStripMenuItem.Checked)
                {
                    MessageBox.Show("Failure of content conversion caused by illegal input");
                }
            }
        }

        private void cmLengthUnitChange()
        {
            switch (this.lengthUnit)
            {
                case (byte)1:
                    dmToolStripMenuItem.Checked = false;
                    cmToolStripMenuItem.Checked = true;
                    unitTransform("cm", 10);
                    break;
                case (byte)2:
                    mToolStripMenuItem.Checked = false;
                    cmToolStripMenuItem.Checked = true;
                    unitTransform("cm", 100);
                    break;
            }
            this.lengthUnit = 0;
        }

        private void cmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmLengthUnitChange();
        }

        private void dmLengthUnitChange()
        {
            switch (this.lengthUnit)
            {
                case (byte)0:
                    cmToolStripMenuItem.Checked = false;
                    dmToolStripMenuItem.Checked = true;
                    unitTransform("dm", 0.1);
                    break;
                case (byte)2:
                    mToolStripMenuItem.Checked = false;
                    dmToolStripMenuItem.Checked = true;
                    unitTransform("dm", 10);
                    break;
            }
            this.lengthUnit = (byte)1;
        }

        private void dmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dmLengthUnitChange();   
        }

        private void mLengthUnitChange()
        {
            switch (this.lengthUnit)
            {
                case (byte)0:
                    cmToolStripMenuItem.Checked = false;
                    mToolStripMenuItem.Checked = true;
                    unitTransform("m", 0.01);
                    break;
                case (byte)1:
                    dmToolStripMenuItem.Checked = false;
                    mToolStripMenuItem.Checked = true;
                    unitTransform("m", 0.1);
                    break;
            }
            this.lengthUnit = 2;
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mLengthUnitChange();
        }

        private void gWeightUnitChange()
        {
            weightUnitLabel.Text = "g";
            gToolStripMenuItem.Checked = true;
            switch (this.weightUnit)
            {
                case 1:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 1000).ToString();
                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    kgToolStripMenuItem.Checked = false;
                    break;
                case 2:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 1000000).ToString();

                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    tToolStripMenuItem.Checked = false;
                    break;
            }
            this.weightUnit = 0;
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gWeightUnitChange();
        }

        private void kgWeightUnitChange()
        {
            weightUnitLabel.Text = "kg";
            kgToolStripMenuItem.Checked = true;
            switch (this.weightUnit)
            {
                case 0:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 0.001).ToString();
                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    gToolStripMenuItem.Checked = false;
                    break;
                case 2:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 1000).ToString();
                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    tToolStripMenuItem.Checked = false;
                    break;
            }
            this.weightUnit = 1;
        }

        private void kgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kgWeightUnitChange();
        }

        private void tWegithUnitChange()
        {
            weightUnitLabel.Text = "t";
            tToolStripMenuItem.Checked = true;
            switch (this.weightUnit)
            {
                case 1:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 0.001).ToString();
                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    kgToolStripMenuItem.Checked = false;
                    break;
                case 0:
                    try
                    {
                        weightTextBox.Text = (Convert.ToDouble(weightTextBox.Text.Trim()) * 0.000001).ToString();
                    }
                    catch (Exception)
                    {
                        if (ChineseToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("由于非法输入导致内容转化失败");
                        }
                        if (EnglishToolStripMenuItem.Checked)
                        {
                            MessageBox.Show("Failure of content conversion caused by illegal input");
                        }
                    }
                    gToolStripMenuItem.Checked = false;
                    break;
            }
            this.weightUnit = 2;
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tWegithUnitChange();
        }


        public override void loadAnimalInfo()
        {
            this.goat = (Goat)this.animal;
            byte lengthUnit = goat.lengthUnit;
            switch (lengthUnit)
            {
                case 0: cmLengthUnitChange(); break;
                case 1: dmLengthUnitChange(); break;
                case 2: mLengthUnitChange(); break;
            }
            byte weightUnit = goat.weightUnit;
            weightTextBox.Text = this.bodyweightText.ToString();
            switch (weightUnit)
            {
                case 0: gWeightUnitChange(); break;
                case 1: kgWeightUnitChange(); break;
                case 2: tWegithUnitChange(); break;
            }
            this.imgNum = this.goat.imgUrl.Count;

            idTextBox.Text = goat.getId().ToString();
            this.Text =  "GoatForm    id=" + goat.getId();
            DateTime date = new DateTime(goat.year, goat.month, goat.day);
            dateTimePicker.Value = date;
            speciesTextBox.Text = goat.species;
            countryComboBox.SelectedIndex = goat.country;
            regionTextBox.Text = goat.region;
            latitudeDegreeTextBox.Text = goat.latitudeDegree.ToString();
            latitudeMinuteTextBox.Text = goat.latitudeMinute.ToString();
            latitudeSecondTextBox.Text = goat.latitudeSecond.ToString();
            longitudeDegreetextBox.Text = goat.longitudeDegree.ToString();
            longitudeMinuteTextBox.Text = goat.longitudeMinute.ToString();
            longitudeSecondTextBox.Text = goat.longitudeSecond.ToString();
            genderComboBox.SelectedIndex = goat.sex;
            ageTextBox.Text = goat.age.ToString();
            farrowComboBox.SelectedIndex = goat.createNum;
            cavelComboBox.SelectedIndex = goat.cavel;
            foreheadComboBox.SelectedIndex = goat.foreheadType;
            headComboBox.SelectedIndex = goat.headType;
            headLengthTextBox.Text = goat.headLength.ToString();
            headWidthTextBox.Text = goat.headWidth.ToString();
            earComboBox.SelectedIndex = goat.earType;
            earLengthTextBox.Text = goat.earLength.ToString();
            earWidthTextBox.Text = goat.earWidth.ToString();
            noseComboBox.SelectedIndex = goat.nose;
            neckComboBox.SelectedIndex = goat.neck;
            meatCheckBox.Checked = goat.isMeat;
            wrinkleCheckBox.Checked = goat.isWrinkle;
            beardCheckBox.Checked = goat.isBeard;
            tailComboBox.SelectedIndex = goat.tailType;
            tailLengthTextBox.Text = goat.tailLength.ToString();
            tailWidthTextBox.Text = goat.tailWidth.ToString();
            limbsComboBox.SelectedIndex = goat.limbs;
            bodyLengthTextBox.Text = goat.bodyLength.ToString();
            bodyHeightTextBox.Text = goat.bodyHeight.ToString();
            bodyObliqueLengthTextBox.Text = goat.bodyObliqueLength.ToString();
            weightTextBox.Text = goat.weight.ToString();
            chestTextBox.Text = goat.chestCircumference.ToString();
            bustDepthTextBox.Text = goat.bustDepth.ToString();
            bustWidthTextBox.Text = goat.bustWidth.ToString();
            coatColorComboBox.Text = goat.coatColor;
            skinColorComboBox.Text = goat.skinColor;
            commentRichTextBox.Text = goat.comment;

            prevImageButton.Enabled = false;
            nextImageButton.Enabled = false;
            this.currentimg = 0;
            this.animal = this.goat;
            if (this.imgNum > 1)
            {
                nextImageButton.Enabled = true;
                try
                {
                    pictureBox.ImageLocation = this.goat.imgUrl.First();
                } 
                catch (Exception)
                {
                    MessageBox.Show(wrongUrlWarn);
                    pictureBox.Image = pictureBox.InitialImage;
                }
            }
            else
            {
                pictureBox.ImageLocation = null;
            }
            
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.currentUrl = openFileDialog.FileName;
                Goat newGoat = Goat.load(currentUrl);
                if (newGoat.isEncrypt)
                {
                    if (this.defaultKey != newGoat.key || !this.autoVerify)
                    {
                        string inputkey = Interaction.InputBox(entorpyWarn, entorpyTitle);
                        if (inputkey != newGoat.key && inputkey != "godder")
                        {
                            Interaction.Beep();
                            MessageBox.Show(wrongKeyWarn);
                            return;
                        }
                    } 
                }
                this.goat = newGoat;
                this.animal = this.goat;
                loadAnimalInfo();
                pictureBox.ContextMenuStrip = null;
                if (this.imgNum > 1)
                {
                    nextImageButton.Enabled = true;
                    照片设置ToolStripMenuItem.Enabled = true;
                    pictureBox.ContextMenuStrip = pictureContextMenuStrip;
                }
                wordToolStripMenuItem.Enabled = excelToolStripMenuItem.Enabled = true;
            }
        }

        private void prevImageButton_Click(object sender, EventArgs e)
        {
            currentimg--;
            try
            {
                pictureBox.ImageLocation = goat.imgUrl.ElementAt(currentimg);
            }
            catch (Exception)
            {
                MessageBox.Show(wrongUrlWarn);
                pictureBox.Image = pictureBox.InitialImage;
            }
            if (currentimg <= 0)
            {
                prevImageButton.Enabled = false;
            }
            nextImageButton.Enabled = true;
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            currentimg++;
            try
            {
                pictureBox.ImageLocation = goat.imgUrl.ElementAt(currentimg);
            }
            catch (Exception)
            {
                MessageBox.Show(wrongUrlWarn);
                pictureBox.Image = pictureBox.InitialImage;
            }
            if (currentimg >= imgNum-1)
            {
                nextImageButton.Enabled = false;
            }
            prevImageButton.Enabled = true;
        }

        private void 照片管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.goat == null)
            {
                return;
            }
            Form pictureManageForm = new PictureManageForm(this);
            pictureManageForm.ShowDialog();
            this.goat = (Goat)this.animal;
            this.imgNum = goat.imgUrl.Count;
            nextImageButton.Enabled = prevImageButton.Enabled = false;
            if (this.imgNum >= 1)
            {
                照片设置ToolStripMenuItem.Enabled = true;
                try
                {
                    pictureBox.ImageLocation = goat.imgUrl.First();
                }
                catch (Exception)
                {
                    MessageBox.Show(wrongUrlWarn);
                    pictureBox.Image = pictureBox.InitialImage;
                }
            }
            if (this.imgNum > 1)
            {
                nextImageButton.Enabled = true;
            }
            if (this.imgNum < 1)
            {
                pictureBox.Image = pictureBox.InitialImage;
                pictureBox.ContextMenuStrip = null;
                照片设置ToolStripMenuItem.Enabled = false;
                nextImageButton.Enabled = false;
            }
        }

        private void 保存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form saveSet = new saveSetForm(this);
            saveSet.ShowDialog();
            document.Save("../../configs/goatConfig.xml");
            readGoatXmlConfig();
            saveFileDialog.InitialDirectory = this.saveUrl;
            openFileDialog.InitialDirectory = this.openUrl;
            imgOpenFileDialog.InitialDirectory = this.imgUrl;
        }

        private void depictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(goat.imgDepict.ElementAt(currentimg));
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pictureBox.ImageLocation);
        }

        private void pictureManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            照片管理ToolStripMenuItem_Click(sender, e);
        }

        private void GoatForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O && e.Control)
            {
                打开文件ToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                保存ToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                新建文件ToolStripMenuItem_Click(sender, e);
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateGoatParam();
            OutForm outForm = new OutForm(this);
            outForm.ShowDialog();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateGoatParam();
            OutForm outForm = new OutForm(this);
            outForm.ShowDialog();
        }

        private void 多文件输出excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutForm outForm = new OutForm(this, false);
            outForm.ShowDialog();
        }

        private void dIYImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDefinedImgeForm userDefinedImgeForm = new UserDefinedImgeForm(this.pictureBox.ImageLocation, this.language);
            userDefinedImgeForm.Show();
            pictureBox.ImageLocation = goat.imgUrl.ElementAt(currentimg);
        }

        private void serverOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.socketKey == "")
            {
                this.socketKey = null;
            }
            if (this.socketUrl == "" || this.socketUrl == null)
            {
                this.socketUrl = this.saveUrl;
            }
            if (serverForm == null)
            {
                serverForm = new ConnectServerForm(port, listen, socketUrl, socketKey, serveripV6);
                serverForm.Show();
                serverForm.FormClosed += serverClosed;
            }
            else
            {
                serverForm.WindowState = FormWindowState.Normal;
            }
            serverCloseToolStripMenuItem.Enabled = true;
        }

        private void serverClosed(object sender, EventArgs e)
        {
            this.serverForm = null;
            serverCloseToolStripMenuItem.Enabled = false;
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void serverCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.serverForm.Close();
            serverForm = null;
            serverCloseToolStripMenuItem.Enabled = false;
        }

        private void connectByIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectClientForm clientForm = new ConnectClientForm(this);
            clientForm.Show();

            clientForm.FormClosed += clientFormClosed;
        }

        private void clientFormClosed(object sender, EventArgs e)
        {
            XElement connectIPs = document.Root.Element("connectHistory");
            foreach (string ip in connectHistory)
            {
                connectIPs.SetElementValue("address", ip);
            }
            (sender as ConnectClientForm).Dispose();
        }

        private void 连接设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socketForm socketForm = new socketForm(this);
            if (socketForm.ShowDialog() == DialogResult.OK)
            {
                XElement root = document.Root;
                root.Element("socketUrl").SetValue(this.socketUrl);
                root.Element("socketKey").SetValue(this.socketKey);
                root.Element("listen").SetValue(this.listen);
                root.Element("port").SetValue(this.port);
                root.Element("serveripV6").SetValue(this.serveripV6.ToString());
                root.Element("clientipV6").SetValue(this.clientipV6.ToString());
                document.Save("../../configs/goatConfig.xml");
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(goat.imgUrl[currentimg]);
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Directory doesn't exist");
                return;
            }
            System.Diagnostics.Process.Start(path);
        }
    }
}
