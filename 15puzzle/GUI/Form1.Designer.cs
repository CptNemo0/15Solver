namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadButton = new Button();
            solveButton = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            solutionBox = new TextBox();
            moveCountBox = new TextBox();
            visitedStatesBox = new TextBox();
            processedStatesBox = new TextBox();
            timeBox = new TextBox();
            exportButton = new Button();
            picker = new DomainUpDown();
            fileNameBox = new TextBox();
            orderPicker = new DomainUpDown();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.BackColor = Color.FromArgb(55, 59, 64);
            loadButton.ForeColor = Color.FromArgb(202, 219, 235);
            loadButton.Location = new Point(12, 12);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(96, 23);
            loadButton.TabIndex = 0;
            loadButton.Text = "Load puzzle";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // solveButton
            // 
            solveButton.BackColor = Color.FromArgb(55, 59, 64);
            solveButton.ForeColor = Color.FromArgb(202, 219, 235);
            solveButton.Location = new Point(216, 42);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(213, 23);
            solveButton.TabIndex = 2;
            solveButton.Text = "Solve!";
            solveButton.UseVisualStyleBackColor = false;
            solveButton.Click += solveButton_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(55, 59, 64);
            textBox2.ForeColor = Color.FromArgb(202, 219, 235);
            textBox2.Location = new Point(12, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(96, 23);
            textBox2.TabIndex = 3;
            textBox2.Text = "Solution";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(55, 59, 64);
            textBox3.ForeColor = Color.FromArgb(202, 219, 235);
            textBox3.Location = new Point(12, 109);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(96, 23);
            textBox3.TabIndex = 4;
            textBox3.Text = "Move Count";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(55, 59, 64);
            textBox4.ForeColor = Color.FromArgb(202, 219, 235);
            textBox4.Location = new Point(12, 138);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(96, 23);
            textBox4.TabIndex = 5;
            textBox4.Text = "Visited States";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(55, 59, 64);
            textBox5.ForeColor = Color.FromArgb(202, 219, 235);
            textBox5.Location = new Point(12, 167);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(96, 23);
            textBox5.TabIndex = 6;
            textBox5.Text = "Processed States";
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(55, 59, 64);
            textBox6.ForeColor = Color.FromArgb(202, 219, 235);
            textBox6.Location = new Point(12, 196);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(96, 23);
            textBox6.TabIndex = 7;
            textBox6.Text = "Time";
            // 
            // solutionBox
            // 
            solutionBox.BackColor = Color.FromArgb(55, 59, 64);
            solutionBox.ForeColor = Color.FromArgb(202, 219, 235);
            solutionBox.Location = new Point(114, 80);
            solutionBox.Name = "solutionBox";
            solutionBox.Size = new Size(315, 23);
            solutionBox.TabIndex = 8;
            // 
            // moveCountBox
            // 
            moveCountBox.BackColor = Color.FromArgb(55, 59, 64);
            moveCountBox.ForeColor = Color.FromArgb(202, 219, 235);
            moveCountBox.Location = new Point(114, 109);
            moveCountBox.Name = "moveCountBox";
            moveCountBox.Size = new Size(315, 23);
            moveCountBox.TabIndex = 9;
            // 
            // visitedStatesBox
            // 
            visitedStatesBox.BackColor = Color.FromArgb(55, 59, 64);
            visitedStatesBox.ForeColor = Color.FromArgb(202, 219, 235);
            visitedStatesBox.Location = new Point(114, 138);
            visitedStatesBox.Name = "visitedStatesBox";
            visitedStatesBox.Size = new Size(315, 23);
            visitedStatesBox.TabIndex = 10;
            // 
            // processedStatesBox
            // 
            processedStatesBox.BackColor = Color.FromArgb(55, 59, 64);
            processedStatesBox.ForeColor = Color.FromArgb(202, 219, 235);
            processedStatesBox.Location = new Point(114, 167);
            processedStatesBox.Name = "processedStatesBox";
            processedStatesBox.Size = new Size(315, 23);
            processedStatesBox.TabIndex = 11;
            // 
            // timeBox
            // 
            timeBox.BackColor = Color.FromArgb(55, 59, 64);
            timeBox.ForeColor = Color.FromArgb(202, 219, 235);
            timeBox.Location = new Point(114, 196);
            timeBox.Name = "timeBox";
            timeBox.Size = new Size(315, 23);
            timeBox.TabIndex = 12;
            // 
            // exportButton
            // 
            exportButton.BackColor = Color.FromArgb(55, 59, 64);
            exportButton.ForeColor = Color.FromArgb(202, 219, 235);
            exportButton.Location = new Point(12, 225);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(417, 23);
            exportButton.TabIndex = 13;
            exportButton.Text = "Export Data";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
            // 
            // picker
            // 
            picker.BackColor = Color.FromArgb(55, 59, 64);
            picker.ForeColor = Color.FromArgb(202, 219, 235);
            picker.Items.Add("BFS");
            picker.Items.Add("DFS");
            picker.Items.Add("Manhattan");
            picker.Items.Add("Hammington");
            picker.Location = new Point(12, 41);
            picker.Name = "picker";
            picker.Size = new Size(96, 23);
            picker.TabIndex = 14;
            picker.Text = "Algorithm";
            picker.SelectedItemChanged += picker_SelectedItemChanged;
            // 
            // fileNameBox
            // 
            fileNameBox.BackColor = Color.FromArgb(55, 59, 64);
            fileNameBox.ForeColor = Color.FromArgb(202, 219, 235);
            fileNameBox.Location = new Point(114, 13);
            fileNameBox.Name = "fileNameBox";
            fileNameBox.Size = new Size(315, 23);
            fileNameBox.TabIndex = 1;
            // 
            // orderPicker
            // 
            orderPicker.BackColor = Color.FromArgb(55, 59, 64);
            orderPicker.ForeColor = Color.FromArgb(202, 219, 235);
            orderPicker.Items.Add("DRLU");
            orderPicker.Items.Add("DRUL");
            orderPicker.Items.Add("LUDR");
            orderPicker.Items.Add("LURD");
            orderPicker.Items.Add("RDLU");
            orderPicker.Items.Add("RDUL");
            orderPicker.Items.Add("ULDR");
            orderPicker.Items.Add("LURD");
            orderPicker.Location = new Point(114, 41);
            orderPicker.Name = "orderPicker";
            orderPicker.Size = new Size(96, 23);
            orderPicker.TabIndex = 15;
            orderPicker.Text = "Order";
            orderPicker.SelectedItemChanged += orderPicker_SelectedItemChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(441, 257);
            Controls.Add(orderPicker);
            Controls.Add(picker);
            Controls.Add(exportButton);
            Controls.Add(timeBox);
            Controls.Add(processedStatesBox);
            Controls.Add(visitedStatesBox);
            Controls.Add(moveCountBox);
            Controls.Add(solutionBox);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(solveButton);
            Controls.Add(fileNameBox);
            Controls.Add(loadButton);
            Name = "Form1";
            Text = "15 solver";
            TransparencyKey = Color.White;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadButton;
        private Button solveButton;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox solutionBox;
        private TextBox moveCountBox;
        private TextBox visitedStatesBox;
        private TextBox processedStatesBox;
        private TextBox timeBox;
        private Button exportButton;
        private DomainUpDown picker;
        private TextBox fileNameBox;
        private DomainUpDown orderPicker;
    }
}