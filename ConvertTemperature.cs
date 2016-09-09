using System;
namespace MeasureConvert
{
	public class ConvertTemperature
	{
		private String[] labels = new String[3] { "Fahrenheit", "Celsius", "Kelvin" };

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

		public double Fahrenheit_Celsius(double number, int sign)
		{
			if (sign > 0) { return RoundToSignificantDigits(number = 5.0 / 9.0 * (number - 32.0), 4); }
			else { return RoundToSignificantDigits(number = 9.0 / 5.0 * number + 32.0, 4); }
		}

		public double Celsius_Kelvin(double number, int sign)
		{
			if (sign > 0) { return RoundToSignificantDigits(number + 273.15, 4); }
			else { return RoundToSignificantDigits(number - 273.15, 4); }
		}

		public double numbers_functions(int assign, double value, int sign)
		{
			double answer = -1.0;
			switch (assign)
			{
				case 0:
					answer = Fahrenheit_Celsius(value, sign);
					break;
				case 1:
					answer = Celsius_Kelvin(value, sign);
					break;
			}
			return answer;
		}


		private int first_index;
		private int second_index;
		private int index_difference;
		private int index_sign;
		private double value_1;
		public ConvertTemperature(string firstunit, string secondunit, string value)
		{
			first_index = Array.IndexOf(labels, firstunit);
			second_index = Array.IndexOf(labels, secondunit);
			index_difference = second_index - first_index;
			index_sign = Math.Sign(index_difference);
			value_1 = Double.Parse(value);
		}

		public string return_value()
		{
			if (index_sign > 0)
			{
				for (int i = this.first_index; i < this.second_index; i++)
				{
					value_1 = numbers_functions(i, value_1, index_sign);
				}
			}
			else
			{
				for (int i = this.first_index - 1; i >= this.second_index; i = i - 1)
				{

					value_1 = numbers_functions(i, value_1, index_sign);
				}

			}
			return value_1.ToString();
		}
	}
}
