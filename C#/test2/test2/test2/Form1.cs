using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //연결하기 버튼 눌려짐!
            serialPort1.PortName = textBox1.Text;
            serialPort1.BaudRate = 115200;
            serialPort1.Encoding = Encoding.UTF8;
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //아두이노에서 println으로 전송하면 C#에서 readline으로 받는다
            string data = serialPort1.ReadLine();
            richTextBox1.Text += data + "\n";

            //data : ESP32가 보낸 데이터
            string[] data2 = data.Split(',');

            if(data2.Length == 2)
            {
                //바로 내가 원하는 데이터이다!
                textBox2.Text = data2[0];
                textBox3.Text = data2[1];
            }

            /*
            //크로스 쓰레드 문제를 해결하기 위한 해법
            this.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.Text += data + "\n";
            }));
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //연결하기 버튼 눌려짐!
            serialPort2.PortName = textBox4.Text;
            serialPort2.BaudRate = 115200;
            serialPort2.Encoding = Encoding.UTF8;
            serialPort2.Open();

            if(serialPort2.IsOpen)
            {
                serialPort2.Write("0");
            }
        }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort2.ReadLine();
            richTextBox1.Text += data + "\n";

            //data에서 CR(캐리지 리턴)을 제거한다
            data = data.Replace("\r", "");

            //data의 값에 따라서 버튼3과 버튼 4의 배경색으로 LED 상태를 표현하겠다
            if(data == "안녕하세요!")
            {
                //LED가 꺼졌을 때 ESP32의 응답
                button3.BackColor = Color.Red;
                button4.BackColor = SystemColors.Control; //기본색
            }
            else if (data == "반갑습니다!")
            {
                //LED가 켜졌을 때 ESP32의 응답
                button3.BackColor = SystemColors.Control; //기본색
                button4.BackColor = Color.Green;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                //정상적인 경우
                serialPort2.Write("0");
            }
            else
            {
                //문제가 되는 상황
                MessageBox.Show("포트를 개방해주세요!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                //정상적인 경우
                serialPort2.Write("1");
            }
            else
            {
                //문제가 되는 상황
                MessageBox.Show("포트를 개방해주세요!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //연결하기 버튼 눌려짐!
            serialPort3.PortName = textBox5.Text;
            serialPort3.BaudRate = 115200;
            serialPort3.Encoding = Encoding.UTF8;
            serialPort3.Open();
        }

        private void serialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort3.ReadLine();
            richTextBox1.Text += data + "\n";

            label3.Text = data;

            float sensor = float.Parse(data);
            //data
            aGauge1.Value =  sensor;

            //그래프에 값을 입력해준다
            //만약 현재 그래프에 있는 포인트의 갯수가 20보다 크다면
            //제일 첫번째로 입력되었던 포인트는 삭제한다.

            //chart1.Series[0].Points.Count : 현재 포인트 갯수

            if(chart1.Series[0].Points.Count > 20)
            {
                //제일 처음 데이터를 삭제한다
                chart1.Series[0].Points.RemoveAt(0);
            }

                chart1.Series[0].Points.Add(sensor);
        }
    }
}
