﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZMS.Forms
{
  public partial class Settings : Form
  {
    public Settings()
    {
      InitializeComponent();
    }

    private void Settings_Load(object sender, EventArgs e)
    {
      LoadTheme();
    }

    private void LoadTheme()
    {
      foreach (Control btns in this.Controls)
      {
        if (btns.GetType() == typeof(Button))
        {
          Button btn = (Button)btns;
          btn.BackColor = ThemeColor.PrimaryColor;
          btn.ForeColor = Color.White;
          btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
        }
      }
      //label1.ForeColor = ThemeColor.SecondaryColor;
      //label2.ForeColor = ThemeColor.PrimaryColor;
    }
  }
}
