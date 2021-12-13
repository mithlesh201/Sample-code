using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace OTPSimulator
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String response = SendOTP(textBox2.Text.ToString(), textBox1.Text.ToString(), "");

            textBox3.Text = response;
        }

        public string SendOTP(string OTP, string MobileNumber, string AccountNumber)
        {
            string strResponse = string.Empty;
            try
            {
                
                string text = string.Empty;

                string URL = "https://otp2.maccesssmspush.com/OTP_ACL_Web/OtpRequestListener?enterpriseid=tdcotp&subEnterpriseid=tdcotp&pusheid=tdcotp&pushepwd=tdcotp9&msisdn=" + MobileNumber + "&sender=TDCBNK&msgtext=Dear Customer, Welcome to Thane DCCB UPI service. Your request for UPI registration is successful";
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                WebRequest myWebRequest = WebRequest.Create(URL);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                Stream ReceiveStream = myWebResponse.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(ReceiveStream, encode);
                strResponse = readStream.ReadToEnd();
               



            }
            catch (Exception ex)
            {
                
                strResponse = ex.ToString();
            }
            return strResponse;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        


        



        

       
    }
}
