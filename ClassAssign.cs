using System;
namespace MeasureConvert
{
	public class ClassAssign
	{
		public string call_class(string measurement, string startingunit, string endingunit, string value)
		{
			if (startingunit.Equals(endingunit)) { return value; }

			if (measurement.Equals("Distance")) 
			{ 
				String[] labels = new String[6] { "Miles", "Feet", "Inches", "Centimeters", "Meters", "Kilometers" };
				double[] dividends = { 5280.0, 12.0, 2.54, 1.0 / 100.0, 1.0 / 1000.0 };
				ConvertUnits convertdistance = new ConvertUnits(labels, dividends, startingunit, endingunit, value);
				return convertdistance.return_value();
			}
			else if (measurement.Equals("Weight")) 
			{ 
				String[] labels = new String[7] { "Tons", "Slugs", "Pounds", "Ounces", "Grams", "Kilograms", "Metric Tons" };
				double[] dividends = new double[6] { 62.1619, 32.174, 16.0, 28.3495, 1.0 / 1000.0, 1.0 / 1000.0 };
				ConvertUnits convertweight=new ConvertUnits(labels, dividends, startingunit, endingunit, value);
				return convertweight.return_value();
			
			}

			else if (measurement.Equals("Volume"))
			{
				String[] labels = new String[11] { "Gallons", "Quarts", "Pints", "Cups", "Fluid Ounces", "Milliliters", "Liters", "Cubic Meters", "Cubic Inches", "Cubic Feet", "Cubic Yards" };
				double[] dividends = new double[10] { 4.0, 2.0, 2.0, 8.0, 29.5735, 0.001, 0.001, 61023.7, 0.000578704, 0.037037 };
				ConvertUnits convertvolume = new ConvertUnits(labels, dividends, startingunit, endingunit, value);
				return convertvolume.return_value();

			}

			else 
			{
				ConvertTemperature converttemp = new ConvertTemperature(startingunit, endingunit, value);
				return converttemp.return_value();
			}
		}
	}
}

