namespace IntelliDiff.Specs
{
    using System;

    internal class EnumHelper
    {
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}