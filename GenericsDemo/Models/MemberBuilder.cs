using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Models
{
    //self refrerencing generic class
    public class MemberBuilder<T> where T : MemberBuilder<T>
    {
        protected string name;

        public T SetName(string name)
        {
            this.name = name;
            return (T)this;
        }

        public void Show()
        {
            Console.WriteLine("Name: " + name);
        }

    }
}
