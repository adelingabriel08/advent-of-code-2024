// // See https://aka.ms/new-console-template for more information
//
// using System.Text;
//
// const Int32 BufferSize = 128;
// string fileName = "puzzle.txt";
// var counter = 0;
// using (var fileStream = File.OpenRead(fileName))
// using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
//     String line;
//     while ((line = streamReader.ReadLine()) != null)
//     {
//         var values = line.Split(' ').Where(x => x.Length > 0).ToArray();
//
//         (bool valid, _) = Get(values);
//         if (valid) counter++;
//         else
//         {
//                 (bool valid2, bool alreadyUsed) = Get(values.Skip(1).ToArray());
//
//                 if (valid2 && !alreadyUsed) counter++;
//                 
//         }
//         
//     }
// }
//
//
//
// Console.WriteLine(counter);
//
// (bool, bool) Get(string[] values)
// {
//     var valid = true;
//     var increasing = true;
//     var alreadyRemoved = false;
//     var alreadyRemovedIndex = 0;
//     for (var i = 0; i<values.Length-1; i++)
//     {
//         int current, next;
//         if (alreadyRemoved && alreadyRemovedIndex == i)
//         {
//             current = int.Parse(values[i-1]);
//         }
//         else
//         {
//             current = int.Parse(values[i]);
//         }
//         
//         next = int.Parse(values[i + 1]);
//
//        
//         if (i == 0)
//         {
//             increasing = current < next;
//         }
//         else
//         {
//             // short circuit if we identify wrong increase/decrease
//
//             if (current < next != increasing)
//             {
//                 if (!alreadyRemoved)
//                 {
//                     alreadyRemoved = true;
//                     alreadyRemovedIndex = i+1;
//                 }
//                 else
//                 {
//                     valid = false;
//                     break;
//                 }
//             }
//         }
//         
//         var difference = Math.Abs(current - next);
//         
//         if (difference < 1 || difference > 3)
//         {
//             if (!alreadyRemoved)
//             {
//                 alreadyRemoved = true;
//                 alreadyRemovedIndex = i+1;
//             }
//             else
//             {
//                 valid = false;
//                 break;
//             }
//         }
//     }
//
//     return (valid, alreadyRemoved);
// }


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

        if (IsValidInput(values) == true)
        {
            counter++;
            continue;
        }

        
        for (int i = 0; i < values.Length; i++)
        {
            if (IsValidInput(values.Where((val, idx) => idx != i).ToArray()))
            {
                counter++;
                break;
            }
        }
        
    }
}

Console.WriteLine(counter);



bool IsValidInput(string[] values)
{
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

    return valid;
}

