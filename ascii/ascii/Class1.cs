using System.Text;


namespace ascii
{
    public class Class1
    {
        public static int asciiscore(string word)
        {
            byte[] chars = Encoding.ASCII.GetBytes(word);
            int score = 0;
            int tempscore = 0;

            for (int i = 1; i < chars.Length; i++)
            {
                tempscore = chars[i-1] - chars[i];
                score += tempscore;
            }
            return score;
        }

        public static void main(string[] args)
        {
            Console.Write(value: asciiscore("hello"));
        }
    }

    
}
