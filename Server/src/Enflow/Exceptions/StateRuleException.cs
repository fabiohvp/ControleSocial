using System;

namespace Enflow.Exceptions
{
	public class StateRuleException : Exception
	{
		public StateRuleException(string message) : base(message) { }
	}
}