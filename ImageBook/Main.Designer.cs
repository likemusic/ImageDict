namespace ImageBook
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
            this.btLitA = new System.Windows.Forms.Button();
            this.btLitO = new System.Windows.Forms.Button();
            this.btLitAE = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbContetn = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContetn)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // pbContetn
            // 
            this.pbContetn.Location = new System.Drawing.Point(0, 0);
            this.pbContetn.Name = "pbContetn";
            this.pbContetn.Size = new System.Drawing.Size(100, 50);
            this.pbContetn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbContetn.TabIndex = 1;
            this.pbContetn.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlContent.Controls.Add(this.pbContetn);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(594, 182);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Resize += new System.EventHandler(this.pnlContent_Resize);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 262);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Name = "Main";
            this.Text = "ImageBook";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContetn)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
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
        private System.Windows.Forms.PictureBox pbContetn;
        private System.Windows.Forms.Panel pnlContent;
    }
}

