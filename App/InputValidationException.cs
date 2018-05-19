using System;

namespace App
{
    public class InputValidationException : Exception
    {
        public InputValidationException(string message) : base(message)
        {
        }
    }
}