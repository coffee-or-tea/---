namespace 串口助手
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.buttonClosePort = new System.Windows.Forms.Button();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.textBoxReceivedData = new System.Windows.Forms.TextBox();
            this.textBoxSendData = new System.Windows.Forms.TextBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.rdoReceiveHex = new System.Windows.Forms.RadioButton();
            this.rdoReceiveASCLL = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSendASCLL = new System.Windows.Forms.RadioButton();
            this.rdoSendHex = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTx = new System.Windows.Forms.Label();
            this.lblRx = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(562, 12);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Location = new System.Drawing.Point(562, 64);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(121, 23);
            this.buttonOpenPort.TabIndex = 1;
            this.buttonOpenPort.Text = "打开串口";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // buttonClosePort
            // 
            this.buttonClosePort.Location = new System.Drawing.Point(562, 93);
            this.buttonClosePort.Name = "buttonClosePort";
            this.buttonClosePort.Size = new System.Drawing.Size(121, 23);
            this.buttonClosePort.TabIndex = 2;
            this.buttonClosePort.Text = "关闭串口";
            this.buttonClosePort.UseVisualStyleBackColor = true;
            this.buttonClosePort.Click += new System.EventHandler(this.buttonClosePort_Click);
            // 
            // buttonSendData
            // 
            this.buttonSendData.Location = new System.Drawing.Point(561, 247);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(121, 23);
            this.buttonSendData.TabIndex = 3;
            this.buttonSendData.Text = "发送";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click);
            // 
            // textBoxReceivedData
            // 
            this.textBoxReceivedData.Location = new System.Drawing.Point(12, 12);
            this.textBoxReceivedData.Multiline = true;
            this.textBoxReceivedData.Name = "textBoxReceivedData";
            this.textBoxReceivedData.Size = new System.Drawing.Size(544, 219);
            this.textBoxReceivedData.TabIndex = 4;
            // 
            // textBoxSendData
            // 
            this.textBoxSendData.Location = new System.Drawing.Point(12, 248);
            this.textBoxSendData.Name = "textBoxSendData";
            this.textBoxSendData.Size = new System.Drawing.Size(543, 21);
            this.textBoxSendData.TabIndex = 5;
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(562, 38);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudrate.TabIndex = 6;
            // 
            // rdoReceiveHex
            // 
            this.rdoReceiveHex.AutoSize = true;
            this.rdoReceiveHex.Checked = true;
            this.rdoReceiveHex.Location = new System.Drawing.Point(6, 20);
            this.rdoReceiveHex.Name = "rdoReceiveHex";
            this.rdoReceiveHex.Size = new System.Drawing.Size(41, 16);
            this.rdoReceiveHex.TabIndex = 7;
            this.rdoReceiveHex.TabStop = true;
            this.rdoReceiveHex.Text = "Hex";
            this.rdoReceiveHex.UseVisualStyleBackColor = true;
            // 
            // rdoReceiveASCLL
            // 
            this.rdoReceiveASCLL.AutoSize = true;
            this.rdoReceiveASCLL.Location = new System.Drawing.Point(62, 20);
            this.rdoReceiveASCLL.Name = "rdoReceiveASCLL";
            this.rdoReceiveASCLL.Size = new System.Drawing.Size(53, 16);
            this.rdoReceiveASCLL.TabIndex = 8;
            this.rdoReceiveASCLL.Text = "ASCLL";
            this.rdoReceiveASCLL.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoReceiveASCLL);
            this.groupBox1.Controls.Add(this.rdoReceiveHex);
            this.groupBox1.Location = new System.Drawing.Point(562, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 41);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSendASCLL);
            this.groupBox2.Controls.Add(this.rdoSendHex);
            this.groupBox2.Location = new System.Drawing.Point(556, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 47);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送设置";
            // 
            // rdoSendASCLL
            // 
            this.rdoSendASCLL.AutoSize = true;
            this.rdoSendASCLL.Location = new System.Drawing.Point(62, 20);
            this.rdoSendASCLL.Name = "rdoSendASCLL";
            this.rdoSendASCLL.Size = new System.Drawing.Size(53, 16);
            this.rdoSendASCLL.TabIndex = 8;
            this.rdoSendASCLL.Text = "ASCLL";
            this.rdoSendASCLL.UseVisualStyleBackColor = true;
            // 
            // rdoSendHex
            // 
            this.rdoSendHex.AutoSize = true;
            this.rdoSendHex.Checked = true;
            this.rdoSendHex.Location = new System.Drawing.Point(6, 20);
            this.rdoSendHex.Name = "rdoSendHex";
            this.rdoSendHex.Size = new System.Drawing.Size(41, 16);
            this.rdoSendHex.TabIndex = 7;
            this.rdoSendHex.TabStop = true;
            this.rdoSendHex.Text = "Hex";
            this.rdoSendHex.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "TX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "RX";
            // 
            // lblTx
            // 
            this.lblTx.AutoSize = true;
            this.lblTx.Location = new System.Drawing.Point(201, 373);
            this.lblTx.Name = "lblTx";
            this.lblTx.Size = new System.Drawing.Size(11, 12);
            this.lblTx.TabIndex = 14;
            this.lblTx.Text = "0";
            // 
            // lblRx
            // 
            this.lblRx.AutoSize = true;
            this.lblRx.Location = new System.Drawing.Point(390, 373);
            this.lblRx.Name = "lblRx";
            this.lblRx.Size = new System.Drawing.Size(11, 12);
            this.lblRx.TabIndex = 15;
            this.lblRx.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 394);
            this.Controls.Add(this.lblRx);
            this.Controls.Add(this.lblTx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.textBoxSendData);
            this.Controls.Add(this.textBoxReceivedData);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.buttonClosePort);
            this.Controls.Add(this.buttonOpenPort);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "定制串口助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Button buttonClosePort;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.TextBox textBoxReceivedData;
        private System.Windows.Forms.TextBox textBoxSendData;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.RadioButton rdoReceiveHex;
        private System.Windows.Forms.RadioButton rdoReceiveASCLL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSendASCLL;
        private System.Windows.Forms.RadioButton rdoSendHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTx;
        private System.Windows.Forms.Label lblRx;
    }
}

