using System;

namespace CSAssignment2
{   
    class Program
    {   /// <summary>
    /// Main function that asks for question number
    /// and runs the respective code
    /// using the respective classes
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(ConstantString.EnterChoice+ ConstantString.EndLine);
            int switchCase = Convert.ToInt32(Console.ReadLine());
            switch (switchCase)
            {
                case 1:
                    {
                        try
                        {   //enter name and path of file.
                            Console.WriteLine(Class1Constants.EnterFileName+ConstantString.EndLine);
                            string fileName = Console.ReadLine();
                            Console.WriteLine(Class1Constants.EnterFolderName+ConstantString.EndLine);
                            string folderPath = Console.ReadLine();
                            if (FileSearch.IsFileExists(fileName, folderPath))//calling function that checks the existence of the file
                            { Console.WriteLine(Class1Constants.FileFound(true)); }
                            else
                            { Console.WriteLine(Class1Constants.FileFound(false)+ConstantString.EndLine); }
                        }
                        catch (Exception ex)//Throwimg Exception for wrong path
                        {
                            Console.WriteLine(Class1Constants.ExceptionMessage+ConstantString.EndLine);

                        }
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {

                        Console.WriteLine(Class2Constants.EnterSize+ConstantString.EndLine);             //taking size of cache from user.
                        int size = Convert.ToInt32(Console.ReadLine());
                        Cache<int, string> obj = new Cache<int, string>();  //Creating object of cache
                        Char Choice;
                        obj.counter = 0;
                        do
                        {
                            Console.WriteLine(Class2Constants.EnterValue+ConstantString.EndLine);        //taking value from User
                            int value = Convert.ToInt32(Console.ReadLine());
                            obj.AddVal(obj.counter, value.ToString(), size);        //adding value to cache.
                            Console.WriteLine(Class2Constants.EnterValueChoice+ConstantString.EndLine);     //Asking for more input values.
                            Choice = Convert.ToChar(Console.ReadLine());
                            obj.DisplayItems();     //Displyaing Entered Items.
                        } while (Choice == 'Y' || Choice == 'y');
                        Console.ReadKey();      //preparing to exit.
                        break;
                    }
                case 3:
                    {
                        BinaryTree<int> tree = new BinaryTree<int>().newnode(1);

                        tree.left = tree.newnode(2);
                        tree.right = tree.newnode(3);
                        tree.left.left = tree.newnode(4);
                        tree.left.right = tree.newnode(5);
                        tree.right.left = tree.newnode(6);
                        tree.right.right = tree.newnode(7);
                        Console.WriteLine(Class3Constants.LevelOrder+ConstantString.EndLine);
                        tree.LevelOrderTraversal(tree);         //calling function that traverses level order.
                        Console.WriteLine(ConstantString.CRLF);
                        Console.WriteLine(Class3Constants.SprialOrder+ConstantString.EndLine);
                        tree.SpiralOrderTraversal(tree);        //Calling function that traverses from spiral order .

                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        int tokensize = 0;
                        int priority = 0;
                        Customer cust;
                        PriorityQueue<Customer> pq = new PriorityQueue<Customer>();//creating priority queue.
                        Console.WriteLine("\n Enter how many Tokens do you have?"); //taking tokens i.e Counterservice having no of counters.
                        tokensize = Convert.ToInt32(Console.ReadLine());
                        int[] tokens = new int[tokensize];

                        char choice;
                        int menu;
                        do
                        {
                            //Creating menu 
                            Console.WriteLine("===============================================");
                            Console.WriteLine("\n1.Enter Customers in Queue");
                            Console.WriteLine("\n2.View total Customers");
                            Console.WriteLine("\n3.View Customers with assigned Tokens");
                            Console.WriteLine("\n0.Exit");
                            Console.WriteLine("===============================================");
                            Console.WriteLine("press 1,2,3,0 etc for the Following options");
                            menu = Convert.ToInt32(Console.ReadLine());
                            switch (menu)
                            {
                                case 1:
                                    {
                                        do
                                        {   //Adding a customer item to the queue 
                                            Console.WriteLine("\n Enter the Name of customer");
                                            string name = Console.ReadLine();
                                            Console.WriteLine("\n Enter the category of customer('N' for Normal & 'P' for Priviledged Category)");
                                            char category = Convert.ToChar(Console.ReadLine());
                                            if ( category == 'N' || category == 'n')//giving priority to category .
                                                priority = 0;
                                            if (category == 'P' || category == 'p')
                                                priority = 1;
                                            
                                            cust = new Customer(name, category, priority);
                                            pq.Enqueue(cust);
                                            Console.WriteLine("\n Want to Enter More Customer?(Y/N)");//Asking for more customers.
                                            choice = Convert.ToChar(Console.ReadLine());

                                        } while (choice == 'Y' || choice == 'y');
                                        Console.WriteLine("===DATA ADDED SUCESSFULLY===");
                                    }
                                    break;
                                case 2:
                                    { //calls DisplayCustomer() to view item details
                                        Console.WriteLine("\n Customer Are:");
                                        Console.WriteLine("NAME\t : CATEGORY");
                                        pq.DisplayCutomer();
                                    }
                                    break;
                                case 3:
                                    { //Displyaing users to whom tokens are assigned.
                                        Console.WriteLine("\n Token Assigned to Users are:");
                                        Console.WriteLine("NAME\t:CATEGORY\t:TOKEN-NO");
                                        pq.AssignedTokens(tokens, pq);
                                    }
                                    break;
                                case 0:
                                    //Exiting
                                    { Console.WriteLine("==GOODBYE=="); }
                                    break;
                                default:
                                    { //default case 
                                        Console.WriteLine("**Sorry! Section is not Valid Menu item**");
                                        Console.WriteLine("**Please Try again.**");
                                    }
                                    break;
                            }
                        } while (menu != 0);

                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine(ConstantString.ChoiceErrorMessage+ConstantString.EndLine);
                        break;
                    }

            }
        }
    }
}
