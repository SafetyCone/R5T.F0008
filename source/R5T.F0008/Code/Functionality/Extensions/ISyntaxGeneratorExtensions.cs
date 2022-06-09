using System;

using R5T.Magyar.Extensions;

using R5T.F0008;


namespace System
{
    public static class ISyntaxGeneratorExtensions
    {
        public static T As<T>(this ISyntaxGenerator syntaxGenerator)
            where T : class
        {
            return syntaxGenerator as T;
        }
    }
}
