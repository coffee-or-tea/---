using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBoxPorts.Items.AddRange(ports);
            comboBoxPorts.SelectedIndex = comboBoxPorts.Items.Count > 0 ? 0 : -1;
            comboBoxBaudrate.SelectedIndex = comboBoxBaudrate.Items.IndexOf("38400");//选择波特率  
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxPorts.Text;
            serialPort1.BaudRate = int.Parse(comboBoxBaudrate.Text);
            try
            {
                serialPort1.Open();
                buttonClosePort.Enabled = true;
                buttonOpenPort.Enabled = false;
            }
            catch (Exception ex)
            {
                //捕获到异常信息
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            buttonOpenPort.Enabled = true;
            buttonClosePort.Enabled = false;   
        }

        private void buttonSendData_Click(object sender, EventArgs e)
        {
            //定义一个变量，记录发送了几个字节  
            int n = 0;
            //16进制发送  
            //if (rdb_tx_hex.Checked)
            //{
            //    string s = richTextBox_tx.Text.Replace(" ", "");
            //    byte[] buffer = new byte[s.Length / 2];
            //    for (int i = 0; i < s.Length; i += 2)
            //        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            //    //转换列表为数组后发送  
            //    serialPort1.Write(buffer.ToArray(), 0, buffer.Length);
            //    //记录发送的字节数  
            //    n = buffer.Length;
            //}
            //else//ascii编码直接发送  
            //{
            //    serialPort1.Write(richTextBox_tx.Text);
            //    n = richTextBox_tx.Text.Length;
            //}
        }
    }
}
