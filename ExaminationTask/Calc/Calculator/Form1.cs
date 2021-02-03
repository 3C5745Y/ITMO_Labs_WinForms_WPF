using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public enum CalculatorView
    {
        Standard,
        Scientific,
    }

    public partial class Form1 : Form
    {
        private CalculatorView _calculatorView;
        private string _currentValue;

        //memory
        bool _hasMemory;
        Operation _operation;
        double _firstOperand;

        public Form1()
        {
            InitializeComponent();

            _currentValue = "0";
            InvalidateResultTextBox();

            _calculatorView = CalculatorView.Standard;
            InvalidateCalculatorView();
        }

        private void InvalidateResultTextBox()
        {
            ResultTextBox.Text = _currentValue;
        }
        private void InvalidateCalculatorView()
        {
            if (_calculatorView == CalculatorView.Scientific)
                ScientificPanel.Visible = true;
            else
                ScientificPanel.Visible = false;
        }

        private void MemorizeNumber()
        {
            double number = double.Parse(_currentValue);
            _firstOperand = number;

            _hasMemory = true;
        }
        private void ResetMemory()
        {
            _firstOperand = double.NaN;
            _currentValue = "0";

            _hasMemory = false;
        }

        #region Num & other input buttons

        private void NumButton_Click(object sender, EventArgs e)
        {
            int digit = int.Parse((sender as Button).Text);

            _currentValue = CalculatorInput.TryAddDigit(_currentValue, digit);

            InvalidateResultTextBox();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _currentValue = "0";

            ResetMemory();

            InvalidateResultTextBox();
        }

        private void ChangeSignButton_Click(object sender, EventArgs e)
        {
            double number = double.Parse(_currentValue);
            number = -number;
            _currentValue = number.ToString();

            InvalidateResultTextBox();
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            _currentValue = CalculatorInput.TryAddDecimalSeparator(_currentValue);

            InvalidateResultTextBox();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (!_hasMemory)
                return;

            var number = double.Parse(_currentValue);
            bool error = false;
            double result = double.NaN;
            switch (_operation)
            {
                case Operation.Addition:
                    result = _firstOperand + number;
                    break;
                case Operation.Subrtaction:
                    result = _firstOperand - number;
                    break;
                case Operation.Multiplication:
                    result = _firstOperand * number;
                    break;
                case Operation.Division:
                    if (number == 0)
                    {
                        MessageBox.Show("Division by zero is not allowed");
                        error = true;
                    }
                    else
                    {
                        result = _firstOperand / number;
                    }
                    break;
                case Operation.Power:
                    result = Math.Pow(_firstOperand, number);
                    break;
            }
            if (error)
            {
                _currentValue = "0";
            }
            else
            {
                _currentValue = "= " + result.ToString();
            }

            InvalidateResultTextBox();

            ResetMemory();
        }
        #endregion

        #region Binary operations

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            if (_hasMemory)
                return;

            MemorizeNumber();
            _operation = Operation.Addition;

            _currentValue = "0";
        }

        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            if (_hasMemory)
                return;

            MemorizeNumber();
            _operation = Operation.Subrtaction;

            _currentValue = "0";
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (_hasMemory)
                return;

            MemorizeNumber();
            _operation = Operation.Multiplication;

            _currentValue = "0";
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            if (_hasMemory)
                return;
           
            MemorizeNumber();
            _operation = Operation.Division;
            
            _currentValue = "0";
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            if (_hasMemory)
                return;

            MemorizeNumber();
            _operation = Operation.Power;

            _currentValue = "0";
        }

        #endregion

        #region Menu buttons handlers

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var helpFileText = File.ReadAllText(
                Path.Combine(Environment.CurrentDirectory, "Help.txt"));

            MessageBox.Show(helpFileText, "Calculator help");
        }

        private void StandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _calculatorView = CalculatorView.Standard;
            InvalidateCalculatorView();
        }

        private void ScientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _calculatorView = CalculatorView.Scientific;
            InvalidateCalculatorView();
        }
        #endregion

        #region Unary operations

        private void CalculatePower(double power)
        {
            var number = double.Parse(_currentValue);
            number = Math.Pow(number, power);
            _currentValue = number.ToString();

            InvalidateResultTextBox();
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            CalculatePower(0.5);
        }
        private void SquareButton_Click(object sender, EventArgs e)
        {
            CalculatePower(2);
        }
        private void ReciprocalButton_Click(object sender, EventArgs e)
        {
            CalculatePower(-1);
        }
        private void CubeRootButton_Click(object sender, EventArgs e)
        {
            CalculatePower(1.0 / 3);
        }

        private void FactorialButton_Click(object sender, EventArgs e)
        {
            var number = double.Parse(_currentValue);

            if (number < 0)
            {
                MessageBox.Show("Factorial could be calculated from positive number.");
                return;
            }

            //check if number is natural
            int nNumber = (int)number;
            if (number - nNumber != 0)
            {
                MessageBox.Show("Factorial could be calculated from natural number.");
                return;
            }

            long fact = 1;
            for (int i = 1; i <= number; i++)
                fact *= i;

            _currentValue = fact.ToString();
            InvalidateResultTextBox();
        }
        #endregion

        private void QuadraticEquationButton_Click(object sender, EventArgs e)
        {
            QuadraticEquationCoefficientsForm form = new QuadraticEquationCoefficientsForm();
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as QuadraticEquationCoefficientsForm;
            var dialogResult = form.DialogResult;
            if (dialogResult == DialogResult.OK)
            {
                var coeffs = form.Coeffs;

                double[] roots = null;
                QuadraticEquationSolver.Solve(coeffs[0], coeffs[1], coeffs[2],
                    out roots);

                _currentValue = QuadraticEquationSolver.RootsToString(roots);
                InvalidateResultTextBox();
            }
        }
    }
}
