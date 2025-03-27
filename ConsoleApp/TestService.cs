namespace ConsoleApp;

internal class TestService
{
    public static int[] MultiplyByLength(int[] pArr)
    {
       var vTest = pArr
           .Select(pNum => pNum * pArr.Length)
           .ToArray();
       return vTest;
    }
}