﻿namespace Snake
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGameOverfc = new System.Windows.Forms.Label();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // lblGameOverfc
            // 
            this.lblGameOverfc.AutoSize = true;
            this.lblGameOverfc.Location = new System.Drawing.Point(240, 56);
            this.lblGameOverfc.Name = "lblGameOverfc";
            this.lblGameOverfc.Size = new System.Drawing.Size(35, 13);
            this.lblGameOverfc.TabIndex = 1;
            this.lblGameOverfc.Text = "label2";
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbCanvas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCanvas.Location = new System.Drawing.Point(6, 8);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(591, 511);
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(716, 521);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.lblGameOverfc);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Snake - The game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGameOverfc;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer gameTimer;
    }
}

