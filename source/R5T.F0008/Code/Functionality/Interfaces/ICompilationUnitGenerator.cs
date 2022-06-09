using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar.Extensions;

using R5T.T0132;
using R5T.T0134;


namespace R5T.F0008
{
	[FunctionalityMarker]
	public interface ICompilationUnitGenerator : IFunctionalityMarker
	{
        public CompilationUnitSyntax CreateNamespace(
            string namespaceName,
            out ISyntaxNodeAnnotation<NamespaceDeclarationSyntax> namespaceAnnotation)
        {
            var compilationUnit = Instances.SyntaxGenerator.CompilationUnit();

            var usingSystem = Instances.SyntaxGenerator.UsingSystemNamespace();

            compilationUnit = Instances.SyntaxNodeOperator.AddUsingDirective(
                compilationUnit,
                usingSystem,
                out _);

            var @namespace = Instances.SyntaxGenerator.As<F0007.ISyntaxGenerator>().Namespace(namespaceName);

            compilationUnit = Instances.SyntaxNodeOperator.AddNamespace(
                compilationUnit,
                @namespace,
                out namespaceAnnotation);

            var namespaceSpacing = Instances.SpacingGenerator.TwoBlankLines();

            compilationUnit = namespaceAnnotation.Modify(
                compilationUnit,
                @namespace => @namespace.WithLeadingTrivia(namespaceSpacing));

            return compilationUnit;
        }

        public CompilationUnitSyntax CreateClass(
            string namespaceName,
            string className,
            out ISyntaxNodeAnnotation<ClassDeclarationSyntax> classAnnotation)
        {
            var compilationUnit = this.CreateNamespace(
                namespaceName,
                out var namespaceAnnotation);

            var @class = Instances.SyntaxGenerator.As<F0007.ISyntaxGenerator>().Class(className);

            compilationUnit = namespaceAnnotation.AddMember(
                compilationUnit,
                @class,
                out classAnnotation);

            // Indentation.
            compilationUnit = classAnnotation.Modify(
                compilationUnit,
                @class => @class
                    .PrependNewLine()
                    .Indent(
                        Instances.IndentationGenerator.ForInterface()));

            return compilationUnit;
        }

        public CompilationUnitSyntax CreatePublicClass(
            string namespaceName,
            string className,
            out ISyntaxNodeAnnotation<ClassDeclarationSyntax> classAnnotation)
        {
            var compilationUnit = this.CreateClass(
                namespaceName,
                className,
                out classAnnotation);

            compilationUnit = classAnnotation.Modify(
                compilationUnit,
                @class => @class.MakePublic());

            return compilationUnit;
        }

        public CompilationUnitSyntax CreatePublicStaticClass(
            string namespaceName,
            string className,
            out ISyntaxNodeAnnotation<ClassDeclarationSyntax> classAnnotation)
        {
            var compilationUnit = this.CreatePublicClass(
                namespaceName,
                className,
                out classAnnotation);

            compilationUnit = classAnnotation.Modify(
                compilationUnit,
                @class => @class.MakeStatic());

            return compilationUnit;
        }
    }
}