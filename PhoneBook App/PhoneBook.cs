using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_App
{
    class PhoneBook
    {
        private string[] names = { "Amina", "Meryem", "Selina", "Anna", "Volkan" };
        private string[] phones = { "040-22411", "040-27742", "040-54323", "040-002374", "040-66535" };
        private string[,] phoneList;

        public PhoneBook()
        {

            Console.Clear();

            DisplayList();
            SortByName();
            Console.WriteLine("Sorted List: ");
            DisplayList();

            int count = names.Length;
            phoneList = new string[count, 2];
            FillTable();
            DisplayTable();
        }
        public void DisplayList()
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write(string.Format("{0, -8}", names[i] ));
                Console.Write(string.Format("{0, -15}", phones[i])+"\n");
            }
            Console.WriteLine("");
            
        }
        private void DisplayTable()
        {
            int rows = phoneList.GetLength(0); 
            int cols = phoneList.GetLength(1);

            Console.WriteLine("\nDisplay 2d array:");
            Console.WriteLine("");

            for (int row = 0; row < rows; row++)
            {
                Console.Write(string.Format("{0, -8}", "Row " + row.ToString()));
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0,-15}", phoneList[row, col]));
                }
                Console.WriteLine("");
            }
        }
        public void FillTable()
        {
            for (int row = 0; row < names.Length; row++)
                {
                    phoneList[row, 0] = names[row]; 
                    phoneList[row, 1] = phones[row];
                
                }
            
  
        }

        public void SortByName()
        {
            int pos, i;
            int lenght = names.Length;

            for (pos=0; pos < lenght -1; pos++)
            {
                for (i=0; i < lenght -pos -1; i++)
                {
                    int result = names[i].CompareTo(names[i + 1]);

                    if (result == 1 )
                    { 
                        SwapValues(i);
                    }
                }
            }


        }

        public void SwapValues(int pos)
        {
            string temp = names[pos];
            names[pos] = names[pos + 1];
            names[pos + 1] = temp;

            temp = phones[pos];
            phones[pos] = phones[pos + 1];
            phones[pos + 1] = temp;
        }


    }



}
