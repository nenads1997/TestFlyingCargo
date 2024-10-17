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
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonUPD = new Button();
            buttonDEL = new Button();
            label2 = new Label();
            textBoxName = new TextBox();
            label3 = new Label();
            textBoxPrice = new TextBox();
            label4 = new Label();
            textBoxDesc = new TextBox();
            label5 = new Label();
            textBoxStock = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 206);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(534, 178);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(59, 44);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(160, 39);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "ADD";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUPD
            // 
            buttonUPD.Location = new Point(242, 44);
            buttonUPD.Name = "buttonUPD";
            buttonUPD.Size = new Size(160, 39);
            buttonUPD.TabIndex = 2;
            buttonUPD.Text = "UPDATE FROM GRID";
            buttonUPD.UseVisualStyleBackColor = true;
            buttonUPD.Click += buttonUPD_Click;
            // 
            // buttonDEL
            // 
            buttonDEL.Location = new Point(417, 44);
            buttonDEL.Name = "buttonDEL";
            buttonDEL.Size = new Size(160, 39);
            buttonDEL.TabIndex = 4;
            buttonDEL.Text = "DELETE SELECTED";
            buttonDEL.UseVisualStyleBackColor = true;
            buttonDEL.Click += buttonDEL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 115);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 7;
            label2.Text = "Product name:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(150, 115);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 151);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 9;
            label3.Text = "Price:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(150, 148);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(100, 23);
            textBoxPrice.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(273, 118);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 11;
            label4.Text = "Description: ";
            // 
            // textBoxDesc
            // 
            textBoxDesc.Location = new Point(365, 115);
            textBoxDesc.Name = "textBoxDesc";
            textBoxDesc.Size = new Size(100, 23);
            textBoxDesc.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(273, 151);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 13;
            label5.Text = "Stock quantity:";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(365, 148);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(100, 23);
            textBoxStock.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(491, 131);
            button1.Name = "button1";
            button1.Size = new Size(102, 25);
            button1.TabIndex = 15;
            button1.Text = "UNSELECT ALL";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBoxStock);
            Controls.Add(label5);
            Controls.Add(textBoxDesc);
            Controls.Add(label4);
            Controls.Add(textBoxPrice);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(buttonDEL);
            Controls.Add(buttonUPD);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonUPD;
        private Button buttonDEL;
        private Label label2;
        private TextBox textBoxName;
        private Label label3;
        private TextBox textBoxPrice;
        private Label label4;
        private TextBox textBoxDesc;
        private Label label5;
        private TextBox textBoxStock;
        private Button button1;
    }
}
