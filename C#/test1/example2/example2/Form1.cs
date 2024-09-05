 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 버튼을 누르면 textbox1의 내용을 label1에 출력하겠다
            label1.Text = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "내가 눌러졌다";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //numeric updown 값을 label1에 대입한다
            int num1 = (int)numericUpDown1.Value;
            label1.Text = num1.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string data = "50";
            int num = int.Parse(data);

            string text1 = "안녕하세요";
            string text2 = "반갑습니다";
            string text3 = text1 + text2;

            int[] num3 = { 1, 2, 3, 4, 5 };
            int[] num4 = new int[5];
            num4[0] = 1;
            num4[1] = 2;

            string[] mydata = { "data1", "data2", "data3" };
            //mydata.Length -> 3

            string mydata2 = "100,200,300";
            string[] output = mydata2.Split(',');

            try
            {
                numericUpDown1.Value = int.Parse(textBox1.Text);
            }
            catch(Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            int num3 = num1 + num2;
            label2.Text = num3.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            int num3 = num1 - num2;
            label2.Text = num3.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            int num3 = num1 * num2;
            label2.Text = num3.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(textBox2.Text);
            double num2 = double.Parse(textBox3.Text);
            double num3 = num1 / num2;
            label2.Text = num3.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Text = textBox4.Text + textBox5.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] data = textBox6.Text.Split(',');
            int output = 0;

            for(int i = 0; i < data.Length; i++)
            {
                output += int.Parse(data[i]);
            }

            label4.Text = output.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // 체크되었다
                label5.Text = "체크가 되었습니다!";
            }
            else
            {
                // 체크되지않았다
                label5.Text = "체크가 되지않았습니다";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox7.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // 추가 버튼을 클릭했다
            // listbox1에 대입한다
            listBox2.Items.Add(textBox8.Text);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 사용자가 항목중 뭔가를 선택했다
            // listBox2.SelectedIndex
            // listBox2.SelectedItem
            label6.Text = listBox2.SelectedItem.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                // 사용자가 listbox에서 뭔가를 선택했냐 안했냐
                if (listBox2.SelectedIndex  != -1)
                {
                    // 선택했다
                    listBox3.Items.Add(listBox2.SelectedItem);
                    // listbox2에 선택되어있던것은 삭제한다
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else
                {
                    // 선택안했다
                    MessageBox.Show("선택해주세요!");
                }
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox1.SelectedItem.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox9.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // 원래있던 내용을 삭제한다
            comboBox1.Items.Clear();

            string[] animals = { "고양이", "호랑이", "햄스터" };

            comboBox1.Items.AddRange(animals);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                // 사용자가 listbox에서 뭔가를 선택했냐 안했냐
                if (listBox3.SelectedIndex  != -1)
                {
                    // 선택했다
                    listBox2.Items.Add(listBox3.SelectedItem);
                    // listbox2에 선택되어있던것은 삭제한다
                    listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                }
            }
            catch
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string name = textBox10.Text;
            string age = textBox11.Text;
            string gender = textBox12.Text;

            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            // 한줄의 레코드를 정의함
            ListViewItem lvi = new ListViewItem();
            lvi.Text = name;
            lvi.SubItems.Add(age);
            lvi.SubItems.Add(gender);

            // 데이터를 집어넣는다
            listView1.Items.Add(lvi);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // listview에서 뭔가를 선택했다
                //listView1.SelectedItems[0].SubItems[0] : 이름
                //listView1.SelectedItems[0].SubItems[1] : 나이
                //listView1.SelectedItems[0].SubItems[2] : 성별
                textBox10.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox11.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox12.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
            catch
            {

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // 선택이 되었냐 안되었냐
            if(listView1.SelectedIndices.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label11.Text = vScrollBar1.Value + "%";
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label12.Text = hScrollBar1.Value + "%";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar1.Value + "%";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button18.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button18.BackColor = Color.FromArgb(0, 0, 255);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int r = trackBar2.Value;
            int g = trackBar3.Value;
            int b = trackBar4.Value;
            button18.BackColor = Color.FromArgb(r, g, b);
            label14.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int r = trackBar2.Value;
            int g = trackBar3.Value;
            int b = trackBar4.Value;
            button18.BackColor = Color.FromArgb(r, g, b);
            label15.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            int r = trackBar2.Value;
            int g = trackBar3.Value;
            int b = trackBar4.Value;
            button18.BackColor = Color.FromArgb(r, g, b);
            label16.Text = trackBar4.Value.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // colorDialog.Color
                button18.BackColor = colorDialog1.Color;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "0";
            }
            else
            {
                textBox13.Text += "0";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if(textBox13.Text == "0")
            {
                textBox13.Text = "1";
            }
            else
            {
                textBox13.Text += "1";
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "2";
            }
            else
            {
                textBox13.Text += "2";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "3";
            }
            else
            {
                textBox13.Text += "3";
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "4";
            }
            else
            {
                textBox13.Text += "4";
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "5";
            }
            else
            {
                textBox13.Text += "5";
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "6";
            }
            else
            {
                textBox13.Text += "6";
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "7";
            }
            else
            {
                textBox13.Text += "7";
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "8";
            }
            else
            {
                textBox13.Text += "8";
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "0")
            {
                textBox13.Text = "9";
            }
            else
            {
                textBox13.Text += "9";
            }
        }

        //계산기의 최종 결과를 저장할 변수
        double result = 0;
        char op = '0'; //op : 마지막으로 누른 연산기호
        bool first = true; //참이면 첫실행 아니면 진행중
        
        //최종결과버튼
        private void button23_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox13.Text);
            if(op == '+')
            {
                result += num;
                textBox13.Text = result.ToString();
            }else if(op == '-')
            {

                result -= num;
                textBox13.Text = result.ToString();
            }
            else if (op == '*')
            {

                result *= num;
                textBox13.Text = result.ToString();
            }
            else if (op == '/')
            {

                result /= num;
                textBox13.Text = result.ToString();
            }
            first = true;
        }

        //더하기버튼
        private void button24_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox13.Text);

            if (first)
            {
                //최초로 계산기가 작동되었기 때문에 2개의 숫자중에
                //한개밖에 없는 상태
                result = num;
                first = false;
            }
            else
            {
                result += num;
            }

            op = '+';
            textBox13.Text = "0";
        }

        //나누기버튼
        private void button33_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox13.Text);

            if (first)
            {
                //최초로 계산기가 작동되었기 때문에 2개의 숫자중에
                //한개밖에 없는 상태
                result = num;
                first = false;
            }
            else
            {
                result /= num;
            }

            op = '/';
            textBox13.Text = "0";
        }

        //빼기버튼
        private void button28_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox13.Text);

            if (first)
            {
                //최초로 계산기가 작동되었기 때문에 2개의 숫자중에
                //한개밖에 없는 상태
                result = num;
                first = false;
            }
            else
            {
                result -= num;
            }

            op = '-';
            textBox13.Text = "0";
        }
        
        //곱하기버튼
        private void button29_Click(object sender, EventArgs e)
        {

            double num = double.Parse(textBox13.Text);

            if (first)
            {
                //최초로 계산기가 작동되었기 때문에 2개의 숫자중에
                //한개밖에 없는 상태
                result = num;
                first = false;
            }
            else
            {
                result *= num;
            }

            op = '*';
            textBox13.Text = "0";
        }

        //초기화버튼
        private void button37_Click(object sender, EventArgs e)
        {
            textBox13.Text = "0";
            first = true;

        }

        private void button38_MouseEnter(object sender, EventArgs e)
        {
            button38.BackColor = Color.Red;
        }

        private void button38_MouseLeave(object sender, EventArgs e)
        {
            button38.BackColor = SystemColors.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //메인폼이 실행되어서 사용자 눈에 UI가 출력되었다
            //버튼 22~37번까지의 이벤트를 커스텀하게 만들겠다
            button22.MouseEnter += my_MouseEnter;
            button22.MouseLeave += my_MouseLeave;

            button23.MouseEnter += my_MouseEnter;
            button23.MouseLeave += my_MouseLeave;

            button24.MouseEnter += my_MouseEnter;
            button24.MouseLeave += my_MouseLeave;

            button25.MouseEnter += my_MouseEnter;
            button25.MouseLeave += my_MouseLeave;

            button26.MouseEnter += my_MouseEnter;
            button26.MouseLeave += my_MouseLeave;

            button27.MouseEnter += my_MouseEnter;
            button27.MouseLeave += my_MouseLeave;

            button28.MouseEnter += my_MouseEnter;
            button28.MouseLeave += my_MouseLeave;

            button29.MouseEnter += my_MouseEnter;
            button29.MouseLeave += my_MouseLeave;

            button30.MouseEnter += my_MouseEnter;
            button30.MouseLeave += my_MouseLeave;

            button31.MouseEnter += my_MouseEnter;
            button31.MouseLeave += my_MouseLeave;

            button32.MouseEnter += my_MouseEnter;
            button32.MouseLeave += my_MouseLeave;

            button33.MouseEnter += my_MouseEnter;
            button33.MouseLeave += my_MouseLeave;

            button34.MouseEnter += my_MouseEnter;
            button34.MouseLeave += my_MouseLeave;

            button35.MouseEnter += my_MouseEnter;
            button35.MouseLeave += my_MouseLeave;

            button36.MouseEnter += my_MouseEnter;
            button36.MouseLeave += my_MouseLeave;

            button37.MouseEnter += my_MouseEnter;
            button37.MouseLeave += my_MouseLeave;
        }
        private void my_MouseEnter(object sender, EventArgs e)
        {
            //버튼에 마우스가 enter되면 실행됨
            Button b = sender as Button;
            b.BackColor = Color.Red;
        }
        private void my_MouseLeave(object sender, EventArgs e)
        {
            //버튼에 마우스가 있다가 사라짐
            Button b = sender as Button;
            b.BackColor = SystemColors.Control;
        }
    }
}
