namespace CorporateExpens
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultList = new System.Windows.Forms.ListBox();
            this.calculateExpense = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultList
            // 
            this.resultList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(207)))), ((int)(((byte)(151)))));
            this.resultList.FormattingEnabled = true;
            this.resultList.ItemHeight = 16;
            this.resultList.Location = new System.Drawing.Point(172, 102);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(566, 324);
            this.resultList.TabIndex = 0;
            this.resultList.SelectedIndexChanged += new System.EventHandler(this.resultList_SelectedIndexChanged);
            // 
            // calculateExpense
            // 
            this.calculateExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(160)))), ((int)(((byte)(132)))));
            this.calculateExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateExpense.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calculateExpense.Location = new System.Drawing.Point(282, 481);
            this.calculateExpense.Name = "calculateExpense";
            this.calculateExpense.Size = new System.Drawing.Size(342, 68);
            this.calculateExpense.TabIndex = 1;
            this.calculateExpense.Text = "Calculate";
            this.calculateExpense.UseVisualStyleBackColor = false;
            this.calculateExpense.Click += new System.EventHandler(this.calculateExpense_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Montserrat Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitle.Location = new System.Drawing.Point(114, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(709, 44);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Accounting Management: Corporate Expense";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(961, 608);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.calculateExpense);
            this.Controls.Add(this.resultList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Corporate Expense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.Button calculateExpense;
        private System.Windows.Forms.Label lblTitle;
    }
}

