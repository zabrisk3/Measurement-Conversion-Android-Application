using System;
namespace MeasureConvert
{
	public class ConvertUnits
	{
		private String[] labels;
		private double[] dividends;
		private int first_index;
		private int second_index;
		private int index_difference;
		private int index_sign;
		private double value_1;


		public ConvertUnits(String[] Labels, double[] numbers, string firstunit, string secondunit, string value)
		{
			this.labels = Labels;
			this.dividends = numbers;
			this.first_index = Array.IndexOf(labels, firstunit);
			this.second_index = Array.IndexOf(labels, secondunit);
			this.index_difference = second_index - first_index;
			this.index_sign = Math.Sign(index_difference);
			this.value_1 = Double.Parse(value);
		}
	
		public double multiply_divide(double number2, double number1, int sign)
		{
			if (sign > 0) { return RoundToSignificantDigits(number1 * number2, 4); }
			else { return RoundToSignificantDigits(number1 / number2, 4); }
		}

		double RoundToSignificantDigits(double d, int digits)
		{
			double EPSILON = 0.00000001;
			if (Math.Abs(d) < EPSILON)
			{
				return 0;
			}

			double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
			return scale * Math.Round(d / scale, digits);
		}
		public string return_value()
		{
			if (index_sign > 0)
			{
				for (int i = first_index; i < second_index; i++)
				{
					value_1 = multiply_divide(dividends[i], value_1, index_sign);
					//value_1 = numbers_functions(i, value_1, index_sign);
				}
			}
			else
			{
				for (int i = first_index - 1; i >= second_index; i = i - 1)
				{
					value_1 = multiply_divide(dividends[i], value_1, index_sign);
					//value_1 = numbers_functions(i, value_1, index_sign);
				}

			}
			return value_1.ToString();
		}
	
	
	}
}

