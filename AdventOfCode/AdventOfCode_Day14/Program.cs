// See https://aka.ms/new-console-template for more information

using System.Text;

const Int32 BufferSize = 128;
string fileName = "puzzle.txt";
var validPositions = new List<(float, float)>();
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string[] parts = line.Split(' ');

        var parsedData = new Dictionary<string, (float, float)>();

        foreach (string part in parts)
        {
            string[] keyValue = part.Split('=');
            if (keyValue.Length == 2)
            {
                string key = keyValue[0];
                string[] values = keyValue[1].Split(',');

                if (values.Length == 2 &&
                    float.TryParse(values[0], out float firstValue) &&
                    float.TryParse(values[1], out float secondValue))
                {
                    parsedData[key] = (firstValue, secondValue);
                }
            }
        }

        var width = 101;
        var height = 103;

        var initialPosition = parsedData["p"];
        var velocity = parsedData["v"];

        for (int i = 0; i < 100; i++)
        {
            var leftPosition = initialPosition.Item1;
            var heightPosition = initialPosition.Item2;

            leftPosition = leftPosition + velocity.Item1;
            heightPosition = heightPosition + velocity.Item2;
            
            leftPosition = AdjustPosition(leftPosition, width);
            heightPosition = AdjustPosition(heightPosition, height);

            initialPosition = (leftPosition, heightPosition);
        }

        if (initialPosition.Item1 != 101 / 2 && initialPosition.Item2 != 103 / 2)
        {
            validPositions.Add(initialPosition);
        }
        
    }

    var topLeftSpace = 0;
    var topRightSpace = 0;
    var BottomLeftSpace = 0;
    var BottomRightSpace = 0;

    foreach (var position in validPositions)
    {
        if (position.Item1 < 101 / 2 && position.Item2 < 103 / 2)
        {
            topLeftSpace++;
        }
        else if (position.Item1 > 101 / 2 && position.Item2 < 103 / 2)
        {
            topRightSpace++;
        }
        else if (position.Item1 < 101 / 2 && position.Item2 > 103 / 2)
        {
            BottomLeftSpace++;
        }
        else if (position.Item1 > 101 / 2 && position.Item2 > 103 / 2)
        {
            BottomRightSpace++;
        }
    }
    
    Console.WriteLine(topLeftSpace * topRightSpace * BottomLeftSpace * BottomRightSpace);
}

float AdjustPosition(float position, int maxValue)
{
    if (position < 0)
        return maxValue-((position) * -1);

    if (position >= maxValue)
        return position-maxValue;

    return position;
}

