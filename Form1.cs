using System.Buffers;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Main_Window : Form
    {

        public Main_Window()
        {
            InitializeComponent();        
        }

        private bool isDragging = false;
        private Point dragStartMousePos; // Renamed for clarity
        private Point dragStartFormPos; // Renamed for clarity

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartMousePos = Cursor.Position;
            dragStartFormPos = Location;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePos = Cursor.Position;
                int deltaX = currentMousePos.X - dragStartMousePos.X;
                int deltaY = currentMousePos.Y - dragStartMousePos.Y;

                Location = new Point(dragStartFormPos.X + deltaX, dragStartFormPos.Y + deltaY);
                Update(); // This might not be strictly necessary here, but it doesn't hurt
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Close_Window_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void Button_1_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "1";
            Program.currentNumber += "1";
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "2";
            Program.currentNumber += "2";
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "3";
            Program.currentNumber += "3";
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "4";
            Program.currentNumber += "4";
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "5";
            Program.currentNumber += "5";
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "6";
            Program.currentNumber += "6";
        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "8";
            Program.currentNumber += "8";
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "7";
            Program.currentNumber += "7";
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                Program.currentNumber = "";
                Input.Text = "";
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "9";
            Program.currentNumber += "9";
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "0")
            {
                return;
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            Input.Text += "0";
            Program.currentNumber += "0";
        }

        private void Button_Addition_Click(object sender, EventArgs e)
        {
            if (Output.Text != "")
            {
                ContinueOperation();
            }
            if (Program.currentNumber == "")
            {
                return;
            }
            Program.numbers.Add(double.Parse(Program.currentNumber));
            Input.Text += " + ";
            Program.operations.Add("+");
            Program.currentNumber = "";
        }

        private void Button_Subtract_Click(object sender, EventArgs e)
        {
            if (Output.Text != "")
            {
                ContinueOperation();
            }
            if (Program.currentNumber == "" && Program.operations.Count == 0)
            {
                Program.currentNumber = "0";
            }
            else if (Program.currentNumber == "")
            {
                return;
            }
            Program.numbers.Add(double.Parse(Program.currentNumber));
            Input.Text += " - ";
            Program.operations.Add("-");
            Program.currentNumber = "";
        }

        private void Button_Multiply_Click(object sender, EventArgs e)
        {
            if (Output.Text != "")
            {
                ContinueOperation();
            }
            if (Program.currentNumber == "")
            {
                return;
            }
            Program.numbers.Add(double.Parse(Program.currentNumber));
            Input.Text += " x ";
            Program.operations.Add("x");
            Program.currentNumber = "";
        }

        private void Button_Divide_Click(object sender, EventArgs e)
        {
            if (Output.Text != "")
            {
                ContinueOperation();
            }
            if (Program.currentNumber == "")
            {
                return;
            }
            Program.numbers.Add(double.Parse(Program.currentNumber));
            Input.Text += " ÷ ";
            Program.operations.Add("÷");
            Program.currentNumber = "";
        }

        private string lastOperation = "";
        private string lastNumber = "";
        private void Button_Equals_Click(object sender, EventArgs e)
        {
            if (Program.isUndefined == true)
            {
                return;
            }
            if (Output.Text.Length > 0 && Program.numbers.Count != 0)
            {
                double result = Convert.ToDouble(Output.Text);
                ClearCalculator();
                Program.numbers.Add(result);
                Program.currentNumber = lastNumber;
                Program.operations.Add(lastOperation);
                Input.Text = Program.CreateInputText() + Program.currentNumber;

            }
            if (Program.currentNumber == "" || Program.operations.Count == 0)
            {
                if (Program.numbers.Count == 0)
                {
                    lastNumber = Input.Text;
                    Output.Text = Input.Text;
                }
                return;
            }
            lastOperation = Program.operations[Program.operations.Count - 1];
            if (Program.currentNumber[Program.currentNumber.Length - 1] == '.')
            {
                Input.Text = Input.Text + "0";
            }
            Program.numbers.Add(double.Parse(Program.currentNumber));
            lastNumber = Program.currentNumber;
            Program.currentNumber = "";
            Program.Calculate();
            if (Program.isUndefined == true)
            {
                Output.Text = "Undefined";
                return;
            }
            Output.Text = Math.Round(Program.numbers[0], 5).ToString();
        }

        private void Button_AC_Click(object sender, EventArgs e)
        {
            ClearCalculator();
        }

        private void ClearCalculator()
        {
            Program.currentNumber = "";
            Program.numbers.Clear();
            Program.operations.Clear();
            Input.Text = "";
            Output.Text = "";
            Program.isUndefined = false;
        }

        private void Button_Undo_Click(object sender, EventArgs e)
        {
            if (Output.Text.Length > 0)
            {
                return;
            }    
            if (Program.currentNumber != "" && Program.operations.Count > 0)
            {
                Program.currentNumber = Program.currentNumber.Remove(Program.currentNumber.Length - 1);
                Input.Text = Program.CreateInputText() + Program.currentNumber;
                return;
            }
            else if (Program.operations.Count > 0)
            {
                Program.operations.RemoveAt(Program.operations.Count - 1);
                Program.currentNumber = Program.numbers[Program.numbers.Count - 1].ToString();
                Input.Text = Program.CreateInputText();
                Program.numbers.RemoveAt(Program.numbers.Count - 1);
                return;
            }
            else if (Input.Text.Length > 0)
            {
                Program.currentNumber = Input.Text;
                Program.currentNumber = Program.currentNumber.Remove(Program.currentNumber.Length - 1);
                Input.Text = Program.currentNumber;
                return;
            }
        }

        private void Button_Period_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber.Contains("."))
            {
                return;
            }
            if (Output.Text != "")
            {
                ClearCalculator();
            }
            if (Program.currentNumber == "")
            {
                Program.currentNumber = "0.";
                Input.Text = "0.";
                return;
            }

            Program.currentNumber += ".";
            Input.Text += ".";
        }

        private void Button_ChangeSign_Click(object sender, EventArgs e)
        {
            if (Program.currentNumber == "")
            {
                return;
            }
            Program.currentNumber = (double.Parse(Program.currentNumber) * -1).ToString();
            Input.Text = Program.CreateInputText() + Program.currentNumber;
        }

        private void ContinueOperation()
        {
            string tempNumber = Output.Text;
            ClearCalculator();
            Program.currentNumber = tempNumber;
            Input.Text = Program.currentNumber;
        }
    }
}
