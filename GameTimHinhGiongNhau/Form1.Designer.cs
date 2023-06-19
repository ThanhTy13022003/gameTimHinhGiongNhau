namespace GameTimHinhGiongNhau
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
            components = new System.ComponentModel.Container();
            btnRestart = new Button();
            lblStatus = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            btnLan = new Button();
            txtIP = new TextBox();
            SuspendLayout();
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnRestart.Location = new Point(640, 12);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(115, 64);
            btnRestart.TabIndex = 0;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += NewPic_Click;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(623, 111);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(173, 40);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Match or MissMatch";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 120;
            GameTimer.Tick += TimerEvent;
            // 
            // btnLan
            // 
            btnLan.Location = new Point(640, 302);
            btnLan.Name = "btnLan";
            btnLan.Size = new Size(94, 29);
            btnLan.TabIndex = 3;
            btnLan.Text = "button1";
            btnLan.UseVisualStyleBackColor = true;
            btnLan.Click += btnLan_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(640, 360);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 652);
            Controls.Add(txtIP);
            Controls.Add(btnLan);
            Controls.Add(lblStatus);
            Controls.Add(btnRestart);
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRestart;
        private Label lblStatus;
        private System.Windows.Forms.Timer GameTimer;
        private Button btnLan;
        private TextBox txtIP;
    }
}