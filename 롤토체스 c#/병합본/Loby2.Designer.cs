namespace game00
{
    partial class Loby2
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
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.확인;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(422, 660);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(211, 46);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.닫기1;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Location = new System.Drawing.Point(1250, 7);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(21, 18);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button2_Click;
            // 
            // button7
            // 
            button7.BackgroundImage = Properties.Resources.KakaoTalk_20241017_175730237;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button7.Location = new System.Drawing.Point(249, 24);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(48, 39);
            button7.TabIndex = 10;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.KakaoTalk_20241017_1757472851;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Location = new System.Drawing.Point(820, 20);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(50, 41);
            button4.TabIndex = 11;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button3_Click;
            // 
            // Loby2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.로비1;
            ClientSize = new System.Drawing.Size(1280, 720);
            Controls.Add(button4);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Loby2";
            Text = "Loby2";
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
    }
}