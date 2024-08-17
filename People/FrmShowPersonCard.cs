using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmShowPersonCard : Form
    {
       private int _ID;

        public FrmShowPersonCard(int PersonID)
        {
            InitializeComponent();
            _ID = PersonID;
        }

        private void FrmShowPersonCard_Load(object sender, EventArgs e)
        {
            cntrPersonCard1.LoadPersonInfo(_ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
