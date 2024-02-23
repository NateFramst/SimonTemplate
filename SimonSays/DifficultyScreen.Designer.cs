namespace SimonSays
{
    partial class DifficultyScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.normalButton = new System.Windows.Forms.Button();
            this.reverseButton = new System.Windows.Forms.Button();
            this.SoundButton = new System.Windows.Forms.Button();
            this.movingButton = new System.Windows.Forms.Button();
            this.impossibleButton = new System.Windows.Forms.Button();
            this.pinWheelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DifficultyLabel.Location = new System.Drawing.Point(36, 34);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(219, 51);
            this.DifficultyLabel.TabIndex = 0;
            this.DifficultyLabel.Text = "DIFFICULTY";
            // 
            // normalButton
            // 
            this.normalButton.Location = new System.Drawing.Point(106, 97);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(75, 23);
            this.normalButton.TabIndex = 1;
            this.normalButton.Text = "Normal";
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // reverseButton
            // 
            this.reverseButton.Location = new System.Drawing.Point(106, 126);
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(75, 23);
            this.reverseButton.TabIndex = 2;
            this.reverseButton.Text = "Reverse";
            this.reverseButton.UseVisualStyleBackColor = true;
            this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
            // 
            // SoundButton
            // 
            this.SoundButton.Location = new System.Drawing.Point(106, 155);
            this.SoundButton.Name = "SoundButton";
            this.SoundButton.Size = new System.Drawing.Size(75, 23);
            this.SoundButton.TabIndex = 3;
            this.SoundButton.Text = "Sound";
            this.SoundButton.UseVisualStyleBackColor = true;
            this.SoundButton.Click += new System.EventHandler(this.soundButton_Click);
            // 
            // movingButton
            // 
            this.movingButton.Location = new System.Drawing.Point(106, 184);
            this.movingButton.Name = "movingButton";
            this.movingButton.Size = new System.Drawing.Size(75, 23);
            this.movingButton.TabIndex = 4;
            this.movingButton.Text = "Moving";
            this.movingButton.UseVisualStyleBackColor = true;
            this.movingButton.Click += new System.EventHandler(this.movingButton_Click);
            // 
            // impossibleButton
            // 
            this.impossibleButton.Location = new System.Drawing.Point(106, 274);
            this.impossibleButton.Name = "impossibleButton";
            this.impossibleButton.Size = new System.Drawing.Size(75, 23);
            this.impossibleButton.TabIndex = 5;
            this.impossibleButton.Text = "Impossible";
            this.impossibleButton.UseVisualStyleBackColor = true;
            this.impossibleButton.Click += new System.EventHandler(this.impossibleButton_Click);
            // 
            // pinWheelButton
            // 
            this.pinWheelButton.Location = new System.Drawing.Point(106, 213);
            this.pinWheelButton.Name = "pinWheelButton";
            this.pinWheelButton.Size = new System.Drawing.Size(75, 23);
            this.pinWheelButton.TabIndex = 6;
            this.pinWheelButton.Text = "Pinwheel";
            this.pinWheelButton.UseVisualStyleBackColor = true;
            this.pinWheelButton.Click += new System.EventHandler(this.pinWheelButton_Click);
            // 
            // DifficultyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.pinWheelButton);
            this.Controls.Add(this.impossibleButton);
            this.Controls.Add(this.movingButton);
            this.Controls.Add(this.SoundButton);
            this.Controls.Add(this.reverseButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.DifficultyLabel);
            this.Name = "DifficultyScreen";
            this.Size = new System.Drawing.Size(300, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button reverseButton;
        private System.Windows.Forms.Button SoundButton;
        private System.Windows.Forms.Button movingButton;
        private System.Windows.Forms.Button impossibleButton;
        private System.Windows.Forms.Button pinWheelButton;
    }
}
