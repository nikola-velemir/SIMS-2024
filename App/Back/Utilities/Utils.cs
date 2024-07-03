using System;

namespace App.Back.Utilities
{
    public static class Utils
    {
        public static int GenerateId()
        {
            return new Random().Next(1, 100000);
        }
    }
}
