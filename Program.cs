using System;

class AssignmentTask
{
    static void Main()
    {
        double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        int n = data.Length;

        Array.Sort(data);

        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += data[i];
        }
        double mean = sum / n;

        double modeValue = data[0];
        int maxCount = 0;
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (data[j] == data[i]) count++;
            }
            if (count > maxCount)
            {
                maxCount = count;
                modeValue = data[i];
            }
        }

        double median;
        if (n % 2 != 0)
            median = data[n / 2];
        else
            median = (data[(n / 2) - 1] + data[n / 2]) / 2.0;

        double vSum = 0;
        double sumDevs = 0;
        for (int i = 0; i < n; i++)
        {
            vSum += Math.Pow(data[i] - mean, 2);
            sumDevs += (data[i] - mean);
        }
        double variance = vSum / n;
        double stdDev = Math.Sqrt(variance);

        double p20 = data[(int)(0.20 * (n - 1))];
        double p50 = median;
        double q1 = data[(int)(0.25 * (n - 1))];
        double q2 = median;
        double q3 = data[(int)(0.75 * (n - 1))];

        double range = data[n - 1] - data[0];
        double iqr = q3 - q1;

        Console.WriteLine("--- Assignment 1 ---");
        Console.WriteLine("(i) Mean: " + mean);
        Console.WriteLine("(ii) Mode: " + modeValue);
        Console.WriteLine("(iii) Median: " + median);
        Console.WriteLine("(iv) Variance: " + Math.Round(variance, 3));
        Console.WriteLine("(v) P20: " + p20);
        Console.WriteLine("(vi) P50: " + p50);
        Console.WriteLine("(vii/ix) Third Quartile: " + q3);
        Console.WriteLine("(viii) Second Quartile: " + q2);
        Console.WriteLine("(x) Range: " + range);
        Console.WriteLine("(xi) Interquartile Range: " + iqr);
        Console.WriteLine("(xii) Standard Deviation: " + Math.Round(stdDev, 3));
        Console.WriteLine("(xiii) Summation of Deviations: " + Math.Round(sumDevs, 2));

        Console.WriteLine("\n--- Assignment 2 ---");
        double lowLimit = q1 - (1.5 * iqr);
        double highLimit = q3 + (1.5 * iqr);

        Console.WriteLine("Lower Limit = " + lowLimit);
        Console.WriteLine("Upper Limit = " + highLimit);

        for (int i = 0; i < n; i++)
        {
            if (data[i] < lowLimit || data[i] > highLimit)
            {
                Console.WriteLine("Value " + data[i] + " is an outlier");
            }
            else
            {
                Console.WriteLine("Value " + data[i] + " is normal");
            }
        }
    }
}