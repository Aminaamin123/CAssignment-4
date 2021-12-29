using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyOrganizer
{ //handle the list of participant and do other calculations and processing of the data
    class PartyManager
    {
        string[] guests;
        private double cost;
        private double fee;
        public PartyManager(int maxNumOfGuests)
        {
            guests = new string[maxNumOfGuests];
        }

        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value > 0.0)
                    cost = value;
            }
        }
        public double Fee
        {
            get
            {
                return fee;
            }
            set
            {
                if (value > 0)
                    fee = value;
            }
        }

        public bool AddNewGuest(string firstName, string lastName)
        {
            
            // add to list
            // guests[guests.Length] = fullName;

            int index = FindVacantPos();
            if (index >= 0)
            {
                guests[index] = FullName(firstName, lastName);
                return true;
            }

            return false;
        }

        public double CalcTotalCost()
        {
            return NumOfGuests() * cost;
        }
        public double CalcTotalFee()
        {
            return NumOfGuests() * fee;
        }

        public double CalcSD()
        {
            return Math.Abs((cost - fee) * NumOfGuests());
        }
        public bool ChangeAt(int index, string firstName, string lastName)
        {
            if (index < NumOfGuests())
            {
                guests[index] = FullName(firstName, lastName);
                return true;
            }
            return false;
        }

        public bool CheckIndex(int index)
        {
            // check if given index is out of range
            if ( index  <= guests.Length)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAt(int index)
        {
            guests[index] = string.Empty;
            MoveElementOneStepToLeft(index);
            return true;
        }

        public int FindVacantPos()
        {
            int index = -1; // no available
            for (int i = 0; i < guests.Length; i++)
            {
                if (String.IsNullOrEmpty(guests[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public string FullName(string firstName, string lastName)
        {
            return lastName.ToUpper() + ", " + firstName;
        }

        public string[] GetGuestList()
        {
            int size = NumOfGuests();
            if (size <= 0)
                return null;
            string[] guestList = new string[size];

            for (int i = 0, j =0; i<guests.Length; i++)
            {
                if (!string.IsNullOrEmpty(guests[i]))
                {
                    guestList[j++] = guests[i];
                }
            }
            return guestList;
        }

        public string GetItemAt(int index)
        {
            return guests[index];
        }

        public void MoveElementOneStepToLeft(int index)
        {
            for  (int i = index+1; i < guests.Length; i++)
            {
                guests[i - 1] = guests[i];
                guests[i] = string.Empty;
            }
        }
        public int NumOfGuests()
        {
            int nr = 0;
            for (int i = 0; i < guests.Length; i++)
            {
                if(!string.IsNullOrEmpty(guests[i]))
                {
                    nr++;
                }
            }
            return nr;
        }


    }
}
