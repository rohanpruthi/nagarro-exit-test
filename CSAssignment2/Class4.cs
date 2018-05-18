using CSAssignment2;
using System;
using System.Collections.Generic;

namespace CSAssignment2
{
    public interface IMyInterface               //Creating interface to extract the data of customer type
    {
        string Name { get; set; }
        char Category { get; set; }
        int Priority { get; set; }
    }

    public class PriorityQueue<T> where T : IComparable<T>, IMyInterface      //making of priority queue
    {

        List<T> data = new List<T>();
        /// <summary>
        /// Adds an item the to que
        /// </summary>
        /// <param name="item">oject of queue having properties Name, Category and Priority</param>
        public void Enqueue(T item)
        {
            data.Add(item);         //Adding items to priority queue
        }
        /// <summary>
        /// removes an item from the queue
        /// </summary>
        /// <returns>removed item: object customer </returns>
        public T Dequeue()           //taking items from priority queue based upon the priority
        {

            int deleteIndex = new int();
            for (int index = default; index < data.Count - 1; index++)
            {

                if (data[index].CompareTo(data[index + 1]) > default(int))    //comparing priorities of customer type data
                {
                    deleteIndex = index + 1;             //if it has less priority then take index of next item which higher priority
                    break;
                }

            }
            T customer = data[deleteIndex];                //put higher priority data into customer variable.
            data.RemoveAt(deleteIndex);                    //remove the data
            return customer;                               //return the higher priority item.
        }
        public void DisplayCutomer()                       //used to display the customers 
        {
            foreach (T customer in data)
            {
                Console.Write("{0}\t:", customer.Name);
                if (customer.Category == 'p' || customer.Category == 'P')
                    Console.WriteLine("Priveledged");
                else if (customer.Category == 'n' || customer.Category == 'N')
                    Console.WriteLine("Normal");

            }
        }
        /// <summary>
        /// Prints category of a customer
        /// </summary>
        /// <param name="category"></param>
        public void Category(char category)                   //for category purpose 
        {
            // string strcat;
            if (category == 'n' || category == 'N')
                Console.Write("Normal");
            else if (category == 'p' || category == 'P')
            { Console.Write("Priveledged"); }
        }

        /// <summary>
        /// Assigning tokens to users based upon their priority
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="queue"></param>
        public void AssignedTokens(int[] tokens, PriorityQueue<T> queue)   
        {
            PriorityQueue<Customer> customer = new PriorityQueue<Customer>();
            for (int index = default; index < tokens.Length; index++)
            {

                if (tokens[index] == default(int))
                {
                    if (data.Count == 1)     //if only one element is in the queue then simply display it
                    {
                        Console.WriteLine("{0}\t:{1}\t\t:Token{2}", data[default].Name, data[default].Category, (index + 1));
                        tokens[index] = 1;//filling assigned tokens as 1.
                        break;
                    }
                    else if (data.Count > 1)
                    {
                        for (int i = default; i < data.Count; i++)   //if more than one elemnts are there in the queue then assign tokens to them acc to their priority.
                        {
                            T cust = queue.Dequeue(); //calling dequeue function.
                            Console.WriteLine("{0}\t:{1}\t\t:Token{2}", cust.Name, cust.Category, (index + 1));
                            tokens[index] = 1;//filling assigned tokens as 1.
                            break;
                        }
                    }
                }

            }

        }

        /// <summary>
        /// peek value of priority queue items
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            T frontItem = data[0];      
            return frontItem;
        }
        /// <summary>
        /// count of priorityQueue items
        /// </summary>
        public int Count()
        {
            return data.Count;          
        }

    }
    class Customer : IComparable<Customer>, IMyInterface    //customers class to contains its data
    {

        public string Name { get; set; }
        public char Category { get; set; }
        public int Priority { get; set; }

        /// <summary>
        /// constructor of class Customer
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <param name="category">Category of customer</param>
        /// <param name="priority">Priority of customer</param>
        public Customer(string name, char category, int priority)
        {
            this.Name = name;
            this.Category = category;
            this.Priority = priority;
        }
       public enum ReturnType
        {
            zero=0,
            positive=1,
            negative=-1
        }
        /// <summary>
        /// comparing customers based upon priority
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Customer other)  
        {
            if (this.Priority > other.Priority) return Convert.ToInt32(ReturnType.negative);
            else if (this.Priority < other.Priority) return Convert.ToInt32(ReturnType.positive);
            else return Convert.ToInt32(ReturnType.zero);
        }
        public void Display()
        {
            Console.WriteLine("{0}:{1}", this.Name, this.Category);  //displaying customer type data
        }

    }
}
