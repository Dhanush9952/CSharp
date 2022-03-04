using System;
using System.IO;

namespace ExceptionHandling
{
    class addition
    {
        public int add(int n1,int n2)
        {
            int sum = n1+n2;
            System.Console.WriteLine("Addition value:{0}",sum);
            return 0;
        }
    }
    class Program
    {
          //Creating our own Exception Class by inheriting Exception class
    public class OddNumberException : Exception
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "Divisor cannot be ODD number";
            }
        }
    }
        static void Main(string[] args)
        {
            addition ad = new addition();
            ad.add(5,10);
            // int a = 20;
            // int b = 0;
            // int c;
            // Console.WriteLine("A VALUE = " + a);
            // Console.WriteLine("B VALUE = " + b);
            // c = a / b;                              // Exception - Divide by Zero
            // Console.WriteLine("C VALUE = " + c);

            int a1, b1, c1;

//   ---------- Handling Exception in C# using logical implementation ---------------
            Console.WriteLine("ENTER ANY TWO NUBERS");
            a1 = int.Parse(Console.ReadLine());
            b1 = Convert.ToInt32(Console.ReadLine());
            if (b1 == 0)                          
            {
                Console.WriteLine("second number should not be zero");
            }
            else
            {
                c1 = a1 / b1;
                Console.WriteLine("DIVIDED VALUE = " + c1);
            }

//   -----------handle an exception using try-catch implementation with the generic catch-----------
            System.Console.WriteLine("Enter 2 numbers: ");
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = a / b;
                Console.WriteLine("DIVIDE VALUE = " + c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
                // System.Console.WriteLine("Error Occured!!!");
            }
            System.Console.WriteLine("Enter 2 numbers: ");


            try
            {
                int a3 = int.Parse(Console.ReadLine());
                int b3 = int.Parse(Console.ReadLine());
                int c3 = a3 / b3;
                Console.WriteLine("DIVIDE VALUE = " + c3);
            }
            catch (DivideByZeroException dbe)
            {
                Console.WriteLine("2nd number should not be zero");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("enter only integer number");
            }
            finally
            {
                Console.WriteLine("Hello this is finally block");
            }

//    ----------Creating and throwing a custom exception in C#----------------
            
            int x, y, z;
            System.Console.WriteLine("------Custom Exceptions-------");
            Console.WriteLine("ENTER TWO INTEGER NUMBERS:");
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            try
            {
                if (y % 2 > 0)
                {
                    //OddNumberException ONE = new OddNumberException();
                    //throw ONE;
                    throw new OddNumberException();
                }
                z = x / y;
                Console.WriteLine(z);
            }
            catch (OddNumberException one)
            {
                Console.WriteLine(one.Message);
            }
            Console.WriteLine("End of the program");

            try
            {
                try
                {
                    //throw new ArgumentException();
                    Console.WriteLine("Enter First Number");
                    int FN = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Second Number");
                    int SN = Convert.ToInt32(Console.ReadLine());
                    int Result = FN / SN;
                    Console.WriteLine("Result = {0}", Result);
                }
                catch (Exception ex)
                {
                    //make sure this path does not exist
                    string filePath = @"C:\Dhanush\Full stack Training\C#\Log.txt";
                    if (File.Exists(filePath))
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.WriteLine(ex.GetType().Name + ex.Message + ex.StackTrace + ex.Source);
                        sw.WriteLine("!!!---MESSAGE CREATED BY MYSELF OUTPUT ERROR---!!!");
                        sw.Close();
                        Console.WriteLine("There is a problem! Plese try later or check log file @C:/Dhanush/Full stack Training/C#/Log.txt");
                    }
                    else
                    {
                        //To retain the original exception pass it as a parameter
                        //to the constructor, of the current exception
                        throw new FileNotFoundException(filePath + " Does not Exist", ex);
                    }
                }
            }
            catch (Exception e)
            {
                //e.Message will give the current exception message
                Console.WriteLine("Current or Outer Exception = " + e.Message);
                //Check if inner exception is not null before accessing Message property
                //else, you may get Null Reference Excception
                if (e.InnerException != null)
                {
                    Console.Write("Inner Exception : ");
                    Console.WriteLine(String.Concat(e.InnerException.StackTrace, e.InnerException.Message));
                }
            }

            try
            {
                Console.WriteLine("Please enter First Number");
                int FNO;
                //int.TryParse() will not throw an exception, instead returns false
                //if the entered value cannot be converted to integer
                bool isValidFNO = int.TryParse(Console.ReadLine(), out FNO);
                if (isValidFNO)
                {
                    Console.WriteLine("Please enter Second Number");
                    int SNO;
                    bool isValidSNO = int.TryParse(Console.ReadLine(), out SNO);
                    
                    if (isValidSNO && SNO != 0)
                    {
                        int Result = FNO / SNO;
                        Console.WriteLine("Result = {0}", Result);
                    }
                    else
                    {
                        //Check if the second number is zero and print a friendly error
                        //message instead of allowing DivideByZeroException exception 
                        //to be thrown and then printing error message to the user.
                        if (isValidSNO && SNO == 0)
                        {
                            Console.WriteLine("Second Number cannot be zero");
                        }
                        else
                        {
                            Console.WriteLine("Only numbers between {0} && {1} are allowed",
                                Int32.MinValue, Int32.MaxValue);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Only numbers between {0} && {1} are allowed",
                                Int32.MinValue, Int32.MaxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
