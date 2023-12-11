using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        string filePath = "path\\Puzzle Input.txt";

        if (File.Exists(filePath))
        {
            string inputData = ReadFromFile(filePath);

            List<List<int>> allBuckets = FindAllBuckets(inputData);
          

        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public static int totalSum = 0;
    public static int largestBucket = 0;
    private static List<List<int>> FindAllBuckets(string inputData)
    {
        string[] buckets = inputData.Split("\n");

        // Initialize a list to store all buckets
        List<List<int>> allBuckets = new List<List<int>>();
        // Iterate through each bucket
        List<int> bucketNumbers = new List<int>();
        foreach (string bucket in buckets)
        {

            if (bucket.Equals(""))
            {

                int sum = 0;

                foreach (int number in bucketNumbers)
                {
                    sum += number;
                    if (largestBucket < sum)
                    {
                        largestBucket = sum;
                    }
                }

                
                //return allBuckets;
            }
            else
            {
                string[] parts = bucket.Split('\n');

                bucketNumbers.Add(int.Parse(parts[0]));

                allBuckets.Add(bucketNumbers);
            }
        }

        Console.WriteLine("largst bucket " + largestBucket);
        int largestThree = 3;
        List<int> topLargest = FindThreeTopLargest(bucketNumbers, largestThree);

        Console.WriteLine($"Top {largestThree} largest elements: " + string.Join(", ", topLargest));


        return allBuckets;
    }


    public static List<int> FindThreeTopLargest(List<int> numbers, int topN)
    {
        List<int> topLargest = numbers.OrderByDescending(n => n).Take(topN).ToList();
        return topLargest;
    }
    static string ReadFromFile(string filePath)
    {
        try
        {
            // Open the file with StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the entire content of the file
                string content = reader.ReadToEnd();

                // Display the content
             //   Console.WriteLine("File Content:");
              //  Console.WriteLine(content);
                return content;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"File Error occurred: {ex.Message}");
        }
        return "";
    }
}