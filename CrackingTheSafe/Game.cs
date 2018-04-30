using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// timer / visualization / start screen
namespace CrackingTheSafe
{
    public partial class Game : Form
    {
        int[] code = GenerateCode();
        int number_of_tries = 15;
        public Game()
        {
            InitializeComponent();
            UserInput.MaxLength = 3;
        }

        private void Button_Click(object sender, EventArgs e)
        {

            Button input = (Button)sender;
            if (UserInput.Text.Length < UserInput.MaxLength)
            {
                if (input == button1)
                    button1.Enabled = false;
                if (input == button2)
                    button2.Enabled = false;
                if (input == button3)
                    button3.Enabled = false;
                if (input == button4)
                    button4.Enabled = false;
                if (input == button5)
                    button5.Enabled = false;
                if (input == button6)
                    button6.Enabled = false;
                if (input == button7)
                    button7.Enabled = false;
                if (input == button8)
                    button8.Enabled = false;
                if (input == button9)
                    button9.Enabled = false;
                UserInput.Text = UserInput.Text + input.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void ProgressBar_Click(object sender, EventArgs e)
        {
        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }

        public static int[] GenerateCode()
        {
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int number;
                Random random = new Random();
                do //checks for repeated numbers 
                    number = random.Next(1, 9);
                while (randomNumbers.Contains(number));
                randomNumbers.Add(number);
            }

            return randomNumbers.ToArray();
        }

        public static int CorrectDigits(int[] user, int[] code)
        {
            int right = 0;
            for (int i = 0; i < user.Length; i++)
                if (user[i] == code[i])
                    right++;
            return right;
        }

        public static int FindDigits(int[] user, int[] code)
        {
            int right = 0;
            for (int i = 0; i < user.Length; i++)
                for (int j = 0; j < code.Length; j++)
                    if (user[i] == code[j] && i != j)
                        right++;
            return right;
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void CheckB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserInput.Text))
            {
                int[] user = digitArr(Int32.Parse(UserInput.Text));
                if (user.Length < 3)
                    label4.Text = "Incorrect";

                else
                {
                    label3.Text = "Number of Tries: " + number_of_tries.ToString();
                    label4.Text = "";
                    label1.Text += "Your Input: ";
                    for (int i = 0; i < user.Length; i++)
                        label1.Text += user[i];

                    label1.Text += System.Environment.NewLine;
                    label1.Text += "Right Position (Correct Digits): " + CorrectDigits(user, code).ToString();
                    label1.Text += System.Environment.NewLine;
                    label1.Text += "Wrong Position (Correct Digits): " + FindDigits(user, code).ToString();
                    label1.Text += System.Environment.NewLine;

                    UserInput.Text = "";

                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;

                    number_of_tries--;

                    if (number_of_tries == 0)
                        CheckB.Enabled = false;

                    if (CorrectDigits(user, code) == 3)
                    {
                        label1.Text = "Congrats";
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                    }
                }
            }
        }

        public static int[] digitArr(int n)
        {
            if (n == 0)
                return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < code.Length; i++)
                label2.Text += code[i].ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        { }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}

