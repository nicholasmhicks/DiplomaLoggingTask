using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Factorialiser.Classes
{
    public static class Calculator
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Calculates and returns the factorial of the input integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static int Factorial(int input)
        {

            _logger.Trace("calculating: " + input);

            try
            {
                if (input < 1) throw new NumberTooLowException(input);
                if (input > 30) throw new NumberTooHighException(input);

                int answer = 1;

                for (int i = input; i > 0; i--)
                {
                    answer *= i;
                }

                return answer;
            }
            catch (NumberTooHighException ex)
            {
                _logger.Trace("input too high: " + ex.Message);
                throw ex;
            }
            catch (NumberTooLowException ex)
            {
                _logger.Trace("input too low: " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Trace("unknown error message: " + ex.Message);
                throw ex;
            }

        }
    }
}
