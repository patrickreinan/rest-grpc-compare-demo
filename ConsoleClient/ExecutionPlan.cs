using System;
namespace ConsoleClient
{
	public class ExecutionPlan
	{
		private readonly List<ExecutionStep> steps;
		private readonly Dictionary<string, double> results;

		public ExecutionPlan()
		{
			steps = new List<ExecutionStep>();
			results = new Dictionary<string, double>();
		}

		public ExecutionPlan AddStep(string name, Action action)
        {
			var step = new ExecutionStep(name, action);
			steps.Add(step);
			return this;
        }

		public void Execute()
        {
			foreach (var step in steps)
            {
				var elapsed = step.Execute();
				results.Add(step.Name, elapsed ); 

			}
           
        }


		public Dictionary<string, double> Results
        {
			get { return results; }
        }

	}
}

