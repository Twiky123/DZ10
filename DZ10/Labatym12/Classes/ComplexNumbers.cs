namespace Labatym12
{
    class ComplexNumber
    {

        readonly double realPart;
        readonly double imaginaryPart;



        public static ComplexNumber operator +(ComplexNumber firstComplexNumber, ComplexNumber secondComplecxNumber)
        {
            return new ComplexNumber(firstComplexNumber.realPart + secondComplecxNumber.realPart, firstComplexNumber.imaginaryPart + secondComplecxNumber.imaginaryPart);
        }
        public static ComplexNumber operator -(ComplexNumber firstComplexNumber, ComplexNumber secondComplecxNumber)
        {
            return new ComplexNumber(firstComplexNumber.realPart - secondComplecxNumber.realPart, firstComplexNumber.imaginaryPart - secondComplecxNumber.imaginaryPart);
        }
        public static ComplexNumber operator *(ComplexNumber firstComplexNumber, ComplexNumber secondComplecxNumber)
        {
            double newImaginaryPart = firstComplexNumber.realPart * secondComplecxNumber.imaginaryPart + firstComplexNumber.imaginaryPart * secondComplecxNumber.realPart;
            double newRealPart;

            if ((firstComplexNumber.imaginaryPart * secondComplecxNumber.imaginaryPart) > 0)
            {
                newRealPart = firstComplexNumber.realPart * secondComplecxNumber.realPart - (-firstComplexNumber.imaginaryPart * secondComplecxNumber.imaginaryPart);
            }
            else
            {
                newRealPart = firstComplexNumber.realPart * secondComplecxNumber.realPart + (-firstComplexNumber.imaginaryPart * secondComplecxNumber.imaginaryPart);
            }

            return new ComplexNumber(newRealPart, newImaginaryPart);
        }
        public static bool operator ==(ComplexNumber firstComplexNumber, ComplexNumber secondComplecxNumber)
        {
            return ((firstComplexNumber.realPart == secondComplecxNumber.realPart) && (firstComplexNumber.imaginaryPart == secondComplecxNumber.imaginaryPart));
        }
        public static bool operator !=(ComplexNumber firstComplexNumber, ComplexNumber secondComplecxNumber)
        {
            return ((firstComplexNumber.realPart != secondComplecxNumber.realPart) || (firstComplexNumber.imaginaryPart != secondComplecxNumber.imaginaryPart));
        }



        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber complexNumber)
            {
                if ((realPart == complexNumber.realPart) && (imaginaryPart == complexNumber.imaginaryPart))
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
        public override string ToString()
        {
            return (imaginaryPart > 0 ? $"({realPart} + {imaginaryPart}i)" : $"({realPart} - {-imaginaryPart}i)");
        }



        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.realPart = realPart;
            this.imaginaryPart = imaginaryPart;
        }
    }
}