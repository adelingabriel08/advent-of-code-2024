// See https://aka.ms/new-console-template for more information

using System.Text;

const Int32 BufferSize = 128;
string fileName = "puzzle.txt";
var counter = 0;
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        var values = line.Split(' ').Where(x => x.Length > 0).ToArray();

        var valid = true;
        var increasing = true;
        for (var i = 0; i<values.Length-1; i++)
        {
            var current = int.Parse(values[i]);
            var next = int.Parse(values[i + 1]);
            if (i == 0)
            {
                increasing = current < next;
            }
            else
            {
                // short circuit if we identify wrong increase/decrease

                if (current < next != increasing)
                {
                    valid = false;

                    break;
                }
            }
            
            var difference = Math.Abs(current - next);
            
            if (difference < 1 || difference > 3)
            {
                valid = false;

                break;
            }
            
        }
        if (valid) counter++;
        
    }
}


Console.WriteLine(counter);