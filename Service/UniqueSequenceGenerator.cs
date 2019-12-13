using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URl_Project.Service
{
    public class UniqueSequenceGenerator
    {
        public string GetSequence()
        {
            string result = string.Empty;

            result = System.Guid.NewGuid().ToString().Replace("-", "");

            return result;
        }
    }
}