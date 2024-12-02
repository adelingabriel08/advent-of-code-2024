// See https://aka.ms/new-console-template for more information

using System.Text;

const Int32 BufferSize = 128;
string fileName = "puzzle.txt";
List<long> left = new List<long>();
Dictionary<long, long> right = new Dictionary<long, long>();
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        var values = line.Split(' ').Where(x => x.Length > 0).ToArray();

        var firstNumber = long.Parse(values[0]);
        var secondNumber = long.Parse(values[1]);

        left.Add(firstNumber);
        if (right.ContainsKey(secondNumber))
        {
            right[secondNumber] = ++right[secondNumber];
        }
        else
        {
            right.Add(secondNumber, 1);
        }
    }
}


long sum = 0;
foreach (var number in left) {
    if (right.ContainsKey(number)) {
        sum += number*right[number];
    }
}


Console.WriteLine(sum);