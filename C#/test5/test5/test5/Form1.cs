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

namespace test5
{
    public partial class Form1 : Form
    {
        // 길이가 들쭉날쭉한 배열이다

        List<string> list = new List<string>() // 선언
        {
            "628870c8", 
            "4af770c8"
        };

        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            // 카드아이디(key), 카드번호(value)
            {"628870c8", "1번카드"}, // 첫번째 key-value값
            {"4af770c8", "2번카드"}, // 두번째 key-value값
            {"7dc570c8", "3번카드"}, // 세번째 key-value값
            {"a8eb70c8", "4번카드"}  // 네번째 key-value값
        };

        class student
        {
            // 멤버변수
            public string card_num;
            public string name;
            public string age;
            public string gender;
        }

        Dictionary<string, student> mystudent = new Dictionary<string, student>();

        public Form1()
        {
            InitializeComponent();
            //list.Add("~~~");
            //dic.Add("~~~");

            student card1 = new student();
            card1.card_num = "628870c8";
            card1.name = "홍길동";
            card1.age = "20";
            card1.gender = "남성";

            student card2 = new student();
            card2.card_num = "4af770c8";
            card2.name = "김땡땡";
            card2.age = "27";
            card2.gender = "남성";

            student card3 = new student();
            card3.card_num = "7dc570c8";
            card3.name = "이땡땡";
            card3.age = "28";
            card3.gender = "남성";

            student card4 = new student();
            card4.card_num = "a8eb70c8";
            card4.name = "전땡땡";
            card4.age = "28";
            card4.gender = "남성";

            mystudent.Add(card1.card_num, card1);
            mystudent.Add(card2.card_num, card2);
            mystudent.Add(card3.card_num, card3);
            mystudent.Add(card4.card_num, card4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //연결하기 버튼을 눌렀다
            if (comboBox1.SelectedIndex != -1)
            {
                //뭐라도 하나 선택했다!
                //serialPort1.PortName = comboBox1.SelectedItem.ToString();
                //serialPort1.BaudRate = 115200;
                //serialPort1.Open(); // 아두이노의 시리얼모니터가 열려있으면 에러

                serialPort2.PortName = comboBox1.SelectedItem.ToString();
                serialPort2.BaudRate = 115200;
                serialPort2.Open(); // 아두이노의 시리얼모니터가 열려있으면 에러
            }
            else
            {
                MessageBox.Show("포트번호를 선택해주세요!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 크로스 스레드 문제가 발생했다(드물게 발생함)
            /*
            this.Invoke(new MethodInvoker(delegate ()
            {
                //DO SOMETHING;
            }));
            */

            // ESP32에서 RFID태그의 값이 수신되었다
            string data = serialPort1.ReadLine(); // 아두이노에 println으로 전송함
            // ESP32보드가 재부팅되는 경우의수(아두이노면 문제 없음)
            data = data.Replace("\r", ""); // 캐리지리턴 소거

            if(data.Length == 8)
            {
                // 리스트박스는 리스트와 사용법이 똑같다
                if(listBox1.Items.Contains(data))
                {
                    // 등록
                    MessageBox.Show("등록된 카드입니다");
                }
                else
                {
                    // 미등록
                    MessageBox.Show("미등록된 카드입니다");

                }

                /*
                // 카드번호가 등록되었는지 아닌지 list로 확인하기
                if(list.Contains(data))
                {
                    // 등록
                    MessageBox.Show("등록된 카드입니다");
                }
                else
                {
                    // 미등록
                    MessageBox.Show("미등록된 카드입니다");

                }
                */

                if (dic.ContainsKey(data))
                {
                    //RFID아이디가 딕셔너리내 존재한다
                                                     //dic["키값"]
                    richTextBox1.Text += data + ", " + dic[data] + "입니다\n";
                }
                else
                {
                    // 존재하지않는다
                    richTextBox1.Text += data + ", 미등록카드입니다\n";
                }

                /*
                // 카드번호를 기준으로 몇번카드인지 인식하기
                string card_num = "";
                if(data == "628870c8")
                {;
                    // 1번카드
                    card_num = "1번카드";
                } 
                else if (data == "4af770c8")
                {
                    // 2번카드
                    card_num = "2번카드";
                }
                else if (data == "7dc570c8")
                {
                    // 3번카드
                    card_num = "3번카드";
                }
                else if(data == "a8eb70c8")
                {
                    // 4번카드
                    card_num = "4번카드";
                } else
                {
                    // 등록되지않은 카드
                    card_num = "미등록카드";
                }
                 richTextBox1.Text += data + ", " + card_num + "입니다\n";
                */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 추가버튼 누른다
            listBox1.Items.Add(textBox1.Text);
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // ESP32에서 RFID태그의 값이 수신되었다
            string data = serialPort2.ReadLine(); // 아두이노에 println으로 전송함
            // ESP32보드가 재부팅되는 경우의수(아두이노면 문제 없음)
            data = data.Replace("\r", ""); // 캐리지리턴 소거

            if (data.Length == 8)
            {
                if (mystudent.ContainsKey(data))
                {
                    // 키값이 존재한다
                    textBox2.Text = mystudent[data].card_num;
                    textBox3.Text = mystudent[data].name;
                    textBox4.Text = mystudent[data].age;
                    textBox5.Text = mystudent[data].gender;
                }
                else
                {
                    // 키값이 존재하지 않는다

                }
            }
         }
    }
}
