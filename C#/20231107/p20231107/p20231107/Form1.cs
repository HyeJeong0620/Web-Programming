using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//네임스페이스추가(설치해야함)
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
//JSON
using Newtonsoft.Json.Linq;

namespace p20231107
{
    public partial class Form1 : Form
    {
        //전역으로 클래스선언
        MqttClient client;
        string clientId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //프로그램이 실행되면 자동으로 브로커와 연결하겠다
            //MQTT 브로커와 연결하는 부분
            string BrokerAddress = "broker.mqtt-dashboard.com";
            client = new MqttClient(BrokerAddress);

            //구독신청을 해서 MQTT
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //서버와 클라이언트가 접속이 완료되는 지점
            //IoT보드가 publish하는 topic을 subscribe해야한다
            //Subscribe Topic 추가

            string[] mytopic =
            {
                "bssm_iot/room1/sensor",
                //"bssm_iot/room2/sensor",
                //"bssm_iot/livingroom/dust",
                //"bssm_iot/livingroom/co2",
                //"bssm_iot/livingroom/rfid",
                //"bssm_iot/outdoor/weather",
            };

            byte[] myqos =
            {
                0,
            };

            //구독신청완료
            client.Subscribe(mytopic, myqos);
        }

        //MQTT이벤트 핸들러(메세지 수신부)
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);

            //DO SOMETHING..!
            richTextBox1.Text += $"[{e.Topic}]" + ReceivedMessage + "\n";

            //e.Topic
            if(e.Topic == "bssm_iot/room1/sensor")
            {
                //JSON테이터 parse
                try
                {
                    //만약 json데이터가 불완전하다면 예외가 발생한다
                    JObject myjson = JObject.Parse(ReceivedMessage);
                    textBox1.Text =  myjson["temp"].ToString();
                    textBox2.Text =  myjson["humi"].ToString();
                    textBox3.Text =  myjson["cds"].ToString();
                    textBox4.Text =  myjson["gas"].ToString();
                }
                catch
                {

                }
            }
            else if(e.Topic == "bssm_iot/room2/sensor")
            {
                //JSON테이터 parse
                try
                {
                    //만약 json데이터가 불완전하다면 예외가 발생한다
                    JObject myjson = JObject.Parse(ReceivedMessage);
                    textBox5.Text =  myjson["temp"].ToString();
                    textBox6.Text =  myjson["humi"].ToString();
                    textBox7.Text =  myjson["cds"].ToString();
                    textBox8.Text =  myjson["gas"].ToString();
                }
                catch
                {

                }
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //유저가 프로그램을 종료했다
            //그러면 MQTT도 종료하겠다
            client.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //on
            client.Publish("bssm_iot/livingroom/servo1", Encoding.UTF8.GetBytes("0"), 0, false);
            client.Publish("bssm_iot/livingroom/servo2", Encoding.UTF8.GetBytes("0"), 0, false);
            client.Publish("bssm_iot/livingroom/servo3", Encoding.UTF8.GetBytes("0"), 0, false);
            client.Publish("bssm_iot/livingroom/servo4", Encoding.UTF8.GetBytes("0"), 0, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //off
            client.Publish("bssm_iot/livingroom/servo1", Encoding.UTF8.GetBytes("90"), 0, false);
            client.Publish("bssm_iot/livingroom/servo2", Encoding.UTF8.GetBytes("90"), 0, false);
            client.Publish("bssm_iot/livingroom/servo3", Encoding.UTF8.GetBytes("90"), 0, false);
            client.Publish("bssm_iot/livingroom/servo4", Encoding.UTF8.GetBytes("90"), 0, false);
        }
    }
}
