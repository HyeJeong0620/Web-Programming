using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace p20231031
{
    public partial class Form1 : Form
    {
        // C#의 전역변수 위치
        string Conn = "Server=localhost;Database=school;Uid=root;Pwd=060620;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //저장버튼 클릭
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();//C#과 DB가 연결

                string name = textBox1.Text;
                string age = textBox2.Text;
                string gender = textBox3.Text;
                string date = DateTime.Now.ToString();

                MySqlCommand msc = new MySqlCommand($"insert into student(name, age, gender, date) values('{name}', {age}, '{gender}', '{date}')", conn);
                msc.ExecuteNonQuery();//C#에서 MYSQL로 쿼리 전송

                //버튼2를 클릭한 것 처럼 효과를 주겠다
                button2_Click(null, null);

                MessageBox.Show("저장되었습니다!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //불러오기 버튼 클릭
            //검색구문
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                DataSet ds = new DataSet(); //C#꺼
                string sql = "SELECT * FROM student";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds, "student"); //ds에 결과값을 저장한다

                //가져온 데이터가 몇개인가?
                //ds.Tables[0].Rows.Count;
                int cnt = ds.Tables[0].Rows.Count;

                //listview 내용을 초기화 한다
                listView1.Items.Clear();

                label4.Text = $"현재 데이터 갯수는 {cnt}개 입니다!";
                
                //가져온 갯수만큼 반복문을 회전시킨다
                for(int i = 0; i < cnt; i++)
                {
                    //i번째 레코드의 ~~필드명
                    string num = ds.Tables[0].Rows[i]["num"].ToString();
                    string name = ds.Tables[0].Rows[i]["name"].ToString();
                    string age = ds.Tables[0].Rows[i]["age"].ToString();
                    string gender = ds.Tables[0].Rows[i]["gender"].ToString();
                    string date = ds.Tables[0].Rows[i]["date"].ToString();

                    //i번째 레크드의 데이터를 listview에 한 레코드로 대입해야한다
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = num;
                    lvi.SubItems.Add(name);
                    lvi.SubItems.Add(age);
                    lvi.SubItems.Add(gender);
                    lvi.SubItems.Add(date);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //삭제버튼
            //리스트뷰에서 선택된게 있냐없냐?
            if(listView1.SelectedItems.Count == 1)
            {
                //우리가 원하는 경우
                string num = listView1.SelectedItems[0].SubItems[0].Text;
                //삭제구문
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand msc = new MySqlCommand($"DELETE FROM student where num={num}", conn);
                    msc.ExecuteNonQuery();

                    button2_Click(null, null); //결과 리플레시

                    MessageBox.Show("삭제되었습니다");
                }
            }
            else
            {
                MessageBox.Show("선택된박스가 없습니다");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string num = listView1.SelectedItems[0].SubItems[0].Text;
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string age = listView1.SelectedItems[0].SubItems[2].Text;
                string gender = listView1.SelectedItems[0].SubItems[3].Text;
                string date = listView1.SelectedItems[0].SubItems[4].Text;

                textBox1.Text = name;
                textBox2.Text = age;
                textBox3.Text = gender;
                textBox4.Text = num;
                textBox5.Text = date;
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string num = textBox4.Text;
            string name = textBox1.Text;
            string age = textBox2.Text;
            string gender = textBox3.Text;
            string date = DateTime.Now.ToString();

            if (num != "")
            {
                //수정할 사항이 있는 것이다
                //수정구문
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand msc = new MySqlCommand($"UPDATE student SET name='{name}', age={age}, " +
                        $"gender='{gender}',date='{date}' " +
                        $"where num={num}", conn);
                    msc.ExecuteNonQuery();

                    button2_Click(null, null); //결과 리플레시

                    MessageBox.Show("수정되었습니다");
                }
            }
            else
            {
                MessageBox.Show("수정할 데이터를 선택해주세요!");
            }
        }
    }
}
