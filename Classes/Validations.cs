using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app3rework.Classes
{
    class Validations
    {
        public static bool IntegerValidation(string str)
        {
            string specialChar = @"|!#$%&/()=?»«@£§€{}.-;'<>_,";
            //str.ToCharArray();
            foreach (var item in specialChar)
            {
                if (str.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool NameValidation(string str)
        {
            string specialChar = @"|!#$%&/()=?»«@£§€{}.-;<>_,";
            //str.ToCharArray();
            foreach (var item in specialChar)
            {
                if (str.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
