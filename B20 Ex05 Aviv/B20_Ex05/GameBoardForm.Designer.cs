namespace B20_Ex05
{
    partial class GameBoardForm
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
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.secondPlayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPlayerLabel
            // 
            this.firstPlayerLabel.AutoSize = true;
            this.firstPlayerLabel.Location = new System.Drawing.Point(12, 406);
            this.firstPlayerLabel.Name = "firstPlayerLabel";
            this.firstPlayerLabel.Size = new System.Drawing.Size(79, 17);
            this.firstPlayerLabel.TabIndex = 0;
            this.firstPlayerLabel.Text = "Player One";
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Location = new System.Drawing.Point(12, 378);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(103, 17);
            this.currentPlayerLabel.TabIndex = 1;
            this.currentPlayerLabel.Text = "Current Player:";
            // 
            // secondPlayerLabel
            // 
            this.secondPlayerLabel.AutoSize = true;
            this.secondPlayerLabel.Location = new System.Drawing.Point(12, 435);
            this.secondPlayerLabel.Name = "secondPlayerLabel";
            this.secondPlayerLabel.Size = new System.Drawing.Size(78, 17);
            this.secondPlayerLabel.TabIndex = 2;
            this.secondPlayerLabel.Text = "Player Two";
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 481);
            this.Controls.Add(this.secondPlayerLabel);
            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.firstPlayerLabel);
            this.Name = "GameBoardForm";
            this.Text = "GameBoardForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameBoardForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerLabel;
        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Label secondPlayerLabel;
    }
}