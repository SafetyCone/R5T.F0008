using System;


namespace R5T.F0008
{
	public class CompilationUnitGenerator : ICompilationUnitGenerator
	{
		#region Infrastructure

	    public static CompilationUnitGenerator Instance { get; } = new();

	    private CompilationUnitGenerator()
	    {
	    }

	    #endregion
	}
}