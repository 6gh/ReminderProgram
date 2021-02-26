
namespace ReminderProgram
{
    partial class AddReminderForm
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
            this.monthnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.daynumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.yearnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minutenumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.hournumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nametextBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.repeatcomboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addbutton1 = new System.Windows.Forms.Button();
            this.previewbutton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.monthnumericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daynumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearnumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutenumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hournumericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthnumericUpDown1
            // 
            this.monthnumericUpDown1.Location = new System.Drawing.Point(25, 77);
            this.monthnumericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.monthnumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthnumericUpDown1.Name = "monthnumericUpDown1";
            this.monthnumericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.monthnumericUpDown1.TabIndex = 0;
            this.monthnumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthnumericUpDown1.ValueChanged += new System.EventHandler(this.monthnumericUpDown1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.minutenumericUpDown1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.hournumericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.yearnumericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.daynumericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monthnumericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date And Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Day";
            // 
            // daynumericUpDown1
            // 
            this.daynumericUpDown1.Location = new System.Drawing.Point(177, 77);
            this.daynumericUpDown1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.daynumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.daynumericUpDown1.Name = "daynumericUpDown1";
            this.daynumericUpDown1.Size = new System.Drawing.Size(71, 22);
            this.daynumericUpDown1.TabIndex = 1;
            this.daynumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Year";
            // 
            // yearnumericUpDown1
            // 
            this.yearnumericUpDown1.Location = new System.Drawing.Point(280, 77);
            this.yearnumericUpDown1.Maximum = new decimal(new int[] {
            2051,
            0,
            0,
            0});
            this.yearnumericUpDown1.Minimum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.yearnumericUpDown1.Name = "yearnumericUpDown1";
            this.yearnumericUpDown1.Size = new System.Drawing.Size(71, 22);
            this.yearnumericUpDown1.TabIndex = 2;
            this.yearnumericUpDown1.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.yearnumericUpDown1.ValueChanged += new System.EventHandler(this.yearnumericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Minute";
            // 
            // minutenumericUpDown1
            // 
            this.minutenumericUpDown1.Location = new System.Drawing.Point(533, 77);
            this.minutenumericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutenumericUpDown1.Name = "minutenumericUpDown1";
            this.minutenumericUpDown1.Size = new System.Drawing.Size(71, 22);
            this.minutenumericUpDown1.TabIndex = 4;
            this.minutenumericUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hour";
            // 
            // hournumericUpDown1
            // 
            this.hournumericUpDown1.Location = new System.Drawing.Point(430, 77);
            this.hournumericUpDown1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hournumericUpDown1.Name = "hournumericUpDown1";
            this.hournumericUpDown1.Size = new System.Drawing.Size(71, 22);
            this.hournumericUpDown1.TabIndex = 3;
            this.hournumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.repeatcomboBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nametextBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 264);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text And Repeats";
            // 
            // nametextBox1
            // 
            this.nametextBox1.Location = new System.Drawing.Point(6, 74);
            this.nametextBox1.Name = "nametextBox1";
            this.nametextBox1.Size = new System.Drawing.Size(602, 22);
            this.nametextBox1.TabIndex = 5;
            this.nametextBox1.Text = "Reminder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Reminder Name / Title";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Reminder Context / Text";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 150);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(602, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Your reminder is now!";
            // 
            // repeatcomboBox1
            // 
            this.repeatcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatcomboBox1.FormattingEnabled = true;
            this.repeatcomboBox1.Items.AddRange(new object[] {
            "Once",
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.repeatcomboBox1.Location = new System.Drawing.Point(6, 227);
            this.repeatcomboBox1.Name = "repeatcomboBox1";
            this.repeatcomboBox1.Size = new System.Drawing.Size(146, 24);
            this.repeatcomboBox1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Repeat Reminder:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.previewbutton1);
            this.groupBox3.Controls.Add(this.addbutton1);
            this.groupBox3.Location = new System.Drawing.Point(12, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(617, 78);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            // 
            // addbutton1
            // 
            this.addbutton1.Location = new System.Drawing.Point(148, 32);
            this.addbutton1.Name = "addbutton1";
            this.addbutton1.Size = new System.Drawing.Size(100, 30);
            this.addbutton1.TabIndex = 0;
            this.addbutton1.Text = "Add";
            this.addbutton1.UseVisualStyleBackColor = true;
            this.addbutton1.Click += new System.EventHandler(this.addbutton1_Click);
            // 
            // previewbutton1
            // 
            this.previewbutton1.Location = new System.Drawing.Point(383, 32);
            this.previewbutton1.Name = "previewbutton1";
            this.previewbutton1.Size = new System.Drawing.Size(100, 30);
            this.previewbutton1.TabIndex = 1;
            this.previewbutton1.Text = "Preview";
            this.previewbutton1.UseVisualStyleBackColor = true;
            this.previewbutton1.Click += new System.EventHandler(this.previewbutton1_Click);
            // 
            // AddReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 613);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddReminderForm";
            this.Text = "Add Reminder";
            this.Load += new System.EventHandler(this.AddReminderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthnumericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daynumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearnumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutenumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hournumericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown monthnumericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yearnumericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown daynumericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minutenumericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown hournumericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox nametextBox1;
        private System.Windows.Forms.ComboBox repeatcomboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button previewbutton1;
        private System.Windows.Forms.Button addbutton1;
    }
}