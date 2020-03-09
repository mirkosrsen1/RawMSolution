using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine
{
    public class Manager<T> where T : new()
    {
        private T _inst;

        public T Inst
        {
            get
            {
                if(_inst == null)
                {
                    _inst = new T();
                }

                return Inst;
            }
        }
    }
}
