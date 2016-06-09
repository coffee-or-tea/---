using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] stylePath = Directory.GetFiles(@"D:\VS files\串口助手\---\串口助手\bin\Debug\传智播客_C#开发超级千千静听播放器源码和资料\皮肤\skin");
        int skini;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBoxPorts.Items.AddRange(ports);
            comboBoxPorts.SelectedIndex = comboBoxPorts.Items.Count > 0 ? 0 : -1;
            comboBoxBaudrate.SelectedIndex = comboBoxBaudrate.Items.IndexOf("38400");//选择波特率  
            
            
            //RegistryHelper rh = new RegistryHelper();
            //string skin = rh.GetRegistryData(Registry.LocalMachine, "SOFTWARE\\TagReceiver\\Params\\SerialPort", "skin");
            //try
            //{
            //    skini = int.Parse(skin);
            //}
            //catch (Exception ex)
            //{
            //    skini = 1; 
            //}
            //skinEngine1.SkinFile = @stylePath[skini-1];
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
            if (rdoSendHex.Checked)
            {
                string s = textBoxSendData.Text.Replace(" ", "");
                byte[] buffer = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
                //转换列表为数组后发送  
                serialPort1.Write(buffer.ToArray(), 0, buffer.Length);
                //记录发送的字节数  
                n = buffer.Length;
            }
            else//ascii编码直接发送  
            {
                serialPort1.Write(textBoxSendData.Text);
                n = textBoxSendData.Text.Length;
            }
        }
        private StringBuilder strbuilder = new StringBuilder();
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = serialPort1.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            //lblRx.Text += n;//增加接收计数  

            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据  
            serialPort1.Read(buf, 0, n);//读取缓冲数据  
            strbuilder.Clear();//清除字符串构造器的内容  
            //因为要访问ui资源，所以需要使用invoke方式同步ui。  
            //从 SerialPort 对象接收数据时，将在辅助线程上引发 DataReceived 事件。
            //由于此事件在辅助线程而非主线程上引发，因此尝试修改主线程中的一些元素（如 UI 元素）时会引发线程异常。 
            //如果有必要修改主 Form 或 Control 中的元素，请使用 Invoke 回发更改请求，这将在正确的线程上执行。
            this.Invoke((EventHandler)(delegate
            {
                //判断是否是显示为16禁止  
                if (rdoReceiveHex.Checked)
                {
                    //依次的拼接出16进制字符串  
                    foreach (byte b in buf)
                    {
                        strbuilder.Append(b.ToString("X2") + " ");
                    }
                }
                else
                {
                    //直接按ASCII规则转换成字符串  
                    strbuilder.Append(Encoding.ASCII.GetString(buf));
                }
                //追加的形式添加到文本框末端，并滚动到最后。  
                this.textBoxReceivedData.AppendText(strbuilder.ToString());

            }));
        }
        
        private void btnCHangeStyle_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = @stylePath[skini++];
            RegistryHelper rh = new RegistryHelper();
            //rh.SetRegistryData(Registry.LocalMachine, "SOFTWARE\\TagReceiver\\Params\\SerialPort", "skin", skini.ToString());
        }
    }
}
