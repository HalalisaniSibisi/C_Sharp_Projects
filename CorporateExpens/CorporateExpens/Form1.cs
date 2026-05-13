using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorporateExpens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void calculateExpense_Click(object sender, EventArgs e)
        {
            // 1. Declare the array
            int[,] data = new int[4, 5];

            // 2. Read the file and fill the array
            string[] lines = File.ReadAllLines("array.txt");

            // 3. Month names (for readable output)
            string[] months = { "January", "February", "March", "April" };

            for (int i = 0; i < 4; i++)
            {
                string[] parts = lines[i].Split(' ');

                for (int j = 0; j < 5; j++)
                {
                    data[i, j] = int.Parse(parts[j]);
                }
            }

            // 4. Find the month with the highest total
            int highest = 0;
            int highest_month = 0;

            for (int i = 0; i < 4; i++)
            {
                int month_total = 0;

                for (int j = 0; j < 5; j++)
                {
                    month_total += data[i, j];
                }

                if (month_total > highest)
                {
                    highest = month_total;
                    highest_month = i;
                }
            }

            resultList.Items.Add($"Month with highest expense: {months[highest_month]}");
            resultList.Items.Add($"Total expense: R{highest}.00");
        }

        private void resultList_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
