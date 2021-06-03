using System;
using System.Collections.Generic;
using System.Text;
using TaxiHandler.Models;
using System.Linq;

namespace TaxiHandler.Services
{
   public class CountedData
    {
        Counts _counts;


        List<Counts> CountedList;


       public void Additem(Counts item)
        {
            List<Counts> counts = new List<Counts>();

            if(CountedList != null)
                 counts = CountedList;

            counts.Add(item);

            CountedList = counts;
            
    
        }


        public Counts GetItemById(string id)
        {
            Counts it = new Counts();
            foreach(var item in CountedList)
            {
                if(item.ID == id)
                {
                    it = item;
                }
            }
            
            return it;

        }

        public List<Counts> GetItems()
        {
            List<Counts> items = new List<Counts>();
            if(CountedList == null)
            {
                var item = new Counts()
                {
                    ID = Guid.NewGuid().ToString(),
                    InitialAmount = "0",
                    NumberOfPeople = "0",
                    Change = "0"
                };
                items.Add(item);
                return items;
            }
            else
            {
                return CountedList;
            }

        }



    }
}
