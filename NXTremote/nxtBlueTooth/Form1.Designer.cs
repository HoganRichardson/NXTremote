namespace NXTremote
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.buttonGetVersion = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxInit = new System.Windows.Forms.GroupBox();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.buttonTurnLeft = new System.Windows.Forms.Button();
            this.buttonTurnRight = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.groupBoxAux = new System.Windows.Forms.GroupBox();
            this.buttonSiren = new System.Windows.Forms.Button();
            this.buttonHorn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonSteerC = new System.Windows.Forms.RadioButton();
            this.radioButtonSteerB = new System.Windows.Forms.RadioButton();
            this.radioButtonSteerA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDriveC = new System.Windows.Forms.RadioButton();
            this.radioButtonDriveB = new System.Windows.Forms.RadioButton();
            this.radioButtonDriveA = new System.Windows.Forms.RadioButton();
            this.groupBoxInit.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBoxAux.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "COM4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Com Port";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(392, 27);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(272, 562);
            this.textBoxLog.TabIndex = 3;
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Enabled = false;
            this.buttonGetInfo.Location = new System.Drawing.Point(113, 47);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(91, 25);
            this.buttonGetInfo.TabIndex = 1;
            this.buttonGetInfo.Text = "Get NXT Info";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // buttonGetVersion
            // 
            this.buttonGetVersion.Enabled = false;
            this.buttonGetVersion.Location = new System.Drawing.Point(9, 47);
            this.buttonGetVersion.Name = "buttonGetVersion";
            this.buttonGetVersion.Size = new System.Drawing.Size(98, 25);
            this.buttonGetVersion.TabIndex = 1;
            this.buttonGetVersion.Text = "Get NXT Version";
            this.buttonGetVersion.UseVisualStyleBackColor = true;
            this.buttonGetVersion.Click += new System.EventHandler(this.GetVersion_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(117, 18);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(67, 25);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // groupBoxInit
            // 
            this.groupBoxInit.Controls.Add(this.label1);
            this.groupBoxInit.Controls.Add(this.textBox1);
            this.groupBoxInit.Controls.Add(this.buttonConnect);
            this.groupBoxInit.Controls.Add(this.buttonGetInfo);
            this.groupBoxInit.Controls.Add(this.buttonGetVersion);
            this.groupBoxInit.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInit.Name = "groupBoxInit";
            this.groupBoxInit.Size = new System.Drawing.Size(374, 83);
            this.groupBoxInit.TabIndex = 12;
            this.groupBoxInit.TabStop = false;
            this.groupBoxInit.Text = "Initialisation";
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.label2);
            this.groupBoxControls.Controls.Add(this.trackBarSpeed);
            this.groupBoxControls.Controls.Add(this.buttonTurnLeft);
            this.groupBoxControls.Controls.Add(this.buttonTurnRight);
            this.groupBoxControls.Controls.Add(this.buttonMoveDown);
            this.groupBoxControls.Controls.Add(this.buttonMoveUp);
            this.groupBoxControls.Enabled = false;
            this.groupBoxControls.Location = new System.Drawing.Point(12, 200);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(374, 303);
            this.groupBoxControls.TabIndex = 13;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "Controls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Speed";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 10;
            this.trackBarSpeed.Location = new System.Drawing.Point(55, 237);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(264, 45);
            this.trackBarSpeed.SmallChange = 5;
            this.trackBarSpeed.TabIndex = 4;
            this.trackBarSpeed.TickFrequency = 10;
            this.trackBarSpeed.Value = 50;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // buttonTurnLeft
            // 
            this.buttonTurnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurnLeft.Location = new System.Drawing.Point(55, 109);
            this.buttonTurnLeft.Name = "buttonTurnLeft";
            this.buttonTurnLeft.Size = new System.Drawing.Size(84, 84);
            this.buttonTurnLeft.TabIndex = 3;
            this.buttonTurnLeft.Text = "🠔";
            this.buttonTurnLeft.UseVisualStyleBackColor = true;
            this.buttonTurnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonTurnLeft_MouseDown);
            this.buttonTurnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonTurnLeft_MouseUp);
            // 
            // buttonTurnRight
            // 
            this.buttonTurnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurnRight.Location = new System.Drawing.Point(235, 109);
            this.buttonTurnRight.Name = "buttonTurnRight";
            this.buttonTurnRight.Size = new System.Drawing.Size(84, 84);
            this.buttonTurnRight.TabIndex = 2;
            this.buttonTurnRight.Text = "🠖";
            this.buttonTurnRight.UseVisualStyleBackColor = true;
            this.buttonTurnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonTurnRight_MouseDown);
            this.buttonTurnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonTurnRight_MouseUp);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveDown.Location = new System.Drawing.Point(145, 109);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(84, 84);
            this.buttonMoveDown.TabIndex = 1;
            this.buttonMoveDown.Text = "🠗";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveDown_MouseDown);
            this.buttonMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMoveDown_MouseUp);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveUp.Location = new System.Drawing.Point(145, 19);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(84, 84);
            this.buttonMoveUp.TabIndex = 0;
            this.buttonMoveUp.Text = "🠕";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUp_MouseDown);
            this.buttonMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMoveUp_MouseUp);
            // 
            // groupBoxAux
            // 
            this.groupBoxAux.Controls.Add(this.buttonSiren);
            this.groupBoxAux.Controls.Add(this.buttonHorn);
            this.groupBoxAux.Enabled = false;
            this.groupBoxAux.Location = new System.Drawing.Point(12, 509);
            this.groupBoxAux.Name = "groupBoxAux";
            this.groupBoxAux.Size = new System.Drawing.Size(374, 80);
            this.groupBoxAux.TabIndex = 14;
            this.groupBoxAux.TabStop = false;
            this.groupBoxAux.Text = "Auxiliary";
            // 
            // buttonSiren
            // 
            this.buttonSiren.Location = new System.Drawing.Point(117, 19);
            this.buttonSiren.Name = "buttonSiren";
            this.buttonSiren.Size = new System.Drawing.Size(100, 55);
            this.buttonSiren.TabIndex = 1;
            this.buttonSiren.Text = "Siren";
            this.buttonSiren.UseVisualStyleBackColor = true;
            this.buttonSiren.Click += new System.EventHandler(this.buttonSiren_Click);
            // 
            // buttonHorn
            // 
            this.buttonHorn.Location = new System.Drawing.Point(6, 19);
            this.buttonHorn.Name = "buttonHorn";
            this.buttonHorn.Size = new System.Drawing.Size(105, 55);
            this.buttonHorn.TabIndex = 0;
            this.buttonHorn.Text = "Horn";
            this.buttonHorn.UseVisualStyleBackColor = true;
            this.buttonHorn.Click += new System.EventHandler(this.buttonHorn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Log";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonSettings);
            this.groupBoxSettings.Controls.Add(this.groupBox2);
            this.groupBoxSettings.Controls.Add(this.groupBox1);
            this.groupBoxSettings.Enabled = false;
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 101);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(374, 93);
            this.groupBoxSettings.TabIndex = 16;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(281, 60);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(87, 27);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Set";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonSteerC);
            this.groupBox2.Controls.Add(this.radioButtonSteerB);
            this.groupBox2.Controls.Add(this.radioButtonSteerA);
            this.groupBox2.Location = new System.Drawing.Point(145, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steering Motor";
            // 
            // radioButtonSteerC
            // 
            this.radioButtonSteerC.AutoSize = true;
            this.radioButtonSteerC.Location = new System.Drawing.Point(88, 28);
            this.radioButtonSteerC.Name = "radioButtonSteerC";
            this.radioButtonSteerC.Size = new System.Drawing.Size(32, 17);
            this.radioButtonSteerC.TabIndex = 5;
            this.radioButtonSteerC.Text = "C";
            this.radioButtonSteerC.UseVisualStyleBackColor = true;
            // 
            // radioButtonSteerB
            // 
            this.radioButtonSteerB.AutoSize = true;
            this.radioButtonSteerB.Checked = true;
            this.radioButtonSteerB.Location = new System.Drawing.Point(50, 28);
            this.radioButtonSteerB.Name = "radioButtonSteerB";
            this.radioButtonSteerB.Size = new System.Drawing.Size(32, 17);
            this.radioButtonSteerB.TabIndex = 4;
            this.radioButtonSteerB.TabStop = true;
            this.radioButtonSteerB.Text = "B";
            this.radioButtonSteerB.UseVisualStyleBackColor = true;
            // 
            // radioButtonSteerA
            // 
            this.radioButtonSteerA.AutoSize = true;
            this.radioButtonSteerA.Location = new System.Drawing.Point(7, 28);
            this.radioButtonSteerA.Name = "radioButtonSteerA";
            this.radioButtonSteerA.Size = new System.Drawing.Size(32, 17);
            this.radioButtonSteerA.TabIndex = 3;
            this.radioButtonSteerA.Text = "A";
            this.radioButtonSteerA.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDriveC);
            this.groupBox1.Controls.Add(this.radioButtonDriveB);
            this.groupBox1.Controls.Add(this.radioButtonDriveA);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive Motor";
            // 
            // radioButtonDriveC
            // 
            this.radioButtonDriveC.AutoSize = true;
            this.radioButtonDriveC.Location = new System.Drawing.Point(87, 28);
            this.radioButtonDriveC.Name = "radioButtonDriveC";
            this.radioButtonDriveC.Size = new System.Drawing.Size(32, 17);
            this.radioButtonDriveC.TabIndex = 2;
            this.radioButtonDriveC.Text = "C";
            this.radioButtonDriveC.UseVisualStyleBackColor = true;
            // 
            // radioButtonDriveB
            // 
            this.radioButtonDriveB.AutoSize = true;
            this.radioButtonDriveB.Location = new System.Drawing.Point(49, 28);
            this.radioButtonDriveB.Name = "radioButtonDriveB";
            this.radioButtonDriveB.Size = new System.Drawing.Size(32, 17);
            this.radioButtonDriveB.TabIndex = 1;
            this.radioButtonDriveB.Text = "B";
            this.radioButtonDriveB.UseVisualStyleBackColor = true;
            // 
            // radioButtonDriveA
            // 
            this.radioButtonDriveA.AutoSize = true;
            this.radioButtonDriveA.Checked = true;
            this.radioButtonDriveA.Location = new System.Drawing.Point(6, 28);
            this.radioButtonDriveA.Name = "radioButtonDriveA";
            this.radioButtonDriveA.Size = new System.Drawing.Size(32, 17);
            this.radioButtonDriveA.TabIndex = 0;
            this.radioButtonDriveA.TabStop = true;
            this.radioButtonDriveA.Text = "A";
            this.radioButtonDriveA.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 601);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxAux);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.groupBoxInit);
            this.Controls.Add(this.textBoxLog);
            this.Name = "Form1";
            this.Text = "NXT Bluetooth";
            this.groupBoxInit.ResumeLayout(false);
            this.groupBoxInit.PerformLayout();
            this.groupBoxControls.ResumeLayout(false);
            this.groupBoxControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBoxAux.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonGetInfo;
        private System.Windows.Forms.Button buttonGetVersion;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxInit;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Button buttonTurnLeft;
        private System.Windows.Forms.Button buttonTurnRight;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.GroupBox groupBoxAux;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button buttonSiren;
        private System.Windows.Forms.Button buttonHorn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDriveB;
        private System.Windows.Forms.RadioButton radioButtonDriveA;
        private System.Windows.Forms.RadioButton radioButtonDriveC;
        private System.Windows.Forms.RadioButton radioButtonSteerC;
        private System.Windows.Forms.RadioButton radioButtonSteerB;
        private System.Windows.Forms.RadioButton radioButtonSteerA;
        private System.Windows.Forms.Button buttonSettings;
    }
}

