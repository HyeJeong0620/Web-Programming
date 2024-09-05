using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace test4
{
    public partial class Form1 : Form
    {
        //요기가 전역변수 위치
        int cnt = 0;
        int degree = 0;
        bool direct = false; // flase면 0~180, true면 180~0
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //연결하기 버튼을 눌렀다
            if (comboBox1.SelectedIndex != -1)
            {
                //뭐라도 하나 선택했다!
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.Open();
            }
            else
            {
                MessageBox.Show("포트번호를 선택해주세요!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                                          // 캐리지리턴
            string data = textBox1.Text + '\r';
            serialPort1.Write(data);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            string data = hScrollBar1.Value.ToString() + '\r';
            label1.Text= data;
            serialPort1.Write(data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //1초마다 이부분이 반복 실행된다(타이머가 작동 중일때)
            cnt--;
            if (cnt == 0)
            {
                //종료 조건
                label3.Text = "요리완료!";
                label2.Text = "0";
            }
            else
            {
                //계속 다운카운트 하는 조건
                label2.Text = cnt.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //시작 버튼을 눌렀다!
            cnt = 10;
            label2.Text = cnt.ToString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //0.1초 간격으로 0~180~0 구간을 무한반복한다!
            if(!direct)
            {
                //0~180(정방향)
                degree++;
                if(degree > 180)
                {
                    //정방향의 끝지점
                    direct = true;
                }
            }
            else
            {
                //180~0(역방향)
                degree--;
                if(degree < 0)
                {
                    //역방향의 끝지점
                    direct= false;
                }
            }
            label4.Text = degree.ToString();
            string data = degree + "\r"; //종료문자
            serialPort1.Write(data); //ESP32에게 전송
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //입력버튼을 눌렀다
            listBox1.Items.Add(textBox2.Text);
            textBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cnt = 0; //항상 0부터 시작
            timer3.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //1초 간격으로 실행된다
            //listBox1.Itmes.Count : 현재 리스트박스에 입력된 각도의 갯수
            if(listBox1.Items.Count == 0)
            {
                timer3.Stop();
                MessageBox.Show("입력 값이 없습니다");
            }
            else
            {
                //listBox1.Items[i].ToString(); i번째의 각도값
                string data = listBox1.Items[cnt].ToString() + "\r";
                cnt++;

                label5.Text = data; //우리가 원하는 현재의 각도값
                serialPort1.Write(data);

                if (cnt == listBox1.Items.Count)
                {
                    //리스트박스의 끝지점에 도달한 경우
                    cnt = 0;
                }
            }
        }
    }
}
