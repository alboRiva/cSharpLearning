using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary.Exceptions
{
    public class TitleAlreadyPresentInDBException: Exception
    {
        public TitleAlreadyPresentInDBException(string message) : base(message)
        {

        }
    }
}
