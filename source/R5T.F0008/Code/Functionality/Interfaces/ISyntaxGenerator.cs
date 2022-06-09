using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.F0008
{
    [FunctionalityMarker]
    public interface ISyntaxGenerator : IFunctionalityMarker,
        F0023.ISyntaxGenerator
    {
        public UsingDirectiveSyntax UsingSystemNamespace()
        {
            var output = Instances.SyntaxParser.ParseUsingDirective(
                Instances.SyntaxTextValues.UsingSystemNamespace);

            return output;
        }
    }
}
