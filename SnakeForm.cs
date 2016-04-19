using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HungrySnake
{
    public partial class SnakeForm : Form
    {
        int _xLoc, _yLoc, _orient; //0: up, 1: left; 2: down; 3: right
        Bitmap _snake = new Bitmap(700, 440); //140, 88
        int _xHead, _yHead, _interval, _score;
        Graphics _graph;
        List<int[]> _locList = new List<int[]>(); //item[0] = row, item[1] = col
        public SnakeForm()
        {
            try
            {
                _graph = Graphics.FromImage(_snake);
                InitializeComponent();
                _graph.Clear(this.BackColor);
                stopButton.Enabled = false;
                scoreDisplay.Text = "Score: 0";
                _interval = 500;
                _xHead = 350;
                _yHead = 220;
                _xLoc = 0;
                _yLoc = 0;
                _orient = 0;
                _score = 0;
            }
            catch(Exception ex)
            {
                Trace.TraceError("Constructor failed. \r\n{0}", ex);
            }
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Interval = _interval;
                timer.Start();
                startButton.Enabled = false;
                stopButton.Enabled = true;
                difCombo.Enabled = false;
                InitialSnake();
            }
            catch (Exception ex)
            {
                Trace.TraceError("startButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void InitialSnake()
        {
            try
            {
                Random r = new Random();
                var xsLoc = _xHead;
                var ysLoc = _yHead;
                var orient = _orient;
                _orient = r.Next(4);

                for (int i = 4; i >= 0; i--)
                {
                    if (_orient == 0)
                    {
                        _graph.FillRectangle(new SolidBrush(Color.Black), _xHead, _yHead - i * 5, 5, 5);
                        _locList.Add(new int[] { _xHead, _yHead - i * 5 });
                    }
                    else if (_orient == 1)
                    {
                        _graph.FillRectangle(new SolidBrush(Color.Black), _xHead - i * 5, _yHead, 5, 5);
                        _locList.Add(new int[] { _xHead - i * 5, _yHead });
                    }
                    else if (_orient == 2)
                    {
                        _graph.FillRectangle(new SolidBrush(Color.Black), _xHead, _yHead + i * 5, 5, 5);
                        _locList.Add(new int[] { _xHead, _yHead + i * 5 });
                    }
                    else if (_orient == 3)
                    {
                        _graph.FillRectangle(new SolidBrush(Color.Black), _xHead + i * 5, _yHead, 5, 5);
                        _locList.Add(new int[] { _xHead + i * 5, _yHead });
                    }
                }

                CheckFoodLoc();

                Graphics graphDraw = snakePanel.CreateGraphics();
                graphDraw.DrawImage(_snake, 0, 0);
            }
            catch(Exception ex)
            {
                Trace.TraceError("InitialSnake() failed. \r\n{0}", ex);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var check = CheckAvail();
                if (check == 1)
                    DrawSnake();
                else if (check == 2)
                {
                    _score++;
                    scoreDisplay.Text = string.Format("Score: " + _score);
                    _xHead = _xLoc;
                    _yHead = _yLoc;
                    _locList.Add(new int[]{ _xHead, _yHead });
                    CheckFoodLoc();
                    DrawSnake();
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("You Lose!");
                    _graph.Clear(this.BackColor);
                    Graphics graphDraw = snakePanel.CreateGraphics();
                    graphDraw.DrawImage(_snake, 0, 0);
                    CleanPlate();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("timer_Tick() failed. \r\n{0}", ex);
            }
        }

        private void CheckFoodLoc()
        {
            Random r = new Random();
            int xLoc = 0, yLoc = 0;
            do
            {
                xLoc = r.Next(138) * 5 + 5;
                yLoc = r.Next(86) * 5 + 5;
            }
            while (CheckExist(xLoc, yLoc));
            _xLoc = xLoc;
            _yLoc = yLoc;

            _graph.FillRectangle(new SolidBrush(Color.Black), _xLoc, _yLoc, 5, 5);

            Graphics graphDraw = snakePanel.CreateGraphics();
            graphDraw.DrawImage(_snake, 0, 0);
        }

        private bool CheckExist(int x, int y)
        {
            try
            {
                for (int i = 0; i < _locList.Count; i++)
                    if (_locList[i][0] == x && _locList[i][1] == y)
                        return true;
                return false;
            }
            catch(Exception ex)
            {
                Trace.TraceError("CheckExist() failed. \r\n{0}", ex);
                return false;
            }
        }

        private void CleanPlate()
        {
            try
            {
                _xHead = 350;
                _yHead = 220;
                _locList.Clear();
                startButton.Enabled = true;
                stopButton.Enabled = false;
                difCombo.Enabled = true;
                _score = 0;
                scoreDisplay.Text = "Score: 0";
            }
            catch(Exception ex)
            {
                Trace.TraceError("CleanPlate() failed. \r\n{0}", ex);
            }
        }

        private void difCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (difCombo.Text == "Easy")
                    _interval = 500;
                else if (difCombo.Text == "Middle")
                    _interval = 250;
                else _interval = 100;
            }
            catch(Exception ex)
            {
                Trace.TraceError("difCombo_SelectedIndexChanged() failed. \r\n{0}", ex);
            }
        }

        private int CheckAvail()
        {
            try
            {
                if ((_orient == 0 && _yHead + 5 >= 440) ||
                    (_orient == 1 && _xHead + 5 >= 700) ||
                    (_orient == 2 && _yHead - 5 < 0) ||
                    (_orient == 3 && _xHead - 5 < 0))
                    return 0;
                else if ((_orient == 0 && CheckExist(_xHead, _yHead + 5)) ||
                    (_orient == 1 && CheckExist(_xHead + 5, _yHead)) ||
                    (_orient == 2 && CheckExist(_xHead, _yHead - 5)) ||
                    (_orient == 3 && CheckExist(_xHead - 5, _yHead)))
                    return 0;
                else if ((_orient == 0 && _yHead + 5 == _yLoc && _xHead == _xLoc) ||
                    (_orient == 1 && _xHead + 5 == _xLoc && _yHead == _yLoc) ||
                    (_orient == 2 && _yHead - 5 == _yLoc && _xHead == _xLoc) ||
                    (_orient == 3 && _xHead - 5 == _xLoc && _yHead == _yLoc))
                    return 2;
                return 1;
            }
            catch(Exception ex)
            {
                Trace.TraceError("CheckAvail() failed. \r\n{0}", ex);
                return 0;
            }
        }

        private void DrawSnake()
        {
            try
            {
                _graph.FillRectangle(new SolidBrush(this.BackColor), _locList[0][0], _locList[0][1], 5, 5);
                _locList.RemoveAt(0);
                if (_orient == 0)
                {
                    _locList.Add(new int[] { _xHead, _yHead + 5 });
                    _yHead += 5;
                }
                else if (_orient == 1)
                {
                    _locList.Add(new int[] { _xHead + 5, _yHead });
                    _xHead += 5;
                }
                else if (_orient == 2)
                {
                    _locList.Add(new int[] { _xHead, _yHead - 5 });
                    _yHead -= 5;
                }
                else if (_orient == 3)
                {
                    _locList.Add(new int[] { _xHead - 5, _yHead });
                    _xHead -= 5;
                }

                    for (int i = 0; i < _locList.Count; i++)
                    {
                        _graph.FillRectangle(new SolidBrush(Color.Black), _locList[i][0], _locList[i][1], 5, 5);
                    }

                    Graphics graphDraw = snakePanel.CreateGraphics();
                    graphDraw.DrawImage(_snake, 0, 0);
                }
            catch (Exception ex)
            {
                Trace.TraceError("DrawSnake() failed. \r\n{0}", ex);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                _graph.Clear(this.BackColor);
                Graphics graphDraw = snakePanel.CreateGraphics();
                graphDraw.DrawImage(_snake, 0, 0);
                CleanPlate();
            }
            catch (Exception ex)
            {
                Trace.TraceError("stopButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void snakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(startButton.Enabled == false)
                {
                    if (e.KeyCode == Keys.A && _orient != 1) _orient = 3; //left
                    else if (e.KeyCode == Keys.W && _orient != 0) _orient = 2; //up
                    else if (e.KeyCode == Keys.D && _orient != 3) _orient = 1; //right
                    else if (e.KeyCode == Keys.S && _orient != 2) _orient = 0; //down
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("snakeForm_KeyDown() failed. \r\n{0}", ex);
            }
        }
    }
}
