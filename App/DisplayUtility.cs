using System;

namespace App
{

    public static class DisplayUtility
    {
        public enum InformationType
        {
            OnSuccess,
            OnError,
            OnDefault
        }

        public static void DisplayText(string message, InformationType type = InformationType.OnDefault)
        {
            SetColor(type);
            Console.WriteLine(message);
        }

        private static void SetColor(InformationType type)
        {
            switch (type)
            {
                case InformationType.OnDefault:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case InformationType.OnError:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case InformationType.OnSuccess:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }
    }
}