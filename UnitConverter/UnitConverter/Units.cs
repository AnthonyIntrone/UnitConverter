using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitConverter
{
    public partial class Units : Form
    {
        #region properties 

        private List<Unit> meas;

        public List<Unit> MEASList
        {
            get
            {
                if (meas == null)
                {
                    meas = new List<Unit>();

                    Unit oneUOM;

                    oneUOM = new Unit("Inches", "L"); meas.Add(oneUOM);
                    oneUOM = new Unit("Feet", "L"); meas.Add(oneUOM);
                    oneUOM = new Unit("Yards", "L"); meas.Add(oneUOM);
                    oneUOM = new Unit("Millimeters", "L"); meas.Add(oneUOM);
                    oneUOM = new Unit("Centimeters", "L"); meas.Add(oneUOM);
                    oneUOM = new Unit("Meters", "L"); meas.Add(oneUOM);

                    //Area 
                    oneUOM = new Unit("Square Inches", "A"); meas.Add(oneUOM);
                    oneUOM = new Unit("Square Feet", "A"); meas.Add(oneUOM);
                    oneUOM = new Unit("Square Yards", "A"); meas.Add(oneUOM);
                    oneUOM = new Unit("Square Miles", "A"); meas.Add(oneUOM);
                    oneUOM = new Unit("Square Centemeters", "A"); meas.Add(oneUOM);
                    oneUOM = new Unit("Square Meters", "A"); meas.Add(oneUOM);

                    //Weight 
                    oneUOM = new Unit("Ounce", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Pound", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Hundredweight", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Short Ton", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Long Ton", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Kilogram", "W"); meas.Add(oneUOM);
                    oneUOM = new Unit("Gram", "W"); meas.Add(oneUOM);

                    //Volume
                    oneUOM = new Unit("Minims", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Fluid Drams", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Fluid OUnces", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Gills", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Liquid Pints", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Liquid Quarts", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Gallons", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Cubic Inches", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Cubic Feet", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Milliliters", "V"); meas.Add(oneUOM);
                    oneUOM = new Unit("Liters", "V"); meas.Add(oneUOM);

                    //Time
                    oneUOM = new Unit("Seconds", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Minutes", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Hours", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Days", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Weeks", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Month", "I"); meas.Add(oneUOM);
                    oneUOM = new Unit("Year", "I"); meas.Add(oneUOM);

                }
                return meas;
            }
        }

        #endregion

        #region Data

        double[,] lengthMatrix =
           { {1.0, 1.0/12.0, 1.0/36.0, 25.4, 2.54, 0.0254},            //Inches
           {12.0, 1.0, 1.0/3.0, 304.8, 30.48, 0.3048},               //Feet
           {36.0, 3.0, 1.0, 914.4, 91.44, 0.9144},                   //yards
           {0.03937008, 0.003280840,  0.001093613, 1.0, 0.1, 0.001}, //millimeter
           {0.3937008, 0.03280840,  0.01093613, 10.0, 1.0, 0.01},    //centimeter
           {39.37008, 3.280840, 1.093613, 1000.0, 100.0, 1.0}        //meter
        };

        double[,] areaMatrix =
           { {1, 0.006944444, 0.0007716049, 0.0000000002490977, 6.4516, 0.00064516},  //Square Inches
           {144, 1, 0.1111111, 0.00000003587006, 929.0304, 0.09290304},            //Square Feet            
           {1296, 9, 1, 0.0000003228306, 8361.2736, 0.83612736},                   //Square Yard
           {4014489600, 27878400, 3097600, 1, 25899881103.36, 2589988.110336},     //Square Mile
           {0.1550003, 0.001076391, 0.0001195990, 0.00000000003861022, 1, 0.0001}, //Square Centimeter
           {1550.003, 10.76391, 1.195990, 0.0000003861022, 10000, 1}               //Square Meters
        };

        double[,] weightMatrix =
          { {1,  0.0625,  0.000625, 0.00003125, 0.00002790179,  0.028349523125, 0.000028349523125},                                    //ounce
          {16, 1, 0.01, 0.0005, 0.0004464286,  0.45359237, 0.00045359237},                                                           //pound
          {1600, 100, 1, 0.05, 0.04464286, 45.359237, 0.045359237},                                                                  //hundredweight
          {32000, 2000,20, 1, 0.8928571, 907.18474, 0.90718474},                                                                     //short ton
          {35840, 2240, 22.4, 1.12, 1, 1016.0469088, 1.0160469088},                                                                  //long ton
          {35.27396, 2.204623, 0.02204623, 0.001102311, 0.0009842065, 1, 0.001},                                                     //kilogram
          {(35.27396 * .001), (2.204623 * .001), (0.02204623 * .001), (0.001102311 * .001), (0.0009842065 * .001), (1 * .001), 1 },  //gram
        };

        double[,] volumeMatrix =
         { {1, 0.01666667,0.002083333,0.0005208333, 0.0001302083, 0.00006510417, 0.00001627604, 0.003759766, 0.000002175790, 0.06161152, 0.00006161152}, //minim
          {60,1, 0.125, 0.03125, 0.0078125, 0.00390625, 0.0009765625, 0.22558594, 0.0001305474, 3.696691, 0.003696691},                                 //liquid dram
          {480, 8, 1, 0.25, 0.0625, 0.03125, 0.0078125, 1.8046875, 0.001044379, 29.57353, 0.02957353},                                                  //fluid ounce
          {1920, 32, 4, 1, 0.25, 0.125, 0.03125, 7.21875, 0.004177517, 118.2941, 0.1182941},                                                            //gill
          {7680,128, 16, 4, 1, 0.5, 0.125, 28.875, 0.01671007, 473.1765, 0.4731765},                                                                    //pint
          {15360, 256, 32, 8, 2, 1, 0.25, 57.75, 0.03342014, 946.3529, 0.9463529},                                                                      //quart
          {61440, 1024, 128, 32, 8, 4, 1, 231, 0.1336806, 3785.412, 3.785412},                                                                          //gallon
          {265.9740, 4.432900, 0.5541126, 0.1385281, 0.03463203, 0.01731602, 0.004329004, 1, 0.0005787037, 16.38706, 0.01638706},                       //cubic inch
          {459603.1, 7660.052, 957.5065, 239.3766, 59.84416, 29.92208, 7.480519, 1728, 1, 28316.85, 28.31685},                                          //cubic foot
          {16.23073, 0.2705122, 0.03381402, 0.008453506, 0.002113376, 0.001056688, 0.0002641721, 0.06102374, 0.00003531467, 1, 0.001},                  //millileter                                                                               
          {16230.73, 270.5122, 33.81402, 8.453506, 2.113376, 1.056688, 0.2641721, 61.02374, 0.03531467, 1000, 1}                                        //liter
        };

        double[,] timeMatrix =
         {{1, 0.0166667, 0.000277778, 1.1574E-5, 1.6534E-6, 3.8027E-7, 3.1689E-8},  //Second
         {60, 1, 0.0166667, 0.00069444, 9.9206E-5, 2.2816E-5, 1.9013E-6},          //Minute
         {3600, 60,  1, 0.0416667, 0.00595238, 0.00136895, 0.00011408},            //Hour
         {864000, 1440, 24, 1, 0.142857, 0.0328549, 0.00273791},                   //Day
         {604800, 10080, 168, 7, 1, 0.229984, 0.191654},                           //Week
         {2.63E+6, 43829.1, 730.484, 30.4368, 4.34812, 1, 0.0833333},              //Month
         {3.156E+7, 525949, 8765.81, 365.242, 52.1775, 12, 1}                      //Year
        };

        #endregion

        #region variables

        List<Unit> lengthList = new List<Unit>();
        List<Unit> areaList = new List<Unit>();
        List<Unit> weightList = new List<Unit>();
        List<Unit> volumeList = new List<Unit>();
        List<Unit> timeList = new List<Unit>();

        int fromIdx = 0;

        #endregion

        #region init & load

        public Units()
        {
            InitializeComponent();
        }

        private void Units_Load(object sender, EventArgs e)
        {
            this.Icon = MakeIcon();
            fromTextBox.Text = "";
            toTextBox.Text = "";
            errorLabel.Text = "";

            LoadMEASLists();
            LoadFromComboBox();
            LoadLengthComboBox();
            
            fromComboBox.SelectedIndex = 1;
            toComboBox.SelectedIndex = 1;

            fromTextBox.KeyPress += new KeyPressEventHandler(OnlyNumberWithSinglePointInTextBox);
            convertButton.Click += new EventHandler(ConvertButtonClick);
            fromComboBox.SelectedIndexChanged += new EventHandler(fromComboBoxSelectedIndexChanged);
        }

        #endregion

        #region load lists

        private void LoadMEASLists()
        {
            foreach(Unit u in MEASList)
            {
                switch (u.TYPE)
                {
                    case "L": lengthList.Add(new Unit(u.MEAS, u.TYPE)); break;
                    case "A": areaList.Add(new Unit(u.MEAS, u.TYPE)); break;
                    case "W": weightList.Add(new Unit(u.MEAS, u.TYPE)); break;
                    case "V": volumeList.Add(new Unit(u.MEAS, u.TYPE)); break;
                    case "I": timeList.Add(new Unit(u.MEAS, u.TYPE)); break;
                    default: break;
                }
            }
        }
        #endregion

        #region load combo boxes

        private void LoadFromComboBox()
        {
            fromBindingSource.DataSource = MEASList;
            fromComboBox.DataSource = fromBindingSource.DataSource;
            fromComboBox.DisplayMember = "MEAS";
        }

        private void LoadLengthComboBox()
        {
            toBindingSource.DataSource = lengthList;
            toComboBox.DataSource = toBindingSource.DataSource;
            toComboBox.DisplayMember = "MEAS";
        }
        private void LoadAreaComboBox()
        {
            toBindingSource.DataSource = areaList;
            toComboBox.DataSource = toBindingSource.DataSource;
            toComboBox.DisplayMember = "MEAS";
        }
        private void LoadWeightComboBox()
        {
            toBindingSource.DataSource = weightList;
            toComboBox.DataSource = toBindingSource.DataSource;
            toComboBox.DisplayMember = "MEAS";
        }
        private void LoadVolumeComboBox()
        {
            toBindingSource.DataSource = volumeList;
            toComboBox.DataSource = toBindingSource.DataSource;
            toComboBox.DisplayMember = "MEAS";
        }
        private void LoadTimeComboBox()
        {
            toBindingSource.DataSource = timeList;
            toComboBox.DataSource = toBindingSource.DataSource;
            toComboBox.DisplayMember = "MEAS";
        }
        #endregion

        #region text box events
        private void OnlyNumberWithSinglePointInTextBox(object sender, KeyPressEventArgs e) 
        { 
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region comboBox events

        private void fromComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Unit unit = MEASList[fromComboBox.SelectedIndex];
            switch (unit.TYPE)
            {
                case "L": LoadLengthComboBox(); break;
                case "A": LoadAreaComboBox(); break;
                case "W": LoadWeightComboBox(); break;
                case "V": LoadVolumeComboBox(); break;
                case "I": LoadTimeComboBox(); break;
                default: break;
            }
        }

        #endregion 

        #region convert button click event
        private void ConvertButtonClick(object sender, EventArgs e)
        {
            Unit unit = MEASList[fromComboBox.SelectedIndex];
            switch (unit.TYPE)
            {
                case "L": conversion(lengthList, lengthMatrix); break;
                case "A": conversion(areaList, areaMatrix); break;
                case "W": conversion(weightList, weightMatrix); break;
                case "V": conversion(volumeList, volumeMatrix); break;
                case "I": conversion(timeList, timeMatrix); break;
                default: break;
            }
        }
        #endregion

        #region conversion

        private void conversion(List<Unit> conversionList, double[,] conversionMatrix)
        {
            int toIdx = toComboBox.SelectedIndex;
            int i = 0;

            if (fromComboBox.SelectedIndex > -1 && toComboBox.SelectedIndex > -1)
            {
                Unit fromUnit = MEASList[fromComboBox.SelectedIndex];
                foreach(Unit u in conversionList)
                {
                    if (u.MEAS.Equals(fromUnit.MEAS)) fromIdx = i; i++;
                }

                double fromNumber = 0;
                if (Double.TryParse(fromTextBox.Text, out fromNumber))
                {
                    toTextBox.Text = (fromNumber * conversionMatrix[fromIdx, toIdx]).ToString();
                }
                else
                {
                    errorLabel.Text = "Invalid Number Entered";
                }
            }
        }

        #endregion

        #region make icon
        private Icon MakeIcon()
        {
            Image img = Properties.Resources.spacebar;
            Bitmap newImg = new Bitmap(img);
            IntPtr iPtr = newImg.GetHicon();
            Icon icon = Icon.FromHandle(iPtr);
            return icon;
        }
        #endregion
    }
}
