using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_DesignPatterSingleton
{
    public class EagerSingleton
    {
        public static EagerSingleton instance;
        private EagerSingleton()
        {

        }

        public static EagerSingleton GetInstance()
        {
            {
                if (instance == null)
                    instance = new EagerSingleton();
                return instance;
            }
        }
    }
}
