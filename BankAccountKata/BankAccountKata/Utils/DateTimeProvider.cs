using System;

namespace BankAccountKata.Utils
{
    public abstract class DateTimeProvider
    {
        private static DateTimeProvider _current;

        static DateTimeProvider()
        {
            // always set a default
            _current = new DefaultDateTimeProvider();
        }

        public abstract DateTime Today { get; }
        
        public static void SetACustomDateTimeProvider(DateTimeProvider customDateTimeProvider)
        {
            _current = customDateTimeProvider;
        }

        public static DateTimeProvider Current { get { return _current; } }

        public static void BackToDefault()
        {
            _current = new DefaultDateTimeProvider();
        }
    }
}