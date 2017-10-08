using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaOcean_TournamentSchedulerBL;

namespace MediaOcean_TournamentScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            int teamCount = (int)numericUpDown1.Value;

            //int[,] matches = GetAllMatches(teamCount);

            Scheduler tournamentScheduler = new Scheduler();
            string outputSchedule = tournamentScheduler.GetTournamentSchedule(teamCount);

            textBox1.Text = outputSchedule;
        }

        
    }
}
