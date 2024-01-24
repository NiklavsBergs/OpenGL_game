namespace MD_spele
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelPoints = new System.Windows.Forms.Label();
            this.buttonW = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.labelOver = new System.Windows.Forms.Label();
            this.buttonRetry = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonChangeMode = new System.Windows.Forms.Button();
            this.buttonModeLevels = new System.Windows.Forms.Button();
            this.buttonModeEndless = new System.Windows.Forms.Button();
            this.buttonModeExpert = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.timerLevel = new System.Windows.Forms.Timer(this.components);
            this.openGLControl2 = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPoints
            // 
            this.labelPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoints.AutoSize = true;
            this.labelPoints.BackColor = System.Drawing.Color.Black;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoints.ForeColor = System.Drawing.Color.White;
            this.labelPoints.Location = new System.Drawing.Point(1084, 9);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(0, 37);
            this.labelPoints.TabIndex = 1;
            // 
            // buttonW
            // 
            this.buttonW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonW.BackColor = System.Drawing.Color.Yellow;
            this.buttonW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonW.Location = new System.Drawing.Point(986, 480);
            this.buttonW.Name = "buttonW";
            this.buttonW.Size = new System.Drawing.Size(60, 60);
            this.buttonW.TabIndex = 2;
            this.buttonW.Text = "W";
            this.buttonW.UseVisualStyleBackColor = false;
            // 
            // buttonA
            // 
            this.buttonA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonA.BackColor = System.Drawing.Color.Red;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonA.Location = new System.Drawing.Point(914, 551);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(60, 60);
            this.buttonA.TabIndex = 3;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = false;
            // 
            // buttonS
            // 
            this.buttonS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS.BackColor = System.Drawing.Color.Lime;
            this.buttonS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonS.Location = new System.Drawing.Point(986, 551);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(60, 60);
            this.buttonS.TabIndex = 4;
            this.buttonS.Text = "S";
            this.buttonS.UseVisualStyleBackColor = false;
            // 
            // buttonD
            // 
            this.buttonD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonD.BackColor = System.Drawing.Color.Blue;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonD.Location = new System.Drawing.Point(1058, 551);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(60, 60);
            this.buttonD.TabIndex = 5;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = false;
            // 
            // labelOver
            // 
            this.labelOver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelOver.AutoSize = true;
            this.labelOver.BackColor = System.Drawing.Color.Black;
            this.labelOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOver.ForeColor = System.Drawing.Color.White;
            this.labelOver.Location = new System.Drawing.Point(385, 22);
            this.labelOver.Name = "labelOver";
            this.labelOver.Size = new System.Drawing.Size(0, 73);
            this.labelOver.TabIndex = 6;
            this.labelOver.Click += new System.EventHandler(this.labelOver_Click);
            // 
            // buttonRetry
            // 
            this.buttonRetry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRetry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRetry.Location = new System.Drawing.Point(438, 226);
            this.buttonRetry.Name = "buttonRetry";
            this.buttonRetry.Size = new System.Drawing.Size(246, 58);
            this.buttonRetry.TabIndex = 7;
            this.buttonRetry.Text = "Retry";
            this.buttonRetry.UseVisualStyleBackColor = true;
            this.buttonRetry.Visible = false;
            this.buttonRetry.Click += new System.EventHandler(this.buttonRetry_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.Location = new System.Drawing.Point(438, 368);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(246, 58);
            this.buttonQuit.TabIndex = 8;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Visible = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelScore
            // 
            this.labelScore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Black;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(391, 117);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 37);
            this.labelScore.TabIndex = 9;
            this.labelScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonChangeMode
            // 
            this.buttonChangeMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonChangeMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChangeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeMode.Location = new System.Drawing.Point(438, 297);
            this.buttonChangeMode.Name = "buttonChangeMode";
            this.buttonChangeMode.Size = new System.Drawing.Size(246, 58);
            this.buttonChangeMode.TabIndex = 10;
            this.buttonChangeMode.Text = "Change mode";
            this.buttonChangeMode.UseVisualStyleBackColor = true;
            this.buttonChangeMode.Visible = false;
            this.buttonChangeMode.Click += new System.EventHandler(this.buttonChangeMode_Click);
            // 
            // buttonModeLevels
            // 
            this.buttonModeLevels.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonModeLevels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModeLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeLevels.Location = new System.Drawing.Point(438, 34);
            this.buttonModeLevels.Name = "buttonModeLevels";
            this.buttonModeLevels.Size = new System.Drawing.Size(246, 58);
            this.buttonModeLevels.TabIndex = 11;
            this.buttonModeLevels.Text = "Levels";
            this.buttonModeLevels.UseVisualStyleBackColor = true;
            this.buttonModeLevels.Visible = false;
            this.buttonModeLevels.Click += new System.EventHandler(this.buttonModeLevels_Click);
            // 
            // buttonModeEndless
            // 
            this.buttonModeEndless.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonModeEndless.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModeEndless.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeEndless.Location = new System.Drawing.Point(438, 98);
            this.buttonModeEndless.Name = "buttonModeEndless";
            this.buttonModeEndless.Size = new System.Drawing.Size(246, 58);
            this.buttonModeEndless.TabIndex = 12;
            this.buttonModeEndless.Text = "Endless";
            this.buttonModeEndless.UseVisualStyleBackColor = true;
            this.buttonModeEndless.Visible = false;
            this.buttonModeEndless.Click += new System.EventHandler(this.buttonModeEndless_Click);
            // 
            // buttonModeExpert
            // 
            this.buttonModeExpert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonModeExpert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModeExpert.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeExpert.Location = new System.Drawing.Point(438, 162);
            this.buttonModeExpert.Name = "buttonModeExpert";
            this.buttonModeExpert.Size = new System.Drawing.Size(246, 58);
            this.buttonModeExpert.TabIndex = 13;
            this.buttonModeExpert.Text = "Expert";
            this.buttonModeExpert.UseVisualStyleBackColor = true;
            this.buttonModeExpert.Visible = false;
            this.buttonModeExpert.Click += new System.EventHandler(this.buttonModeExpert_Click);
            // 
            // labelLevel
            // 
            this.labelLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelLevel.AutoSize = true;
            this.labelLevel.BackColor = System.Drawing.Color.Black;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelLevel.Location = new System.Drawing.Point(492, 51);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(0, 55);
            this.labelLevel.TabIndex = 14;
            // 
            // timerLevel
            // 
            this.timerLevel.Interval = 1500;
            this.timerLevel.Tick += new System.EventHandler(this.timerLevel_Tick);
            // 
            // openGLControl2
            // 
            this.openGLControl2.BackColor = System.Drawing.Color.Black;
            this.openGLControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl2.DrawFPS = true;
            this.openGLControl2.ForeColor = System.Drawing.Color.Black;
            this.openGLControl2.FrameRate = 35;
            this.openGLControl2.Location = new System.Drawing.Point(0, 0);
            this.openGLControl2.Name = "openGLControl2";
            this.openGLControl2.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl2.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl2.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl2.Size = new System.Drawing.Size(1144, 623);
            this.openGLControl2.TabIndex = 0;
            this.openGLControl2.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl2_OpenGLDraw);
            this.openGLControl2.Load += new System.EventHandler(this.openGLControl2_Load);
            this.openGLControl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.openGLControl2_KeyPress);
            this.openGLControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl2_MouseClick);
            this.openGLControl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl2_MouseMove);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1144, 623);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.buttonModeExpert);
            this.Controls.Add(this.buttonModeEndless);
            this.Controls.Add(this.buttonModeLevels);
            this.Controls.Add(this.buttonChangeMode);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonRetry);
            this.Controls.Add(this.labelOver);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonS);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonW);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.openGLControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Top-down Shooter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private SharpGL.OpenGLControl openGLControl2;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Button buttonW;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Label labelOver;
        private System.Windows.Forms.Button buttonRetry;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonChangeMode;
        private System.Windows.Forms.Button buttonModeLevels;
        private System.Windows.Forms.Button buttonModeEndless;
        private System.Windows.Forms.Button buttonModeExpert;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Timer timerLevel;
    }
}

