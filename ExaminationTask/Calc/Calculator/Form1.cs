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
        private CalculatorView calculatorView;
        private string currentValue;

        //memory
        bool hasMemory;
        Operation operation;
        double firstOperand;

        public Form1()
        {
            InitializeComponent();

            currentValue = "0";
            InvalidateResultTextBox();

            calculatorView = CalculatorView.Standard;
            InvalidateCalculatorView();
        }

        private void InvalidateResultTextBox()
        {
            ResultTextBox.Text = currentValue;
        }
        private void InvalidateCalculatorView()
        {
            if (calculatorView == CalculatorView.Scientific)
                ScientificPanel.Visible = true;
            else
                ScientificPanel.Visible = false;
        }
        private void MemorizeNumber()
        {
            double number = double.Parse(currentValue);
            firstOperand = number;

            hasMemory = true;
        }
        private void ResetMemory()
        {
            firstOperand = double.NaN;
            currentValue = "0";

            hasMemory = false;
        }

        #region Num & other input buttons

        private void NumButton_Click(object sender, EventArgs e)
        {
            int digit = int.Parse((sender as Button).Text);

            currentValue = CalculatorInput.TryAddDigit(currentValue, digit);

            InvalidateResultTextBox();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            currentValue = "0";

            ResetMemory();

            InvalidateResultTextBox();
        }
        private void ChangeSignButton_Click(object sender, EventArgs e)
        {
            double number = double.Parse(currentValue);
            number = -number;
            currentValue = number.ToString();

            InvalidateResultTextBox();
        }
        private void DotButton_Click(object sender, EventArgs e)
        {
            currentValue = CalculatorInput.TryAddDecimalSeparator(currentValue);

            InvalidateResultTextBox();
        }
        //кнопка "="    
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (!hasMemory)
                return;

            var number = double.Parse(currentValue);
            bool error = false;
            double result = double.NaN;
            switch (operation)
            {
                case Operation.Addition:
                    result = firstOperand + number;
                    break;
                case Operation.Subrtaction:
                    result = firstOperand - number;
                    break;
                case Operation.Multiplication:
                    result = firstOperand * number;
                    break;
                case Operation.Division:
                    if (number == 0)
                    {
                        MessageBox.Show("Division by zero is not allowed");
                        error = true;
                    }
                    else
                    {
                        result = firstOperand / number;
                    }
                    break;
                case Operation.Power:
                    result = Math.Pow(firstOperand, number);
                    break;
            }
            if (error)
            {
                currentValue = "0";
            }
            else
            {
                currentValue = "= " + result.ToString();
            }

            InvalidateResultTextBox();

            ResetMemory();
        }
        #endregion

        #region Binary operations
      
        private void AdditionButton_Click(object sender, EventArgs e)
        {
            if (hasMemory)
                return;

            MemorizeNumber();
            operation = Operation.Addition;

            currentValue = "0";
        }
        
        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            if (hasMemory)
                return;

            MemorizeNumber();
            operation = Operation.Subrtaction;

            currentValue = "0";
        }
        
        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (hasMemory)
                return;

            MemorizeNumber();
            operation = Operation.Multiplication;

            currentValue = "0";
        }
        
        private void DivisionButton_Click(object sender, EventArgs e)
        {
            if (hasMemory)
                return;
           
            MemorizeNumber();
            operation = Operation.Division;
            
            currentValue = "0";
        }
       
        private void PowerButton_Click(object sender, EventArgs e)
        {
            if (hasMemory)
                return;

            MemorizeNumber();
            operation = Operation.Power;

            currentValue = "0";
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
            calculatorView = CalculatorView.Standard;
            InvalidateCalculatorView();
        }
        
        private void ScientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculatorView = CalculatorView.Scientific;
            InvalidateCalculatorView();
        }
        #endregion

        #region Unary operations
        
        private void CalculatePower(double power)
        {
            var number = double.Parse(currentValue);
            number = Math.Pow(number, power);
            currentValue = number.ToString();

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
            var number = double.Parse(currentValue);

            if (number < 0)
            {
                MessageBox.Show("Factorial could be calculated from positive number.");
                return;
            }

            //проверка на натуральное число
            int nNumber = (int)number;
            if (number - nNumber != 0)
            {
                MessageBox.Show("Factorial could be calculated from natural number.");
                return;
            }

            long fact = 1;
            for (int i = 1; i <= number; i++)
                fact *= i;

            currentValue = fact.ToString();
            InvalidateResultTextBox();
        }
        #endregion
       
        private void QuadraticEquationButton_Click(object sender, EventArgs e)
        {
            QuadraticEquationCoefficientsForm form = new QuadraticEquationCoefficientsForm();
            form.FormClosed += Form_FormClosed;
            form.Show();
        }
        //вывод результата решения уравнения в текстовое поле в виде строки с указанием значением корней уравнения
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

                currentValue =  QuadraticEquationSolver.RootsToString(roots);
                InvalidateResultTextBox();
            }
        }
    }
}
