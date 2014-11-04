using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmingprogram
{
    class Container
    {
        private int capacity;
        private int maxCapacity;
        private int amountOfItems;

        public Container(int capacity) {
            this.capacity = capacity;
            this.maxCapacity = capacity;
        }

        public Boolean add()
        {
            if (amountOfItems >= maxCapacity)
            {
                return false;
            }
            else
            {
                amountOfItems++;
            }
            return true;
        }

        public Boolean remove()
        {
            if (amountOfItems > 0)
            {
                amountOfItems--;
            }
            else
            {
                throw new IndexOutOfRangeException("Amount of items too low");
            }
            return true;
        }

        public int getAmountOfItems()
        {
            return amountOfItems;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public int getMaxCapacity()
        {
            return maxCapacity;
        }
    }
}
