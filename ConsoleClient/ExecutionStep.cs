using System;
using System.Diagnostics;

namespace ConsoleClient
{
	public  class ExecutionStep
	{

		private readonly Stopwatch stopwatch;
		public readonly Action action;

        public string Name { get; }

        public ExecutionStep(string name, Action action)
		{
			this.stopwatch = new Stopwatch();
            Name = name;
            this.action = action;
        }


        public double Execute()
        {

			stopwatch.Start();
			action();
			stopwatch.Stop();
			return stopwatch.Elapsed.TotalMilliseconds;

        }
	}
}

