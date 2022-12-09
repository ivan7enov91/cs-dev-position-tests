using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringMultiplication
{
    public static class StringMultiplier
    {
        public static string Multiply(string value1, string value2)
        {
            bool resultHasNegativeSign = value1.Contains("-") ^ value2.Contains("-");

            value1 = value1.TrimStart('0').Replace("-", "");
            if(string.IsNullOrEmpty(value1)) 
                value1 = "0";
            value2 = value2.TrimStart('0').Replace("-", "");
            if (string.IsNullOrEmpty(value2))
                value2 = "0";

            var resultNumbers = new List<int>(value1.Length + value2.Length + 1);
            resultNumbers.AddRange(Enumerable.Repeat(0, resultNumbers.Capacity));

            for (var i = 0; i < value1.Length; i++)
            {
                for(var j = 0; j < value2.Length; j++)
                {
                    var amountToAdd = int.Parse(value1.Substring(value1.Length - i - 1, 1)) * int.Parse(value2.Substring(value2.Length - j - 1, 1));
                    var numbersToAdd = amountToAdd > 9 ? new[] { amountToAdd % 10, amountToAdd / 10 } : new[] { amountToAdd };

                    for(var k = 0; k < numbersToAdd.Length; k++)
                    {
                        var resultArrayIndex = i + j + k;

                        var needIncrementFollowingDigit = resultNumbers[resultArrayIndex] + numbersToAdd[k] > 9; 
                        resultNumbers[resultArrayIndex] = (resultNumbers[resultArrayIndex] + numbersToAdd[k]) % 10;
                        if(needIncrementFollowingDigit)
                        {
                            var x = resultArrayIndex + 1;
                            do
                            {
                                resultNumbers[x] = (resultNumbers[x] + 1) % 10;
                                needIncrementFollowingDigit = resultNumbers[x] == 0;
                                x++;
                            } while (needIncrementFollowingDigit);
                        }
                    }
                }
            }

            if (resultNumbers.All(x => x == 0)) 
                return "0";

            resultNumbers.Reverse();
            return (resultHasNegativeSign ? "-" : "") + 
                string.Join("", resultNumbers.Select(x => x.ToString())).TrimStart('0');
        }
    }
}
