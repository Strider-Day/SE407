using System.Net.Http.Headers;

namespace Mathmatics.ConsoleApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                string operation;
                int operand1, operand2;

                ValidateArguements(args, out operation, out operand1, out operand2);

                BasicMath basicMath = new BasicMath();

                int result;
                string operationDesc;


                switch(operation) 
                {
          
                    case "+":
                    {
                        result = basicMath.Add(operand1, operand2);
                        operationDesc = "plus";
                        break;
                    }
                    case "-":
                    {
                        result = basicMath.Subtract(operand1, operand2);
                        operationDesc = "minus";
                        break;
                    }
                    case "*":
                    {
                        result = basicMath.Multiply(operand1, operand2);
                        operationDesc = "multiplied by";
                        break;
                    }
                    case "/":
                    {
                        result = basicMath.Divide(operand1, operand2);
                        operationDesc = "divided by";
                        break;
                    }
                    default:
                    {
                        result = -1;
                        operationDesc = "Error";
                        break;
                    }
                }

                if (operationDesc == "Error")
                {
                    Console.WriteLine("An unexpectted error occured");
                }
                
                Console.WriteLine($"{operand1} {operationDesc} {operand2} is equal to {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private static void ValidateArguements(string[] args, out string operation, out int operand1, out int operand2)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("Not enough arguments.");
            }
            if (args[0] != "+" && args[0] != "-" && args[0] != "*" && args[0] != "/") 
            {
                throw new ArgumentException("First arguements must be a math operator.");
            }
            
            if (!int.TryParse(args[1], out operand1))
            {
                throw new ArgumentException("Second arguements must be a valid integer.");
            }
            if (!int.TryParse(args[2], out operand2))
            {
                throw new ArgumentException("Second arguements must be a valid integer.");
            }

            operation = args[0];
   
        }
    }
}
