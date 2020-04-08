using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public static class AgeMapping
    {
        public enum AgeCategories
        {
            Under_18,
            Cat_18_to_29,
            Cat_30_to_39,
            Cat_40_to_55,
            Cat_56_to_70,
            Over_70
        }

        public static AgeCategories GetAgeCategory(DateTime birth)
        {
            var years = DateTime.Now.Year - birth.Year;
            if (years < 18)
                return AgeCategories.Under_18;
            else if (years >= 18 && years < 30)
                return AgeCategories.Cat_18_to_29;
            else if (years >= 30 && years < 39)
                return AgeCategories.Cat_30_to_39;
            else if (years >= 40 && years < 55)
                return AgeCategories.Cat_40_to_55;
            else if (years >= 56 && years < 70)
                return AgeCategories.Cat_56_to_70;
            else
                return AgeCategories.Over_70;
        }
       
    }
}
