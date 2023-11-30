namespace Labatym12
{
    class RationalNumber
    {

        readonly int numerator;
        readonly int denominator;



        public static RationalNumber MakeRationalNumber(int numerator, int denominator)
        {
            if (denominator > 0)
            {
                return new RationalNumber(numerator, denominator);
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            if (denominator == 1)
            {
                return $"{numerator}";
            }
            else
            {
                return $"{numerator}/{denominator}";
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalNumber rationalNumber)
            {
                int newDenominator = FindingDenominator(denominator, rationalNumber.denominator);
                int newFirstNumerator = numerator * (newDenominator / denominator);
                int newSecondNumerator = rationalNumber.numerator * (newDenominator / rationalNumber.denominator);

                if (newFirstNumerator == newSecondNumerator)
                {
                    return true;
                }
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private static int FindingDenominator(int firstDenominator, int secondDenominator)
        {
            int firstNumber = firstDenominator;
            int secondNumber = secondDenominator;

            while ((firstNumber != 0) && (secondNumber != 0))
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber %= secondNumber;
                }
                else
                {
                    secondNumber %= firstNumber;
                }
            }

            return (firstDenominator * secondDenominator) / (firstNumber + secondNumber);
        }



        public static RationalNumber operator +(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newNumerator = (firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator)) + (secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator));

            return new RationalNumber(newNumerator, newDenominator);
        }
        public static RationalNumber operator -(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newNumerator = (firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator)) - (secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator));

            return new RationalNumber(newNumerator, newDenominator);
        }
        public static RationalNumber operator *(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            return new RationalNumber(firstRationalNumber.numerator * secondRationalNumber.numerator, firstRationalNumber.denominator * secondRationalNumber.denominator);
        }

        public static RationalNumber operator /(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            return new RationalNumber(firstRationalNumber.numerator * secondRationalNumber.denominator, firstRationalNumber.denominator * secondRationalNumber.numerator);
        }
        public static int operator %(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            RationalNumber rationalNumber = firstRationalNumber / secondRationalNumber;

            return (rationalNumber.numerator % rationalNumber.denominator);
        }
        public static bool operator ==(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator == newSecondNumerator;
        }
        public static bool operator !=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator != newSecondNumerator;
        }
        public static bool operator >(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator > newSecondNumerator;
        }
        public static bool operator <(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator < newSecondNumerator;
        }
        public static bool operator >=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator >= newSecondNumerator;
        }
        public static bool operator <=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator <= newSecondNumerator;
        }
        public static RationalNumber operator ++(RationalNumber rationalNumber)
        {
            return new RationalNumber(rationalNumber.numerator + rationalNumber.denominator, rationalNumber.denominator);
        }
        public static RationalNumber operator --(RationalNumber rationalNumber)
        {
            return new RationalNumber(rationalNumber.numerator - rationalNumber.denominator, rationalNumber.denominator);
        }
        public static explicit operator float(RationalNumber rationalNumber)
        {
            return (float)rationalNumber.numerator / rationalNumber.denominator;
        }
        public static explicit operator int(RationalNumber rationalNumber)
        {
            return rationalNumber.numerator / rationalNumber.denominator;
        }



        private RationalNumber(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
    }
}