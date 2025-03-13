using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Repository
{
    class GenericRepository<T> where T :struct
    {

        public void GetValues(List<T> items)
        {
            // chain of operations
            items.ToList().ForEach(item => 
            Console.WriteLine(item));

        }
    }
}
