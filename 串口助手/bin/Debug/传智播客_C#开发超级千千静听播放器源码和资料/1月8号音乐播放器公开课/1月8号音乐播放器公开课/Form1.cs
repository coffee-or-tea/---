using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1月8号音乐播放器公开课
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //在我们程序加载的时候 给当前窗体更换一个好看的皮肤
            skinEngine1.SkinFile = @"C:\Users\SpringRain\Desktop\皮肤\skin\SportsOrange.ssk";
            //给当前的PictureBox赋值一张默认的图片
            pictureBox1.Image = Image.FromFile(@"C:\Users\SpringRain\Desktop\Images\1.jpg");
            //设置图片在PictureBox中的布局
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //取消播放器的自动播放功能
            musicPlayer.settings.autoStart = false;

            //给当前播放器赋值一个默认播放的文件路径
            // musicPlayer.URL = @"F:\老赵生活\Music\1.mp3";
        }
        int i = 0;
        private void btnChange_Click(object sender, EventArgs e)
        {
            //把所有的皮肤文件全部读取进来 
            //获取皮肤文件夹中所有皮肤文件的全路径 存储到stylePath数组中
            string[] stylePath = Directory.GetFiles(@"C:\Users\SpringRain\Desktop\皮肤\skin");

            //点击更换皮肤其实就是去stylePath这样的数组中拿到一个皮肤文件的全路径 赋值给我们的SkinFile
            i++;//让皮肤发生改变
            //表示我在最后一个皮肤文件有嗯了一个换肤
            if (i == stylePath.Length)
            {
                i = 0;
            }
            skinEngine1.SkinFile = stylePath[i];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //每隔指定的秒数来更换图片

            //读取我们的图片文件
            string[] imgsPath = Directory.GetFiles(@"C:\Users\SpringRain\Desktop\Images");
            i++;
            if (i == imgsPath.Length)
            {
                i = 0;
            }
            pictureBox1.Image = Image.FromFile(imgsPath[i]);
        }

        //实现播放器的播放或者暂停
        private void btnPlayOrPause_Click(object sender, EventArgs e)
        {
            if (btnPlayOrPause.Text == "播放")
            {
                //我此时想要做的事情肯定是让播放器开始播放
                musicPlayer.Ctlcontrols.play();
                //播放器如果处于正在播放的状态 应该将按钮改为暂停
                btnPlayOrPause.Text = "暂停";
            }
            else if (btnPlayOrPause.Text == "暂停")
            {
                //想要做的事情肯定是暂停
                musicPlayer.Ctlcontrols.pause();
                btnPlayOrPause.Text = "播放";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //点击停止
            musicPlayer.Ctlcontrols.stop();
        }

        //存储音乐文件的全路径
        List<string> listSongs = new List<string>();
        //选择音乐
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //在Show出来之前，设置一下对话框的属性
            //设置打开对话框的标题
            ofd.Title = "请选择要播放的音乐文件";
            //设置对话框可以多选
            ofd.Multiselect = true;
            //设置打开文件类型
            ofd.Filter = "音乐文件|*.mp3|所有文件|*.*";
            //设置打开文件的初始路径
            ofd.InitialDirectory = @"F:\老赵生活\Music";
            //展示对话框
            ofd.ShowDialog();

            //获得我们在对话框中选中的文件的全路径
            string[] filePath = ofd.FileNames;
            //根据全路径截取文件名加载到ListBox列表中
            //需要将数组中的全路径存储起来
            for (int i = 0; i < filePath.Length; i++)
            {
                //将全路径存储到集合中
                listSongs.Add(filePath[i]);
                //将文件名截取出来放置到ListBox列表中
                listBox1.Items.Add(Path.GetFileName(filePath[i]));
            }
        }

        //双击播放
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            //当我们双击某一首音乐文件的时候 我们需要找到双击的这个文件名所对应的全路径
            musicPlayer.URL = listSongs[listBox1.SelectedIndex];
            musicPlayer.Ctlcontrols.play();
            //加载歌词
            LoadLrc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //上一曲
            //获得当前选中项的索引
            int index = listBox1.SelectedIndex;
            //将之前选中项的索引全部清空，这样能够确保我们之后一个歌曲被选中
            listBox1.SelectedIndices.Clear();
            if (index == -1)
            {
                return;
            }
            index--;
            //我在第一首歌点击了上一曲
            if (index < 0)
            {
                index = listBox1.Items.Count - 1;
            }
            //将改变后的索引重新赋值给当前选中项的索引
            listBox1.SelectedIndex = index;
            //通过索引区泛型集合里面拿到全路径 赋值给播放器的URL属性
            musicPlayer.URL = listSongs[index];
            musicPlayer.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox1.SelectedIndices.Clear();
            if (index == -1)
            {
                return;
            }
            index++;
            //在最后一首歌又点击了下一首
            if (index == listBox1.Items.Count)
            {
                index = 0;
            }

            listBox1.SelectedIndex = index;
            musicPlayer.URL = listSongs[index];
            musicPlayer.Ctlcontrols.play();
        }


        //多选删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得要清除歌曲的数量
            int count = listBox1.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                //先删除集合
                listSongs.RemoveAt(listBox1.SelectedIndex);
                //再删除列表
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        //根据时间差进行下一曲
        private void timer2_Tick(object sender, EventArgs e)
        {
            //当前正在播放音乐的时候进行播放
            if (musicPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                //显示歌曲的信息
                lblInfo.Text = musicPlayer.Ctlcontrols.currentPosition + "\r\n" + musicPlayer.Ctlcontrols.currentPositionString + "\r\n" + musicPlayer.currentMedia.duration + "\r\n" + musicPlayer.currentMedia.durationString;

                //如果当前播放的总时间减去正在播放的总时间小于等于1的时候 就可以进行下一曲了
                if (musicPlayer.currentMedia.duration - musicPlayer.Ctlcontrols.currentPosition <= 1)
                {
                    //下一曲
                    //int index = listBox1.SelectedIndex;
                    //listBox1.SelectedIndices.Clear();
                    //if (index == -1)
                    //{
                    //    return;
                    //}
                    //index++;
                    ////在最后一首歌又点击了下一首
                    //if (index == listBox1.Items.Count)
                    //{
                    //    index = 0;
                    //}

                    //listBox1.SelectedIndex = index;
                    //musicPlayer.URL = listSongs[index];
                    //musicPlayer.Ctlcontrols.play();
                }
            }
        }


        //根据播放状态进行下一曲
        private void musicPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //当播放器的播放状态发生改变的时候 判断当前音乐播放器的播放状态是否到达了Ended，如果是Ended，则进行下一曲
            if (musicPlayer.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                //下一曲
                int index = listBox1.SelectedIndex;
                listBox1.SelectedIndices.Clear();
                if (index == -1)
                {
                    return;
                }
                index++;
                //在最后一首歌又点击了下一首
                if (index == listBox1.Items.Count)
                {
                    index = 0;
                }

                listBox1.SelectedIndex = index;
                musicPlayer.URL = listSongs[index];
            }

            if (musicPlayer.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                //捕获异常
                try
                {
                    musicPlayer.Ctlcontrols.play();
                }
                catch { }
            }
        }


        //加载歌词
        void LoadLrc()
        {
            //判断当前正在播放的歌曲是否存在歌词文件
            //获得当前正在播放的歌曲
            string songPath = listSongs[listBox1.SelectedIndex];
            songPath += ".lrc";
            if (File.Exists(songPath))
            {
                //如果存在 通过路径读取歌词文件
                string[] lrcText = File.ReadAllLines(songPath, Encoding.Default);
                //将时间和歌词截取出来 单独的进行存放

                FormatLrc(lrcText);
            }
            else
            {
                //不存在
                lblLrc.Text = "---------歌词未找到-------------";
            }
        }


        //存储歌词时间
        List<double> listTime = new List<double>();
        //存储歌词
        List<string> listLrc = new List<string>();


        //截取字符串
        void FormatLrc(string[] lrcText)
        {
            for (int i = 0; i < lrcText.Length; i++)
            {
                //[00:15.57]当我和世界不一样
                //lrcTemp[0]  00:15.57
                //lrcTemp[1]  当我和世界不一样
                string[] lrcTemp = lrcText[i].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                //将歌词存储到集合中去
                listLrc.Add(lrcTemp[1]);
                //将00:15.57 变成  15.57
                //lrcNewTemp[0] 00  
                //lrcNewTemp[1] 15.57
                string[] lrcNewTemp = lrcTemp[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //15.57
                double time = double.Parse(lrcNewTemp[0]) * 60 + double.Parse(lrcNewTemp[1]);
                //将最终截取到的时间 扔到listTime中
                listTime.Add(time);
            }
        }


        //显示歌词
        private void timer3_Tick(object sender, EventArgs e)
        {
            //获得当前播放器的时间
            double currentTime = musicPlayer.Ctlcontrols.currentPosition;

            for (int i = 0; i < listTime.Count - 1; i++)
            {
                if (currentTime >= listTime[i] && currentTime < listTime[i + 1])
                {
                    lblLrc.Text = listLrc[i];
                }
            }
        }

    }
}
