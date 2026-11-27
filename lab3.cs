using System;
using System.Diagnostics;
using System.Text;

namespace Program
{
    class Prog
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            bool ProgramRun = true;

            while (ProgramRun)
            {
                Console.WriteLine(" --- Main menu --- ");
                Console.WriteLine("1. Guess the answer");
                Console.WriteLine("2. About the author");
                Console.WriteLine("3. Array sorting");
                Console.WriteLine("4. Exit");

                Console.Write("Enter the number from 1 to 4: ");
                int choice = MenuChoice();
                

                switch(choice)
                {
                    case 1:
                        ExecuteGameMode();
                        break;
                    case 2:
                        ShowAutchorInfo();
                        break;

                    case 3:
                        ExecuteSortingMode();
                        break;

                    case 4:
                        if (ConfirmExit())
                        {
                            ProgramRun = false;
                        }
                        break;
                }
            }
        }

//Методы для меню:
        public static int MenuChoice()
        {
            int choice1;
            while (!int.TryParse(Console.ReadLine(), out choice1) || choice1 < 1 || choice1 > 4)
            {
                Console.WriteLine("Error, re-enter the number");
                Console.Write("Enter the number from 1 to 4: ");
            }
        return choice1;
        }

// Методы для case 1:
        public static void ExecuteGameMode()
        {
            Console.WriteLine(" --- Guess the answer --- ");

            double a = 0;
            double Res = 0;
            double Znamenatel = Math.Sqrt(Math.Log(Math.Pow(Math.E, 2), 3));

            bool VInput = false;

            while (!VInput)
            {
                Console.Write("Enter the a: ");

                if (double.TryParse(Console.ReadLine(), out a))
                {
                    if (Math.Round(Math.Cos(2*a), 2) == 0 || Znamenatel == 0)
                    {
                        Console.WriteLine("Error, tangent cannot be found or you are divinding by zero");
                    }
                    else
                    {
                        Res = CalculateFunc(a, Znamenatel);
                        VInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("This is not a number");
                }
            }
            ExecuteGuessGame(Res);
        }

        public static void ExecuteGuessGame(double Result)
        {
            double Suppositoin = 0;
            bool Win = false;

            for (int i = 0; i < 3 && !Win; i++)
            {
                Console.Write("Enter the supposed answer: ");
                
                while (!double.TryParse(Console.ReadLine(), out Suppositoin))
                {
                    Console.WriteLine("This is not a number-");
                    Console.Write("Enter the supposed anwer: ");
                }

                if (Math.Round(Suppositoin, 2) == Result)
                {
                     Win = true;
                }
                else
                {
                    int tryes = 2 - i;

                    if (tryes > 0)
                    {
                        Console.WriteLine("Incorrent answer, you have " + tryes + " left");
                    }
                }
            }

            if (Win)
            {
                Console.WriteLine("Congratulations, the answer is correct!");
            }

            else
            {
                Console.WriteLine("You lose. No more attempts");
                Console.WriteLine("The answer is: " + Result);
            }

            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine(); 

        }

        public static double CalculateFunc(double a1, double znamenatel)
        {
            double Res = 0;
            double Chislitel = Math.Sin(a1) + Math.Tan(2*a1);
            Res = Math.Round(Chislitel / znamenatel, 2);
            return(Res);
        }

// Методы для case 2:
        public static void ShowAutchorInfo()
        {
            Console.WriteLine(" --- Author information --- ");
            Console.WriteLine("Student: Передрий Арсений Витальевич");
            Console.WriteLine("Group number: 6105-090301D");
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
        }

// Методы для case 3:
        public static int ArraySize()
        {
            int size = 0;
            Console.Write("Enter the array size n: ");
            while(!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Enter the correct size n: ");
            }
            return size;
        }

        public static int[] CreateArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(-100, 101);
            }
            return array;
        }

        public static int[] CloneArray(int[] arr)
        {
            int[] array2 = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                array2[i] = arr[i];
            }
            return array2;
        }

        public static void PrintArray(int[] array)
        {
            if (array.Length > 10)
            {
                Console.WriteLine("Ошибка! Массивы не могут быть выведены, если длина > 10");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }

        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = tmp;
                    }
                }
            }
            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int MinIndex = i;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] < array[MinIndex])
                    {
                        MinIndex = j;
                    }
                }
                int tmp = array[MinIndex];
                array[MinIndex] = array[i];
                array[i] = tmp;
            }
            return array;
        }

        public static  void ExecuteSortingMode()
        {
            Console.Write(" - Array sorting -");

            int size = ArraySize();
            int[] OriginalArray = CreateArray(size);

            int[] ArrayBubble = CloneArray(OriginalArray);
            int[] ArraySelection = CloneArray(OriginalArray);

            Console.WriteLine("Array before sorting: ");
            PrintArray(OriginalArray);

            Stopwatch SwBubble = Stopwatch.StartNew(); //SwBubble начинает отсчитывать время
            int[] SortedBubble = BubbleSort(ArrayBubble);
            SwBubble.Stop(); //Остановка секундомера

            Stopwatch SwSelection = Stopwatch.StartNew(); //SwSelection начинает отсчитывать время
            int[] SortedSelection = SelectionSort(ArraySelection);
            SwSelection.Stop(); //Остановка секундомера

            Console.WriteLine("Array after sorting: ");
            PrintArray(SortedBubble);

            Console.WriteLine("Bubble sort time: " + SwBubble.Elapsed.TotalMilliseconds + " ms");
            Console.WriteLine("Selection sort time: " + SwSelection.Elapsed.TotalMilliseconds + " ms");

            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine();
        }   

// Методы для case 4:
        public static bool ConfirmExit()
        {

            bool Exit = false;
            bool CloseProg = false;

            while (!Exit)
            {
                Console.WriteLine("Enter д/н: ");
                string input = Console.ReadLine();

                if (input=="д")
                {
                    CloseProg = true;
                    Exit = true;
                }
                else if (input == "н")
                {
                    CloseProg = false;
                    Exit = true;
                }
                else
                {
                    Console.WriteLine("Enter only д/н: ");
                }
            }
            return CloseProg;
        }
    }
}