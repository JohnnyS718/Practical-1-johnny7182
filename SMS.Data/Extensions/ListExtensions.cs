
namespace SMS.Data.Extensions;

// Static List Extension Class providing ToPrettyString and Print 
// extension method on any IList Collection
public static class ListExtension
{

    // print the list directly to the console
    public static void Print<T>(this IList<T> data)
    {
        Console.WriteLine(data.ToPrettyString());
    }

    
    // return a string representation of the IList parameter data
    public static string ToPrettyString<T>(this IList<T> data)
    {   
        // provide a suitable loop to construct a string from the IList data in format [ e1, e2, e3, ... ]
        var r = "[ ";
        //foreach(var e in data)
        foreach (var (value, i) in data.Select((value, i) => ( value, i )))
        {
            if (i < (data.Count - 1))
            {
                r += $"{value}, ";
            }
            else
            {
                r += $"{value} ";
            }
        }
        r = r + "]";

        // return the newly constructed string
        return r;
    }

}
