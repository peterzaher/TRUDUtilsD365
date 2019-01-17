﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;

namespace TRUDUtilsD365.TableFieldsBuilder
{
    public partial class TableFieldsBuilderDialog : Form
    {
        private TableFieldsBuilderParms _parms;
        public void SetParameters(TableFieldsBuilderParms parms)
        {
            _parms = parms;
            tableFieldsBuilderParmsBindingSource.Add(parms);

            FieldTypeBox.DataSource = Enum.GetValues(typeof(FieldType));
        }
        public TableFieldsBuilderDialog()
        {
            InitializeComponent();
        }

        private void UpdatePreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                PreviewTextBox.Text = _parms.GetPreviewString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _parms.AddFields();

                _parms.DisplayLog();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void GetTemplateButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialogTemplate.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialogTemplate.FileName;
                var byteRes = Properties.Resources.TableFieldsBuilderTemplateV11;

                File.WriteAllBytes(fileName, byteRes);

                System.Diagnostics.Process.Start(fileName);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void EDTNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FieldNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EDTExtendsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FieldTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
