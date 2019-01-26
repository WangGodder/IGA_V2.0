using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using word = Office;
using IGAv2._0.com.godder.animal;

namespace IGAv2._0.com.godder.form
{
    public partial class OutForm : Form
    {
        private short type;
        private List<AnimalAbstract> animals = new List<AnimalAbstract>();
        private List<DataShowControl> dataControls = new List<DataShowControl>();
        private List<DataShowControl> dataControlsCopy;
        private DataShowControl enterDataControl = null;
        private GoatForm goatForm;
        private byte lengthUnit = 0;
        private byte weightUnit = 0;
        private string fileUrl;

        private string fileOpenWrong = "file has been opened cannot change it, please close file and try again.";

        public OutForm(GoatForm superForm, bool readInfo = true)
        {
            this.type = 1;
            this.goatForm = superForm;
            AnimalFormInit(superForm);
            if (readInfo)
            {
                txtButton.Enabled = true;
                wordButton.Enabled = true;
                excelButton.Enabled = true;
                goatInit(readInfo);
            }
            else
            {
                txtButton.Enabled = false;
                wordButton.Enabled = false;
                excelButton.Enabled = false;
                goatInit(readInfo);
            }

            button3.Click += buttonAdd_Click_Goat;
            this.openFileDialog.InitialDirectory = superForm.openUrl;
            weigthComboBox.SelectedIndexChanged += goatWeigthComboBox_SelectedIndexChanged;
            lengthComboBox.SelectedIndexChanged += goatLengthComboBox_SelectedIndexChanged;
        }

        private void AnimalFormInit(AnimalFormAbstract superForm)
        {
            lengthUnit = superForm.lengthUnit;
            weightUnit = superForm.weightUnit;
            this.lengthUnit = goatForm.lengthUnit;
            this.weightUnit = goatForm.weightUnit;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(superForm.language);
            InitializeComponent();
            typeComboBox.SelectedIndex = this.type;
            typeComboBox.Enabled = false;
            lengthComboBox.SelectedIndex = this.lengthUnit;
            weigthComboBox.SelectedIndex = this.weightUnit;
        }

        private void goatInit(bool readInfo = true)
        {
            if (readInfo)
            {
                dataControls.Add(new DataShowControl(goatForm.idLabel.Text, goatForm.idText));
                dataControls.Add(new DataShowControl("type", "goat"));
                dataControls.Add(new DataShowControl(goatForm.dateLabel.Text, goatForm.dateValue.ToString()));
                dataControls.Add(new DataShowControl(goatForm.speciesLabel.Text, goatForm.speciesText));
                dataControls.Add(new DataShowControl(goatForm.countryLabel.Text, goatForm.countryComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.regionLabel.Text, goatForm.regionText));
                dataControls.Add(new DataShowControl(goatForm.latitudeLabel.Text, goatForm.latitudeDegreeText + "°" + goatForm.latitudeMinuteText + "'" + goatForm.latitudeSecondText + "\""));
                dataControls.Add(new DataShowControl(goatForm.longitudeLabel.Text, goatForm.longitudeDegreeText + "°" + goatForm.longitudeMinuteText + "'" + goatForm.longitudeSecondText + "\""));
                dataControls.Add(new DataShowControl(goatForm.genderLabel.Text, goatForm.genderComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.ageLabel.Text, goatForm.ageText));
                dataControls.Add(new DataShowControl(goatForm.farrowLabel.Text, goatForm.farrowComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.cavelLabel.Text, goatForm.cavelComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.foreheadLabel.Text, goatForm.foreheadComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text, goatForm.headComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text + goatForm.lengthLabel1.Text, goatForm.headLengthText));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text + goatForm.widthLabel1.Text, goatForm.headWidthText));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text, goatForm.earComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text + goatForm.lengthLabel1.Text, goatForm.earLengthText));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text + goatForm.widthLabel1.Text, goatForm.earWidthText));
                dataControls.Add(new DataShowControl(goatForm.noseLabel.Text, goatForm.noseComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.neckLabel.Text, goatForm.neckComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.meatCheckBox.Text, goatForm.meatChecked.ToString()));
                dataControls.Add(new DataShowControl(goatForm.wrinkleCheckBox.Text, goatForm.wrinkleChecked.ToString()));
                dataControls.Add(new DataShowControl(goatForm.beardCheckBox.Text, goatForm.beardChecked.ToString()));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text, goatForm.tailComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text + goatForm.lengthLabel1.Text, goatForm.headLengthText));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text + goatForm.widthLabel1.Text, goatForm.headWidthText));
                dataControls.Add(new DataShowControl(goatForm.limbsLabel.Text, goatForm.limbsComboBox.Text));
                dataControls.Add(new DataShowControl(goatForm.bodyLengthLabel.Text, goatForm.bodyLengthText));
                dataControls.Add(new DataShowControl(goatForm.bodyHeightLabel.Text, goatForm.bodyHeightText));
                dataControls.Add(new DataShowControl(goatForm.bodyObliqueLengthLabel.Text, goatForm.bodyObliqueLengthText));
                dataControls.Add(new DataShowControl(goatForm.weightLabel.Text, goatForm.bodyweightText));
                dataControls.Add(new DataShowControl(goatForm.chestLabel.Text, goatForm.chestText));
                dataControls.Add(new DataShowControl(goatForm.bustDepthLabel.Text, goatForm.bustDepthText));
                dataControls.Add(new DataShowControl(goatForm.bustWidthLabel.Text, goatForm.bustWidthText));
                dataControls.Add(new DataShowControl(goatForm.coatColorLabel.Text, goatForm.coatColorValue));
                dataControls.Add(new DataShowControl(goatForm.skinColorLabel.Text, goatForm.skinColorValue));
                dataControls.Add(new DataShowControl("comment", goatForm.commentText));

                listBox1.Items.Add("id= " + goatForm.idText);
                animals.Add(goatForm.getGoat());
            }
            else
            {
                dataControls.Add(new DataShowControl(goatForm.idLabel.Text));
                dataControls.Add(new DataShowControl("type"));
                dataControls.Add(new DataShowControl(goatForm.dateLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.speciesLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.countryLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.regionLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.latitudeLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.longitudeLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.genderLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.ageLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.farrowLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.cavelLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.foreheadLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text + goatForm.lengthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.headLabel.Text + goatForm.widthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text + goatForm.lengthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.earLabel.Text + goatForm.widthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.noseLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.neckLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.meatCheckBox.Text));
                dataControls.Add(new DataShowControl(goatForm.wrinkleCheckBox.Text));
                dataControls.Add(new DataShowControl(goatForm.beardCheckBox.Text));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text + goatForm.lengthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.tailLabel.Text + goatForm.widthLabel1.Text));
                dataControls.Add(new DataShowControl(goatForm.limbsLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.bodyLengthLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.bodyHeightLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.bodyObliqueLengthLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.weightLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.chestLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.bustDepthLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.bustWidthLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.coatColorLabel.Text));
                dataControls.Add(new DataShowControl(goatForm.skinColorLabel.Text));
                dataControls.Add(new DataShowControl("comment"));

            }

            dataControlsCopy = new List<DataShowControl>(dataControls);

            foreach (DataShowControl control in dataControls)
            {
                dataPanel.Controls.Add(control);
                control.Enter += DataShowControl_Enter;
                control.button.Click += dataDeleteButton_Click;
            }
        }

        private void dataDeleteButton_Click(object sender, EventArgs e)
        {
            Button bt = (sender as Button);
            string id = bt.Name.Split('_').Last();
            DataShowControl dataControl = dataControlsCopy.Find((control) => { return control.Name.Split('_').Last() == id; });
            DialogResult result = MessageBox.Show("Are you sure to delete " + dataControl.label.Text, "Warn", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            dataControl.Hide();
            dataControlsCopy.Remove(dataControl);
            this.ActiveControl = null;
            leftButton.Enabled = false;
            rightButton.Enabled = false;
        }

        private void DataShowControl_Enter(object sender, EventArgs e)
        {
            this.enterDataControl = (sender as DataShowControl);
            leftButton.Enabled = rightButton.Enabled = true;
            if (dataControlsCopy.IndexOf(enterDataControl) == 0)
            {
                leftButton.Enabled = false;
            }
            if (dataControlsCopy.IndexOf(enterDataControl) == dataControls.Count - 1)
            {
                rightButton.Enabled = false;
            }
        }

        private void swapControls(int index1, int index2)
        {
            DataShowControl swap = dataControlsCopy.ElementAt(index1);
            dataControlsCopy[index1] = dataControlsCopy[index2];
            dataControlsCopy[index2] = swap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = dataControlsCopy.IndexOf(enterDataControl);
            swapControls(index, --index);
            dataPanel.Controls.Clear();
            foreach (DataShowControl control in dataControlsCopy)
            {
                dataPanel.Controls.Add(control);
            }
            this.ActiveControl = this.enterDataControl;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = dataControlsCopy.IndexOf(enterDataControl);
            swapControls(index, ++index);
            dataPanel.Controls.Clear();
            foreach (DataShowControl control in dataControlsCopy)
            {
                dataPanel.Controls.Add(control);
            }
            this.ActiveControl = this.enterDataControl;
        }

        private void buttonAdd_Click_Goat(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button3.Enabled = resetButton.Enabled = false;
                foreach (string url in openFileDialog.FileNames)
                {
                    progressBar.Value = 0;
                    Goat goat = Goat.load(url);
                    animals.Add(goat);
                    progressBar.PerformStep();
                    listBox1.Items.Add("id= " + goat.getId().ToString());
                    progressBar.PerformStep();
                    loadGoat(goat);
                }
                MessageBox.Show("load complete");
                button3.Enabled = resetButton.Enabled = true;
                this.ActiveControl = this.enterDataControl;
                txtButton.Enabled = wordButton.Enabled = excelButton.Enabled = true;
            }
        }

        private void loadGoat(Goat goat)
        {
            goat.changeLengthUnit(this.lengthUnit);
            goat.changeWeightUnit(this.weightUnit);
            progressBar.PerformStep();
            dataControls[0].addData(goat.getId().ToString());
            progressBar.PerformStep();
            dataControls[1].addData("goat");
            progressBar.PerformStep();
            dataControls[2].addData(goat.year.ToString() + "/" + goat.month.ToString() + "/" + goat.day.ToString());
            progressBar.PerformStep();
            dataControls[3].addData(goat.species);
            progressBar.PerformStep();
            dataControls[4].addData(goatForm.countryComboBox.Items[goat.country].ToString());
            progressBar.PerformStep();
            dataControls[5].addData(goat.region);
            progressBar.PerformStep();
            dataControls[6].addData(goat.latitudeDegree.ToString() + "°" + goat.latitudeMinute + "'" + goat.latitudeSecond + "\"");
            progressBar.PerformStep();
            dataControls[7].addData(goat.longitudeDegree.ToString() + "°" + goat.longitudeMinute + "'" + goat.longitudeSecond + "\"");
            progressBar.PerformStep();
            dataControls[8].addData(goatForm.genderComboBox.Items[goat.sex].ToString());
            progressBar.PerformStep();
            dataControls[9].addData(goat.age.ToString());
            progressBar.PerformStep();
            dataControls[10].addData(goat.createNum.ToString());
            progressBar.PerformStep();
            dataControls[11].addData(goatForm.cavelComboBox.Items[goat.cavel].ToString());
            progressBar.PerformStep();
            dataControls[12].addData(goatForm.foreheadComboBox.Items[goat.foreheadType].ToString());
            progressBar.PerformStep();
            dataControls[13].addData(goatForm.headComboBox.Items[goat.headType].ToString());
            progressBar.PerformStep();
            dataControls[14].addData(goat.headLength.ToString());
            progressBar.PerformStep();
            dataControls[15].addData(goat.headWidth.ToString());
            progressBar.PerformStep();
            dataControls[16].addData(goatForm.earComboBox.Items[goat.earType].ToString());
            progressBar.PerformStep();
            dataControls[17].addData(goat.earLength.ToString());
            progressBar.PerformStep();
            dataControls[18].addData(goat.earWidth.ToString());
            progressBar.PerformStep();
            dataControls[19].addData(goatForm.noseComboBox.Items[goat.nose].ToString());
            progressBar.PerformStep();
            dataControls[20].addData(goatForm.neckComboBox.Items[goat.neck].ToString());
            progressBar.PerformStep();
            dataControls[21].addData(goat.isMeat.ToString());
            progressBar.PerformStep();
            dataControls[22].addData(goat.isWrinkle.ToString());
            progressBar.PerformStep();
            dataControls[23].addData(goat.isBeard.ToString());
            progressBar.PerformStep();
            dataControls[24].addData(goatForm.tailComboBox.Items[goat.tailType].ToString());
            progressBar.PerformStep();
            dataControls[25].addData(goat.tailLength.ToString());
            progressBar.PerformStep();
            dataControls[26].addData(goat.tailWidth.ToString());
            progressBar.PerformStep();
            dataControls[27].addData(goatForm.limbsComboBox.Items[goat.limbs].ToString());
            progressBar.PerformStep();
            dataControls[28].addData(goat.bodyLength.ToString());
            progressBar.PerformStep();
            dataControls[29].addData(goat.bodyHeight.ToString());
            progressBar.PerformStep();
            dataControls[30].addData(goat.bodyObliqueLength.ToString());
            progressBar.PerformStep();
            dataControls[31].addData(goat.weight.ToString());
            progressBar.PerformStep();
            dataControls[32].addData(goat.chestCircumference.ToString());
            progressBar.PerformStep();
            dataControls[33].addData(goat.bustDepth.ToString());
            progressBar.PerformStep();
            dataControls[34].addData(goat.bustWidth.ToString());
            progressBar.PerformStep();
            dataControls[35].addData(goat.coatColor);
            progressBar.PerformStep();
            dataControls[36].addData(goat.skinColor);
            progressBar.PerformStep();
            dataControls[37].addData(goat.comment);
            progressBar.PerformStep();

            dataPanel.Controls.Clear();
            foreach (DataShowControl control in dataControlsCopy)
            {
                dataPanel.Controls.Add(control);
            }

            this.dataPanel.Height += 40;
            this.Height += 40;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            int index = listBox1.SelectedIndex;
            progressBar.Value = 0;
            progressBar.Maximum = dataControls.Count;
            foreach (DataShowControl control in dataControls)
            {
                control.deleteDataAt(index);
                progressBar.PerformStep();
            }
            listBox1.Items.RemoveAt(index);
            listBox1.SelectedIndex = -1;
            dataPanel.Height -= 40;
            this.Height -= 40;
            animals.RemoveAt(index);
            if (listBox1.Items.Count == 0)
            {
                txtButton.Enabled = wordButton.Enabled = excelButton.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            if (listBox1.SelectedIndex <= 0)
            {
                button1.Enabled = false;
            }
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                button2.Enabled = false;
            }
            if (listBox1.SelectedIndex < 0)
            {
                button4.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void swapAnimal(int index1, int index2)
        {
            AnimalAbstract swap = animals[index1];
            animals[index1] = animals.ElementAt(index2);
            animals[index2] = swap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string swap = listBox1.Items[index].ToString();
            listBox1.Items[index] = listBox1.Items[index - 1];
            listBox1.Items[index - 1] = swap;
            foreach (DataShowControl control in dataControls)
            {
                control.swapData(index, index - 1);
            }
            swapAnimal(index, index - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string swap = listBox1.Items[index].ToString();
            listBox1.Items[index] = listBox1.Items[index + 1];
            listBox1.Items[index + 1] = swap;
            foreach (DataShowControl control in dataControls)
            {
                control.swapData(index, index + 1);
            }
            swapAnimal(index, index + 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.dataControlsCopy = new List<DataShowControl>(dataControls);
            dataPanel.Controls.Clear();
            foreach (DataShowControl control in dataControlsCopy)
            {
                control.Show();
                dataPanel.Controls.Add(control);
            }
            leftButton.Enabled = rightButton.Enabled = false;
            this.ActiveControl = null;
        }

        private void txtButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "记事本文件|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string url = saveFileDialog.FileName;
                outputTxt(url);
                this.fileUrl = url;
                openFileButton.Enabled = true;
            }
        }

        private void outputTxt(string url)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(url, FileMode.Create);
            }
            catch (Exception)
            {
                MessageBox.Show(fileOpenWrong);
                return;
            }
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                foreach (DataShowControl control in dataControlsCopy)
                {
                    sw.Write(control.label.Text + ": ");
                    sw.WriteLine(control.getDataAt(i));
                }
            }
            sw.Close();
            fs.Close();
        }

        private void wordButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "word文档|*.doc";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string url = saveFileDialog.FileName;
                outputTxt(url);
                this.fileUrl = url;
                openFileButton.Enabled = true;
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "excel文档|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string url = saveFileDialog.FileName;
                outputExcel(url);
                this.fileUrl = url;
                openFileButton.Enabled = true;
            }
        }

        private void outputExcel(string url)
        {
            StringBuilder stringBuilder = new StringBuilder();
            FileStream fs = null;
            try
            {
                fs = new FileStream(url, FileMode.Create);
            }
            catch (Exception)
            {
                MessageBox.Show(fileOpenWrong);
                return;
            }
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));
            UTF8Encoding uTF8 = new UTF8Encoding();
            Byte[] encodeBytes = uTF8.GetBytes("\t");
            string format = uTF8.GetString(encodeBytes);
            foreach (DataShowControl control in dataControlsCopy)
            {
                stringBuilder.Append(control.label.Text.ToLower() + "\t");
            }
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                foreach (DataShowControl control in dataControlsCopy)
                {
                   stringBuilder.Append(control.getDataAt(i) + format);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            sw.Write(stringBuilder);
            sw.Close();
            fs.Close();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.fileUrl);
        }

        private void goatLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataControls[14].changeUnit(Math.Pow(10 ,Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[15].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[17].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[18].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[25].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[26].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[28].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[29].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[30].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[32].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[33].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));
            dataControls[34].changeUnit(Math.Pow(10, Convert.ToInt32(this.lengthUnit - lengthComboBox.SelectedIndex)));

            this.lengthUnit = Convert.ToByte(lengthComboBox.SelectedIndex);
        }

        private void goatWeigthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataControls[31].changeUnit(Math.Pow(1000, Convert.ToInt32(this.weightUnit - weigthComboBox.SelectedIndex)));
            this.weightUnit = Convert.ToByte(weigthComboBox.SelectedIndex);
        }
    }
}
