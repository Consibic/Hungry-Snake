namespace HungrySnake
{
    partial class SnakeForm
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.snakePanel = new System.Windows.Forms.Panel();
            this.difCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(225, 463);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(102, 34);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(356, 463);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(102, 34);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.AutoSize = true;
            this.scoreDisplay.Location = new System.Drawing.Point(88, 474);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(47, 13);
            this.scoreDisplay.TabIndex = 2;
            this.scoreDisplay.Text = "Score: 0";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // snakePanel
            // 
            this.snakePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snakePanel.Location = new System.Drawing.Point(0, 0);
            this.snakePanel.Name = "snakePanel";
            this.snakePanel.Size = new System.Drawing.Size(700, 440);
            this.snakePanel.TabIndex = 3;
            // 
            // difCombo
            // 
            this.difCombo.FormattingEnabled = true;
            this.difCombo.Location = new System.Drawing.Point(530, 471);
            this.difCombo.Name = "difCombo";
            this.difCombo.Size = new System.Drawing.Size(103, 21);
            this.difCombo.TabIndex = 4;
            this.difCombo.Text = "-Difficulty-";
            this.difCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difCombo.DataSource = new[] { "Easy", "Middle", "Difficult" };
            this.difCombo.SelectedIndexChanged += new System.EventHandler(this.difCombo_SelectedIndexChanged);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 519);
            this.Controls.Add(this.difCombo);
            this.Controls.Add(this.snakePanel);
            this.Controls.Add(this.scoreDisplay);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(716, 557);
            this.MinimumSize = new System.Drawing.Size(716, 557);
            this.Name = "SnakeForm";
            this.Text = "Hungry Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.snakeForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel snakePanel;
        private System.Windows.Forms.ComboBox difCombo;
    }
}

