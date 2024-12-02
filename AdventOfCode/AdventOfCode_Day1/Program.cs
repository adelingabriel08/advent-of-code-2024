// See https://aka.ms/new-console-template for more information

using System.Text;

const Int32 BufferSize = 128;
string fileName = "puzzle.txt";
List<long> left = new List<long>();
List<long> right = new List<long>();
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        var values = line.Split(' ').Where(x => x.Length > 0).ToArray();
        
        var firstNumber = long.Parse(values[0]);
        var secondNumber = long.Parse(values[1]);
        
        left.Add(firstNumber);
        right.Add(secondNumber);
    }
}

left.Sort();
right.Sort();


long distance = 0;
for (Int32 i = 0; i < left.Count; i++)
{
    distance += Math.Abs(left[i] - right[i]);
}


Console.WriteLine(distance);