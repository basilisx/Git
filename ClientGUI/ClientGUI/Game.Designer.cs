namespace ClientGUI
{
    partial class Game
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtHealth = new System.Windows.Forms.TextBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPlayerHp = new System.Windows.Forms.TextBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.btnEmpower = new System.Windows.Forms.Button();
            this.btnShield = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Surrender";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHealth
            // 
            this.txtHealth.Location = new System.Drawing.Point(399, 37);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.ReadOnly = true;
            this.txtHealth.Size = new System.Drawing.Size(45, 20);
            this.txtHealth.TabIndex = 1;
            this.txtHealth.TextChanged += new System.EventHandler(this.txtHealth_TextChanged);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(69, 279);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 2;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "HP:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(272, 281);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(159, 59);
            this.txtLog.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(451, 281);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Enemy Turn";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(200, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 101);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtPlayerHp
            // 
            this.txtPlayerHp.Location = new System.Drawing.Point(46, 247);
            this.txtPlayerHp.Name = "txtPlayerHp";
            this.txtPlayerHp.ReadOnly = true;
            this.txtPlayerHp.Size = new System.Drawing.Size(45, 20);
            this.txtPlayerHp.TabIndex = 7;
            this.txtPlayerHp.TextChanged += new System.EventHandler(this.txtPlayerHp_TextChanged);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(12, 250);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(28, 13);
            this.lblPlayer.TabIndex = 8;
            this.lblPlayer.Text = "HP: ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(146, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 173);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(399, 81);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(84, 35);
            this.btnPicture.TabIndex = 10;
            this.btnPicture.Text = "Change Background";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // btnEmpower
            // 
            this.btnEmpower.Location = new System.Drawing.Point(166, 279);
            this.btnEmpower.Name = "btnEmpower";
            this.btnEmpower.Size = new System.Drawing.Size(75, 23);
            this.btnEmpower.TabIndex = 12;
            this.btnEmpower.Text = "Empower";
            this.btnEmpower.UseVisualStyleBackColor = true;
            this.btnEmpower.Click += new System.EventHandler(this.btnEmpower_Click);
            // 
            // btnShield
            // 
            this.btnShield.Location = new System.Drawing.Point(69, 317);
            this.btnShield.Name = "btnShield";
            this.btnShield.Size = new System.Drawing.Size(75, 23);
            this.btnShield.TabIndex = 13;
            this.btnShield.Text = "Shield";
            this.btnShield.UseVisualStyleBackColor = true;
            this.btnShield.Click += new System.EventHandler(this.btnShield_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 350);
            this.Controls.Add(this.btnShield);
            this.Controls.Add(this.btnEmpower);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.txtPlayerHp);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.txtHealth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHealth;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPlayerHp;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Button btnEmpower;
        private System.Windows.Forms.Button btnShield;
    }
}