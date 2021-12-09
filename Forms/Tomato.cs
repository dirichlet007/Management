﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Management.Controls;
using Management.DataBaseHelper;
using Management.ProjectHelper;
namespace Management.Forms
{
    public partial class Tomato : Form
    {
        public Tomato()
        {
            InitializeComponent();
        }
        class Tmtinfo
        {
            public string tmtname;
            public string tmttype;
        }
        FormHelper fmhpr = new FormHelper();
        public void textdisplay() {

            List<Tmtinfo> bls = new List<Tmtinfo>();
            DBUtil db = new DBUtil();
            string sql = string.Format(@"select tdname,tdtype,tdlenth from tomato ");
            DataSet ds = db.SqlSet(sql);
            var location = panel1.Location;
            try
            {
                DataTable myTable = ds.Tables[0];
                foreach (DataRow myRow in myTable.Rows)
                {

                    //遍历表中的每个单元格
                    Tmtinfo u = new Tmtinfo();
                    u.tmtname = myRow[0].ToString();
                    u.tmttype = myRow[1].ToString();
                    mybutton btn = new mybutton();
                    btn.label1_text = u.tmtname;                   
                    btn.label2_text = u.tmttype;
                    location.Y += 110;
                    btn.Location = new Point(location.X, location.Y);
                    panel1.Controls.Add(btn);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }
        private void Tomato_Load(object sender, EventArgs e)
        {
            this.AutoScrollMinSize = new Size(ClientRectangle.Width, ClientRectangle.Height);
            textdisplay();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddBacklog fs = new AddBacklog();
            fs.rfhTmtClk += textdisplay;
            fs.ShowDialog();
        }
    }
}
