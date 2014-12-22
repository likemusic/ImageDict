namespace ImageDict
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.btLitA = new System.Windows.Forms.Button();
            this.btLitO = new System.Windows.Forms.Button();
            this.btLitAE = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnScaleMinus = new System.Windows.Forms.Button();
            this.btnScalePlus = new System.Windows.Forms.Button();
            this.pnlContent = new ImageDict.Controls.SelectablePanel();
            this.pbContent = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.btnScalePlus);
            this.pnlTop.Controls.Add(this.btnScaleMinus);
            this.pnlTop.Controls.Add(this.cbScale);
            this.pnlTop.Controls.Add(this.btLitA);
            this.pnlTop.Controls.Add(this.btLitO);
            this.pnlTop.Controls.Add(this.btLitAE);
            this.pnlTop.Controls.Add(this.btNext);
            this.pnlTop.Controls.Add(this.btPrev);
            this.pnlTop.Controls.Add(this.tbSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(594, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // cbScale
            // 
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Items.AddRange(new object[] {
            "500%",
            "250%",
            "200%",
            "125%",
            "100%",
            "75%",
            "50%",
            "25%",
            "20%",
            "10%",
            "5%"});
            this.cbScale.Location = new System.Drawing.Point(365, 13);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(121, 21);
            this.cbScale.TabIndex = 6;
            this.cbScale.Text = "100%";
            this.cbScale.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // btLitA
            // 
            this.btLitA.Location = new System.Drawing.Point(310, 11);
            this.btLitA.Name = "btLitA";
            this.btLitA.Size = new System.Drawing.Size(40, 23);
            this.btLitA.TabIndex = 5;
            this.btLitA.Text = "Å";
            this.btLitA.UseVisualStyleBackColor = true;
            this.btLitA.Click += new System.EventHandler(this.btLitA_Click);
            // 
            // btLitO
            // 
            this.btLitO.Location = new System.Drawing.Point(264, 11);
            this.btLitO.Name = "btLitO";
            this.btLitO.Size = new System.Drawing.Size(40, 23);
            this.btLitO.TabIndex = 4;
            this.btLitO.Text = "Ø";
            this.btLitO.UseVisualStyleBackColor = true;
            this.btLitO.Click += new System.EventHandler(this.btLitO_Click);
            // 
            // btLitAE
            // 
            this.btLitAE.Location = new System.Drawing.Point(218, 11);
            this.btLitAE.Name = "btLitAE";
            this.btLitAE.Size = new System.Drawing.Size(40, 23);
            this.btLitAE.TabIndex = 3;
            this.btLitAE.Text = "Æ";
            this.btLitAE.UseVisualStyleBackColor = true;
            this.btLitAE.Click += new System.EventHandler(this.btLitAE_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(110, 45);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 2;
            this.btNext.Text = ">>";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPrev
            // 
            this.btPrev.Enabled = false;
            this.btPrev.Location = new System.Drawing.Point(28, 45);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(75, 23);
            this.btPrev.TabIndex = 1;
            this.btPrev.Text = "<<";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(13, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(187, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnScaleMinus
            // 
            this.btnScaleMinus.AutoSize = true;
            this.btnScaleMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnScaleMinus.Location = new System.Drawing.Point(492, 12);
            this.btnScaleMinus.Name = "btnScaleMinus";
            this.btnScaleMinus.Size = new System.Drawing.Size(25, 23);
            this.btnScaleMinus.TabIndex = 7;
            this.btnScaleMinus.Text = "-";
            this.btnScaleMinus.UseVisualStyleBackColor = true;
            this.btnScaleMinus.Click += new System.EventHandler(this.btnScaleMinus_Click);
            // 
            // btnScalePlus
            // 
            this.btnScalePlus.AutoSize = true;
            this.btnScalePlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnScalePlus.Location = new System.Drawing.Point(520, 12);
            this.btnScalePlus.Name = "btnScalePlus";
            this.btnScalePlus.Size = new System.Drawing.Size(25, 23);
            this.btnScalePlus.TabIndex = 8;
            this.btnScalePlus.Text = "+";
            this.btnScalePlus.UseVisualStyleBackColor = true;
            this.btnScalePlus.Click += new System.EventHandler(this.btnScalePlus_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlContent.Controls.Add(this.pbContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(594, 182);
            this.pnlContent.TabIndex = 6;
            this.pnlContent.TabStop = true;
            this.pnlContent.Click += new System.EventHandler(this.pnlContent_Click);
            this.pnlContent.Resize += new System.EventHandler(this.pnlContent_Resize);
            // 
            // pbContent
            // 
            this.pbContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbContent.Location = new System.Drawing.Point(0, 0);
            this.pbContent.Name = "pbContent";
            this.pbContent.Size = new System.Drawing.Size(100, 50);
            this.pbContent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbContent.TabIndex = 1;
            this.pbContent.TabStop = false;
            this.pbContent.Click += new System.EventHandler(this.pbContent_Click);
            this.pbContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbContent_MouseDown);
            this.pbContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbContent_MouseMove);
            this.pbContent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbContent_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 262);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Name = "Main";
            this.Text = "ImageDict";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btLitA;
        private System.Windows.Forms.Button btLitO;
        private System.Windows.Forms.Button btLitAE;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.PictureBox pbContent;
        //private ImageDict.Controls.SelectablePictureBox pbContent;
        //private System.Windows.Forms.Panel pnlContent;
        private ImageDict.Controls.SelectablePanel pnlContent;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Button btnScalePlus;
        private System.Windows.Forms.Button btnScaleMinus;
    }
}

