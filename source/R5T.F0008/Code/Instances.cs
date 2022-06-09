using System;

using R5T.F0005;
using R5T.F0007;
using R5T.F0013;
using R5T.Z0003;


namespace R5T.F0008
{
    public static class Instances
    {
        public static IIndentationGenerator IndentationGenerator { get; } = F0007.IndentationGenerator.Instance;
        public static ISpacingGenerator SpacingGenerator { get; } = F0007.SpacingGenerator.Instance;
        public static ISyntaxGenerator SyntaxGenerator { get; } = F0008.SyntaxGenerator.Instance;
        public static ISyntaxNodeOperator SyntaxNodeOperator { get; } = F0013.SyntaxNodeOperator.Instance;
        public static ISyntaxParser SyntaxParser { get; } = F0005.SyntaxParser.Instance;
        public static ISyntaxTextValues SyntaxTextValues { get; } = Z0003.SyntaxTextValues.Instance;
    }
}
