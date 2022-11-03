namespace Kursyak
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sheet = new System.Windows.Forms.PictureBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.dataGridViewMatrix1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewMatrix2 = new System.Windows.Forms.DataGridView();
            this.buttonFW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix2)).BeginInit();
            this.SuspendLayout();
            // 
            // sheet
            // 
            this.sheet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sheet.BackColor = System.Drawing.Color.Lavender;
            this.sheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheet.Location = new System.Drawing.Point(2, 2);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(367, 457);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.selectButton.AutoSize = true;
            this.selectButton.Location = new System.Drawing.Point(17, 466);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(60, 34);
            this.selectButton.TabIndex = 14;
            this.selectButton.Text = "Cursor";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteALLButton.AutoSize = true;
            this.deleteALLButton.Location = new System.Drawing.Point(289, 466);
            this.deleteALLButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(60, 34);
            this.deleteALLButton.TabIndex = 13;
            this.deleteALLButton.Text = "DelAll";
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteButton.AutoSize = true;
            this.deleteButton.Location = new System.Drawing.Point(221, 466);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(60, 34);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.drawEdgeButton.AutoSize = true;
            this.drawEdgeButton.Location = new System.Drawing.Point(153, 466);
            this.drawEdgeButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(60, 34);
            this.drawEdgeButton.TabIndex = 11;
            this.drawEdgeButton.Text = "Edge";
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.drawVertexButton.AutoSize = true;
            this.drawVertexButton.Location = new System.Drawing.Point(85, 466);
            this.drawVertexButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(60, 34);
            this.drawVertexButton.TabIndex = 10;
            this.drawVertexButton.Text = "Vertex";
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // buttonAdj
            // 
            this.buttonAdj.Location = new System.Drawing.Point(496, 4);
            this.buttonAdj.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(191, 31);
            this.buttonAdj.TabIndex = 16;
            this.buttonAdj.Text = "Матрица смежности ";
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // dataGridViewMatrix1
            // 
            this.dataGridViewMatrix1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMatrix1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatrix1.Location = new System.Drawing.Point(387, 42);
            this.dataGridViewMatrix1.Name = "dataGridViewMatrix1";
            this.dataGridViewMatrix1.RowHeadersWidth = 51;
            this.dataGridViewMatrix1.RowTemplate.Height = 24;
            this.dataGridViewMatrix1.Size = new System.Drawing.Size(412, 205);
            this.dataGridViewMatrix1.TabIndex = 17;
            // 
            // dataGridViewMatrix2
            // 
            this.dataGridViewMatrix2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMatrix2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatrix2.Location = new System.Drawing.Point(387, 295);
            this.dataGridViewMatrix2.Name = "dataGridViewMatrix2";
            this.dataGridViewMatrix2.RowHeadersWidth = 51;
            this.dataGridViewMatrix2.RowTemplate.Height = 24;
            this.dataGridViewMatrix2.Size = new System.Drawing.Size(412, 205);
            this.dataGridViewMatrix2.TabIndex = 18;
            // 
            // buttonFW
            // 
            this.buttonFW.Location = new System.Drawing.Point(496, 257);
            this.buttonFW.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFW.Name = "buttonFW";
            this.buttonFW.Size = new System.Drawing.Size(191, 31);
            this.buttonFW.TabIndex = 19;
            this.buttonFW.Text = "Алг. Флойда-Уоршелла";
            this.buttonFW.UseVisualStyleBackColor = true;
            this.buttonFW.Click += new System.EventHandler(this.buttonFW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(811, 513);
            this.Controls.Add(this.buttonFW);
            this.Controls.Add(this.dataGridViewMatrix2);
            this.Controls.Add(this.dataGridViewMatrix1);
            this.Controls.Add(this.buttonAdj);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Флойд-Уоршелл-Клини";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button buttonAdj;
        private System.Windows.Forms.DataGridView dataGridViewMatrix1;
        private System.Windows.Forms.DataGridView dataGridViewMatrix2;
        private System.Windows.Forms.Button buttonFW;
    }
}

