using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace _2nd_Year_Test_Project_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Data.PopulateDGV(dgv_CovidStat);
        }
    }
}
