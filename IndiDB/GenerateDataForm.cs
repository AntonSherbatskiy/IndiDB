﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndiDB
{
    public partial class GenerateDataForm : Form
    {
        public GenerateDataForm()
        {
            InitializeComponent();
            IsConfirmed = false;
        }

        public bool IsConfirmed { get; private set; }

        private void OkButton_Click(object sender, EventArgs e)
        {
            IsConfirmed = true;
            Close();
        }
    }
}
