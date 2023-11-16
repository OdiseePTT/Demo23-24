namespace BMI
{
    public static class BMICalculator
    {
        public static BMIResult CalculateBMI(double height, double weight)
        {
            if (height > 0 && weight > 0)
            {
                double bmi = weight / Math.Pow(height / 100, 2);
                string category = GetBMICategory(bmi);
                return new BMIResult { Value = bmi, Category = category };
            }
            else
            {
                return null;
            }
        }

        public static bool IsValidInputs(double height, double weight)
        {
            return height > 0 && weight > 0;
        }

        private static string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 24.9)
                return "Normal weight";
            else if (bmi < 29.9)
                return "Overweight";
            else
                return "Obese";
        }
    }

    public class BMIResult
    {

        public double Value { get; set; }
        public string Category { get; set; }

    }
}