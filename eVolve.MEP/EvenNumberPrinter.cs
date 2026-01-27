namespace eVolve.MEP;

public class EvenNumberPrinter
{
    // so given 2 positive numbers
    public static void Print(int highest, int lowest)
    {
        // lets check to make sure we have the right order
        if (lowest > highest)
        {
            var temp = lowest;
            
            lowest = highest;
            highest = temp;
        }
        
        // print the event numbers between lowest and highest which is evenly / by the lowest
        // Given 17 and 4 output should be 4,8,12,16 - 4 5 6 7 8 9 10 11 12 13 14 15 16 17
        
        // 4 / 4, 8 / 4, 12 / 4, 16 / 4
        
        // 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21
       
        var list = Enumerable.Range(lowest, highest - lowest + 1);
        var allEventNumbers = list.Where(i => i % 2 == 0).ToList();
        
        allEventNumbers.Where(i => i % lowest == 0).ToList().ForEach(Console.WriteLine);
    }
}