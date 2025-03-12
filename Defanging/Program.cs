namespace Defanging
{
    internal class Program
    {
        static String Defang(String s)
        {
            String defanged = s.Replace(".", "[.]");
            return defanged;
        }

        static void Main(string[] args)
        {
            Console.Write(Defang("1.1.1.1"));
        }
    }
}
