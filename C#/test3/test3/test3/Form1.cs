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

namespace test3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //사용자가 프로그램을 실행해서
            //모든 컴포넌트의 로드가 완료되었다

            //PC의 사용가능한 포트목록을 combobox에 대입한다

            comboBox1.Items.AddRange(SerialPort.GetPortNames());

            //button2.Tag = "292\r";
            //button2.MouseDown += my_MouseDown;
            //button2.MouseUp += my_MouseUp;
        }

        /*
        private void my_MouseDown(object sender, EventArgs e)
        {

        }
        private void my_MouseUp(object sender, EventArgs e)
        {

        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            //연결하기 버튼을 눌렀다
            if(comboBox1.SelectedIndex != -1)
            {
                //뭐라도 하나 선택했다!
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.Open();

                MessageBox.Show("연결되었습니다!");
            }
            else
            {
                MessageBox.Show("포트번호를 선택해주세요!");
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            //도음을 누르고 있다
            //serialPort1.Write
            //serialPort1.WriteLine() + CR + LF
            serialPort1.Write("262\r");
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            //누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            //레를 눌렀다
            serialPort1.Write("294\r");
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            //레를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            //미를 눌렀다
            serialPort1.Write("330\r");
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            //미를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            //파를 눌렀다
            serialPort1.Write("349\r");
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            //파를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            //솔을 눌렀다
            serialPort1.Write("392\r");
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            //솔을 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            //라를 눌렀다
            serialPort1.Write("440\r");
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            //라를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            //시를 눌렀다
            serialPort1.Write("494\r");
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            //시를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            //도를 눌렀다
            serialPort1.Write("523\r");
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            //도를 누르고 있다가 땠다
            serialPort1.Write("0\r");
        }
    }
}
