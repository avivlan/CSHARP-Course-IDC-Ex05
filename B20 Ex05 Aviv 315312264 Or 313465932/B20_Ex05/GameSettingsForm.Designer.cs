namespace B20_Ex05
{
    partial class GameSettingsForm
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
            this.firstPlayerLabel = new System.Windows.Forms.Label();
            this.secondPlayerLabel = new System.Windows.Forms.Label();
            this.firstPlayerText = new System.Windows.Forms.TextBox();
            this.secondPlayerText = new System.Windows.Forms.TextBox();
            this.isComputerButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerLabel
            // 
            this.firstPlayerLabel.AutoSize = true;
            this.firstPlayerLabel.Location = new System.Drawing.Point(13, 13);
            this.firstPlayerLabel.Name = "firstPlayerLabel";
            this.firstPlayerLabel.Size = new System.Drawing.Size(124, 17);
            this.firstPlayerLabel.TabIndex = 0;
            this.firstPlayerLabel.Text = "First Player Name:";
            // 
            // secondPlayerLabel
            // 
            this.secondPlayerLabel.AutoSize = true;
            this.secondPlayerLabel.Location = new System.Drawing.Point(13, 51);
            this.secondPlayerLabel.Name = "secondPlayerLabel";
            this.secondPlayerLabel.Size = new System.Drawing.Size(145, 17);
            this.secondPlayerLabel.TabIndex = 1;
            this.secondPlayerLabel.Text = "Second Player Name:";
            // 
            // firstPlayerText
            // 
            this.firstPlayerText.Location = new System.Drawing.Point(184, 10);
            this.firstPlayerText.Name = "firstPlayerText";
            this.firstPlayerText.Size = new System.Drawing.Size(142, 22);
            this.firstPlayerText.TabIndex = 2;
            this.firstPlayerText.TextChanged += new System.EventHandler(this.firstPlayerText_TextChanged);
            // 
            // secondPlayerText
            // 
            this.secondPlayerText.Enabled = false;
            this.secondPlayerText.Location = new System.Drawing.Point(184, 45);
            this.secondPlayerText.Name = "secondPlayerText";
            this.secondPlayerText.Size = new System.Drawing.Size(142, 22);
            this.secondPlayerText.TabIndex = 3;
            this.secondPlayerText.Text = "- computer -";
            // 
            // isComputerButton
            // 
            this.isComputerButton.Location = new System.Drawing.Point(332, 42);
            this.isComputerButton.Name = "isComputerButton";
            this.isComputerButton.Size = new System.Drawing.Size(122, 28);
            this.isComputerButton.TabIndex = 4;
            this.isComputerButton.Text = "Against a Friend";
            this.isComputerButton.UseVisualStyleBackColor = true;
            this.isComputerButton.Click += new System.EventHandler(this.isComputerButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.startButton.Location = new System.Drawing.Point(332, 234);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(122, 40);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(16, 139);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(81, 17);
            this.boardSizeLabel.TabIndex = 6;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.boardSizeButton.Location = new System.Drawing.Point(19, 160);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(164, 114);
            this.boardSizeButton.TabIndex = 7;
            this.boardSizeButton.Text = "4 x 4";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 281);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.isComputerButton);
            this.Controls.Add(this.secondPlayerText);
            this.Controls.Add(this.firstPlayerText);
            this.Controls.Add(this.secondPlayerLabel);
            this.Controls.Add(this.firstPlayerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameSettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerLabel;
        private System.Windows.Forms.Label secondPlayerLabel;
        private System.Windows.Forms.TextBox firstPlayerText;
        private System.Windows.Forms.TextBox secondPlayerText;
        private System.Windows.Forms.Button isComputerButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Button boardSizeButton;
    }
}