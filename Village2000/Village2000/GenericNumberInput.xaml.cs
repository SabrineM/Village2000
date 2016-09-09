using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Village2000
{
    public abstract partial class GenericNumberInput : UserControl
    {
    }

    public abstract class GenericNumberInput<T> : GenericNumberInput
    {

        protected T minValue;
        string prevValue = "";

        public GenericNumberInput(string defaultValue)
        {
            InitializeComponent();

            numberBox.Text = defaultValue;
            numberBox.KeyUp += numberBox_KeyUp;
            numberBox.KeyDown += numberBox_KeyDown;
        }

        public GenericNumberInput() : this("") { }
        public GenericNumberInput(int defaultValue) : this(defaultValue.ToString()) { }

        private void numberBox_KeyDown(object sender, KeyEventArgs e)
        {
            prevValue = numberBox.Text;
        }

        private void numberBox_KeyUp(object sender, KeyEventArgs e)
        {
            var caretIndex = numberBox.CaretIndex;

            var text = numberBox.Text.ToArray();
            var result = "";
            foreach (var c in text)
            {
                if (IsLegalChar(c))
                {
                    result += c;
                }
            }

            if (result != "" && !IsHigherThanMinvalue(ParseValue(result)))
            {
                result = prevValue;
            }

            numberBox.Text = result;
            numberBox.CaretIndex = caretIndex;
        }

        public T Value
        {
            get { return ParseValue(numberBox.Text); }
            set { numberBox.Text = value.ToString(); }
        }

        protected abstract T ParseValue(string value);
        protected abstract bool IsHigherThanMinvalue(T value);
        protected abstract bool IsLegalChar(char value);


        public void SetMinimumValue(T value)
        {
            minValue = value;
        }
    }

    public class IntInput : GenericNumberInput<int>
    {

        public IntInput() : base()
        {
            minValue = 0;
        }

        protected override int ParseValue(string value)
        {
            int number;
            var isNumber = Int32.TryParse(value, out number);
            return number;
        }

        protected override bool IsHigherThanMinvalue(int value)
        {
            return value >= (int)minValue;
        }
        protected override bool IsLegalChar(char c)
        {
            if (c.Equals('-'))
            {
                return true;
            }
            int number;
            return Int32.TryParse(c.ToString(), out number);
        }
    }

    public class DoubleInput : GenericNumberInput<double>
    {
        public DoubleInput() : base()
        {
            minValue = 0.0;
        }
        protected override double ParseValue(string value)
        {
            double number;
            var isNumber = Double.TryParse(value, out number);
            return number;
        }
        protected override bool IsHigherThanMinvalue(double value)
        {
            return value >= (double)minValue;
        }
        protected override bool IsLegalChar(char c)
        {
            if (c.Equals(',') || c.Equals('-'))
            {
                return true;
            }

            double number;
            return Double.TryParse(c.ToString(), out number);
        }
    }
}
