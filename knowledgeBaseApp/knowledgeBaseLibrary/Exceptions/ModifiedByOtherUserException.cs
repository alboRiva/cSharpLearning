using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary.Exceptions
{
    public class ModifiedByOtherUserException: Exception
    {
        public ModifiedByOtherUserException(string message) : base(message)
        {
        }
    }
}
