using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTest
{
    public class DecodeArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chardata"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Numarray_Ways(char[] chardata, int k)
        {
            if (k == 0 || k == 1)
                return 1;

            int count = 0;

            if (chardata[k - 1] > '0')
                count = Numarray_Ways(chardata, k - 1);


            if(chardata[k - 2] == '1' || chardata[k - 2] =='2' || chardata[k - 2] < '7')
                count += Numarray_Ways(chardata, k - 2);

            return count;
          
        }

    }
}
