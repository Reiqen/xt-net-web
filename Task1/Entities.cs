using System;

namespace Task1
{
    /*
        This class provides entities.
        Please read comments above classes and enums for more information.
    */

    class Entities
    {
        // Contains enum for font adjustment
        [Flags]
        public enum Font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }
    }
}