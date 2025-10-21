using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace _665_30_51585
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Card
        int ScoreP1 = 0;
        int ScoreP2 = 0;
        int NumberP1 = 0;
        int NumberP2 = 0;
        int Turn = 1;
        int State = 0; // ถ้า 0 คือตาที่ 1 ของ Round ถ้า 1 คือ ตาที่ 2 ของRound ( 0 : Self , 1 : Opponent)
        int CardShowTime = 2000; // ms 
        public Form1()
        {   
            InitializeComponent();
            
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            Debug.Text = NumberP1.ToString();
            DebugNumber2.Text = NumberP2.ToString();
            TXTScoreP1.Text = "Score P1 >> " + " " + ScoreP1.ToString();
            TXTScoreP2.Text = "Score P2 >> " + " " + ScoreP2.ToString();
        }


        private void Shuffle(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            numbers = Enumerable.Range(1, 10).ToArray();// เริ่มต้น array เป็นเลข 1–10 แล้วสับ
            Shuffle(numbers);

            
            Button[] buttons = { button2, button3, button4, button5, button6, button7, button8, button9, button10, button11 };// ให้ปุ่มทั้งหมดในเกม

            
            for (int i = 0; i < buttons.Length; i++)// ใส่เลขตามลำดับของ numbers
            {
                buttons[i].Text = numbers[i].ToString();
                buttons[i].Enabled = true;
            }

            
            tabControl1.SelectedIndex = 1;// เปลี่ยนหน้าไป tab ที่ 1 (หน้าเกม)

            ScoreP1 = 0; // RESET GAME
            ScoreP2 = 0;
            NumberP1 = 0;
            NumberP2 = 0;
            foreach (var btn in buttons)
            {
                btn.Enabled = false;

            }
            Task.Delay(CardShowTime).ContinueWith(_ =>// ปรับดีเลย์ได้ ที่ Card Show time
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (var btn in buttons)
                    {
                        btn.Enabled = true;
                        btn.Text = "?";
                        Turn = 1; 
                        State = 0; 
                        

                    }
                });
            });
        }



        private void HandleClick(Button btn) 
        {
            if (!btn.Enabled) return; // กดปุ่มปิดอยู่

            int index = GetButtonIndex(btn); //หา index ของปุ่ม
            //if (index < 0 || index >= numbers.Length) return;

            int num = numbers[index];
            btn.Text = num.ToString();
            btn.Enabled = false;

            if (Turn == 1 && State == 0)
            {
                NumberP1 = num; //ให้ค่าการ์ด ใส่ใน P1
                Turn = 2;       //เปลี่ยนเทิน
                State = 1;      // เปลี่ยนสเตต
            }
            else if (Turn == 2 && State == 1)
            {
                NumberP2 = num; 
                State = 0;
                Turn = 1;
                CompareRound();  // เช็ค P1 P2 ว่าใครมากกว่า
            }
        }

        private int GetButtonIndex(Button btn) // ปุ่ม index 
        {
            if (btn == button2) return 0; 
            if (btn == button3) return 1;
            if (btn == button4) return 2;
            if (btn == button5) return 3;
            if (btn == button6) return 4;
            if (btn == button7) return 5;
            if (btn == button8) return 6;
            if (btn == button9) return 7;
            if (btn == button10) return 8;
            if (btn == button11) return 9;
            return -9;
        }

        private void CompareRound()
        {
            if (NumberP1 > NumberP2)
                ScoreP1++;
            else if (NumberP2 > NumberP1)
                ScoreP2++;

            TXTScoreP1.Text = "Score P1 >> " + ScoreP1.ToString();
            TXTScoreP2.Text = "Score P2 >> " + ScoreP2.ToString();
        }

        // ปุ่มทั้งหมดใช้ HandleClick()
        private void button2_Click(object sender, EventArgs e) => HandleClick(button2);
        private void button3_Click(object sender, EventArgs e) => HandleClick(button3);
        private void button4_Click(object sender, EventArgs e) => HandleClick(button4);
        private void button5_Click(object sender, EventArgs e) => HandleClick(button5);
        private void button6_Click(object sender, EventArgs e) => HandleClick(button6);
        private void button7_Click(object sender, EventArgs e) => HandleClick(button7);
        private void button8_Click(object sender, EventArgs e) => HandleClick(button8);
        private void button9_Click(object sender, EventArgs e) => HandleClick(button9);
        private void button10_Click(object sender, EventArgs e) => HandleClick(button10);
        private void button11_Click(object sender, EventArgs e) => HandleClick(button11);

        private void Debug_Click(object sender, EventArgs e)
        {

        }

        private void DebugNumber2_Click(object sender, EventArgs e)
        {

        }
    }
}
