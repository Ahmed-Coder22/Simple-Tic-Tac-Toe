using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress

        }
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }
       public bool CheckValue(Button But1,Button But2,Button But3)
        {
            if (But1.Tag.ToString() != "?" && But1.Tag.ToString() == But2.Tag.ToString() && But1.Tag.ToString() == But3.Tag.ToString())
            {
                But1.BackColor = Color.Green;
                But2.BackColor = Color.Green;
                But3.BackColor = Color.Green;
                if (But1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
              

            }
            GameStatus.GameOver = false;
            return false;

        }
        void EndGame()
        {

            lbPlayer.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    rbWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    rbWinner.Text = "Player2";
                    break;

                default:

                    rbWinner.Text = "Draw";
                    break;

            }
        }

            public void CheckWin()
        {
            if (CheckValue(button1, button2, button3))
                return;
            if (CheckValue(button4, button5, button6))
                return;
            if (CheckValue(button7, button8, button9))
                return;
            if (CheckValue(button1, button4, button7))
                return;
            if (CheckValue(button2, button5, button8))
                return;
            if (CheckValue(button3, button6, button9))
                return;
            if (CheckValue(button1, button5, button9))
                return;
            if (CheckValue(button3, button5, button7))
                return;
          
        }
        void UpdateBut(Button But)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("Game is already over! Please restart to play again.",
                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (But.Tag.ToString()=="?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        But.BackgroundImage = Image.FromFile(@"C:\Users\Ahmed\OneDrive\Pictures\Screenshots\X.png");
                        But.Tag = "X";
                        lbPlayer.Text = "Player 2";
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        CheckWin();
                        break;

                    case enPlayer.Player2:
                        But.BackgroundImage = Image.FromFile(@"C:\Users\Ahmed\OneDrive\Pictures\Screenshots\O.png");
                        But.Tag = "O";
                        lbPlayer.Text = "Player 1";
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayCount++;
                        CheckWin();
                        break;
                }
            }
            else
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBut(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBut(button2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateBut(button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateBut(button4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateBut(button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateBut(button6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateBut(button7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateBut(button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateBut(button9);

        }
        void RestButton(Button But)
        {
            But.Tag = "?";
            But.BackgroundImage = Image.FromFile(@"C:\Users\Ahmed\OneDrive\Pictures\Screenshots\question-mark-96.png");
            But.BackColor =Color.Gold;
        }
        private void RestartGame()
        {

            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lbPlayer.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            rbWinner.Text = "In Progress";



        }

        private void butuRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
