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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btLitA);
            this.pnlTop.Controls.Add(this.btLitO);
            this.pnlTop.Controls.Add(this.btLitAE);
            this.pnlTop.Controls.Add(this.btNext);
            this.pnlTop.Controls.Add(this.btPrev);
            this.pnlTop.Controls.Add(this.tbSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(594, 48);
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
            // 
            // btLitO
            // 
            this.btLitO.Location = new System.Drawing.Point(264, 11);
            this.btLitO.Name = "btLitO";
            this.btLitO.Size = new System.Drawing.Size(40, 23);
            this.btLitO.TabIndex = 4;
            this.btLitO.Text = "Ø";
            this.btLitO.UseVisualStyleBackColor = true;
            // 
            // btLitAE
            // 
            this.btLitAE.Location = new System.Drawing.Point(218, 11);
            this.btLitAE.Name = "btLitAE";
            this.btLitAE.Size = new System.Drawing.Size(40, 23);
            this.btLitAE.TabIndex = 3;
            this.btLitAE.Text = "Æ";
            this.btLitAE.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(507, 12);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 2;
            this.btNext.Text = ">>";
            this.btNext.UseVisualStyleBackColor = true;
            // 
            // btPrev
            // 
            this.btPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrev.Location = new System.Drawing.Point(425, 12);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(75, 23);
            this.btPrev.TabIndex = 1;
            this.btPrev.Text = "<<";
            this.btPrev.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(13, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(187, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 48);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(594, 214);
            this.pnlContent.TabIndex = 1;
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
        private System.Windows.Forms.Panel pnlContent;
    }
}

