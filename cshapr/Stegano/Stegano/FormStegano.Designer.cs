namespace Stegano
{
    partial class FormStegano
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDownloadImage = new System.Windows.Forms.Button();
            this.buttonLSB = new System.Windows.Forms.Button();
            this.buttonBitExtraction = new System.Windows.Forms.Button();
            this.buttonChannelHistogram = new System.Windows.Forms.Button();
            this.buttonGrayMode = new System.Windows.Forms.Button();
            this.buttonOriginalImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonDownloadImage);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLSB);
            this.splitContainer1.Panel1.Controls.Add(this.buttonBitExtraction);
            this.splitContainer1.Panel1.Controls.Add(this.buttonChannelHistogram);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGrayMode);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOriginalImage);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMain);
            this.splitContainer1.Size = new System.Drawing.Size(907, 506);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonDownloadImage
            // 
            this.buttonDownloadImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownloadImage.Location = new System.Drawing.Point(10, 471);
            this.buttonDownloadImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDownloadImage.Name = "buttonDownloadImage";
            this.buttonDownloadImage.Size = new System.Drawing.Size(263, 26);
            this.buttonDownloadImage.TabIndex = 6;
            this.buttonDownloadImage.Text = "Выбрать файл";
            this.buttonDownloadImage.UseVisualStyleBackColor = true;
            this.buttonDownloadImage.Click += new System.EventHandler(this.buttonDownloadImage_Click);
            // 
            // buttonLSB
            // 
            this.buttonLSB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLSB.Enabled = false;
            this.buttonLSB.Location = new System.Drawing.Point(9, 235);
            this.buttonLSB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLSB.Name = "buttonLSB";
            this.buttonLSB.Size = new System.Drawing.Size(261, 32);
            this.buttonLSB.TabIndex = 5;
            this.buttonLSB.Text = "Получение данных (LSB)";
            this.buttonLSB.UseVisualStyleBackColor = true;
            this.buttonLSB.Click += new System.EventHandler(this.buttonLSB_Click);
            // 
            // buttonBitExtraction
            // 
            this.buttonBitExtraction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBitExtraction.Enabled = false;
            this.buttonBitExtraction.Location = new System.Drawing.Point(10, 195);
            this.buttonBitExtraction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBitExtraction.Name = "buttonBitExtraction";
            this.buttonBitExtraction.Size = new System.Drawing.Size(261, 32);
            this.buttonBitExtraction.TabIndex = 4;
            this.buttonBitExtraction.Text = "Выделение битов";
            this.buttonBitExtraction.UseVisualStyleBackColor = true;
            this.buttonBitExtraction.Click += new System.EventHandler(this.buttonBitExtraction_Click);
            // 
            // buttonChannelHistogram
            // 
            this.buttonChannelHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChannelHistogram.Enabled = false;
            this.buttonChannelHistogram.Location = new System.Drawing.Point(10, 154);
            this.buttonChannelHistogram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonChannelHistogram.Name = "buttonChannelHistogram";
            this.buttonChannelHistogram.Size = new System.Drawing.Size(261, 32);
            this.buttonChannelHistogram.TabIndex = 3;
            this.buttonChannelHistogram.Text = "Гистограмма каналов";
            this.buttonChannelHistogram.UseVisualStyleBackColor = true;
            this.buttonChannelHistogram.Click += new System.EventHandler(this.buttonChannelHistogram_Click);
            // 
            // buttonGrayMode
            // 
            this.buttonGrayMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGrayMode.Enabled = false;
            this.buttonGrayMode.Location = new System.Drawing.Point(9, 114);
            this.buttonGrayMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGrayMode.Name = "buttonGrayMode";
            this.buttonGrayMode.Size = new System.Drawing.Size(261, 32);
            this.buttonGrayMode.TabIndex = 2;
            this.buttonGrayMode.Text = "Оттенки серого";
            this.buttonGrayMode.UseVisualStyleBackColor = true;
            this.buttonGrayMode.Click += new System.EventHandler(this.buttonGrayMode_Click);
            // 
            // buttonOriginalImage
            // 
            this.buttonOriginalImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOriginalImage.Enabled = false;
            this.buttonOriginalImage.Location = new System.Drawing.Point(10, 73);
            this.buttonOriginalImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOriginalImage.Name = "buttonOriginalImage";
            this.buttonOriginalImage.Size = new System.Drawing.Size(261, 32);
            this.buttonOriginalImage.TabIndex = 1;
            this.buttonOriginalImage.Text = "Оригинальное изображение";
            this.buttonOriginalImage.UseVisualStyleBackColor = true;
            this.buttonOriginalImage.Click += new System.EventHandler(this.buttonOriginalImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sansation", 25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stegano";
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(626, 506);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // FormStegano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 506);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Sansation", 12F);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormStegano";
            this.Text = "Stegano (SerKin0)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOriginalImage;
        private System.Windows.Forms.Button buttonDownloadImage;
        private System.Windows.Forms.Button buttonLSB;
        private System.Windows.Forms.Button buttonBitExtraction;
        private System.Windows.Forms.Button buttonChannelHistogram;
        private System.Windows.Forms.Button buttonGrayMode;
        private System.Windows.Forms.PictureBox pictureBoxMain;
    }
}