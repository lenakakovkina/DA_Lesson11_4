using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

var diaryWithMarks = new Dictionary<string, List<int>>();

while (true)
{
    Console.WriteLine("\nInput subject and mark separated by a colon (or type 'stop' to finish):");
    String userInput = Console.ReadLine();

    if (userInput.ToLower() == "stop")
        break;

  
    string subjectName = Regex.Replace(userInput, ":.*", "").Trim();
    string marksOnly = Regex.Replace(userInput, ".*?:", "").Trim();

    if (int.TryParse(marksOnly, out int marksOnlyToInt))
    {
        if (!diaryWithMarks.ContainsKey(subjectName))
        {
            // If subject does not exist, create a new list and add the mark
            diaryWithMarks[subjectName] = new List<int>();
        }

        // Add the mark to the existing or new subject list
        diaryWithMarks[subjectName].Add(marksOnlyToInt);
    }
    else
    {
        Console.WriteLine("\nInvalid mark input. Please enter a valid integer.");
    }

    Console.WriteLine("\nHere is list of subjects and their marks:");
    foreach (var entry in diaryWithMarks)
    {
        int quantityOfMarks = entry.Value.Count;
        int sumOfMarks = entry.Value.Sum();
        double averageMark = sumOfMarks / quantityOfMarks;
        Console.WriteLine($"Subject: {entry.Key}; Marks: {string.Join(", ", entry.Value)} The averadge mark is:{averageMark}");
    }
}
