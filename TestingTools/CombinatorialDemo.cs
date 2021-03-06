using System;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TestingTools
{
	[TestFixture]
	public class CombinatorialDemo
	{

		[Test]
		public void CombinatorialConsole(
			[Values("a", "b", "c")] string a,
			[Values("+", "-")] string b,
			[Values("x", "y")] string c)
		{
			Console.WriteLine("{0} {1} {2}", a, b, c);
		}

		[Test, Pairwise]
		public void PairwiseConsole(
			[Values("a", "b", "c")] string a,
			[Values("+", "-")] string b,
			[Values("x", "y")] string c)
		{
			Console.WriteLine("{0} {1} {2}", a, b, c);
		}






		[Test, Pairwise]
		[UseReporter(typeof(DiffReporter))]
		public void PairwiseApprovals(
			[Values("a", "b", "c")] string a,
			[Values("+", "-")] string b,
			[Values("x", "y")] string c)
		{
			using (ApprovalResults.ForScenario(a, b, c))
			{
				var v = string.Format("{0} {1} {2}", a, b, c);
				Approvals.Verify(v);
			}
		}
		[Test]
		[UseReporter(typeof(DiffReporter))]
		public void PairwiseApprovalsAllInOne()
		{
			CombinationApprovals.VerifyAllCombinations(
				(a, b, c) => string.Format("{0} {1} {2}", a, b, c), 
				new[] {"a", "b", "c"},
				new[] {"+", "-"},
				new[] {"x", "y"});
		}
	}
}