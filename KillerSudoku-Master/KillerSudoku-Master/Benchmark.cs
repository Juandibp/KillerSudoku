using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku_Master
{
	class Benchmark
	{
		public TimeSpan startTime;
		public TimeSpan stopTime;

		public string getTime()
		{
			TimeSpan time = (stopTime.Subtract(startTime));
			double minutes = time.TotalMinutes;
			double seconds = time.TotalSeconds;
			double milli = time.TotalMilliseconds;
			return "\nTime: " + Math.Round(minutes,5) + ':' + Math.Round(seconds,5)+":"+Math.Round(milli,5)+'\n';
		
		}
		public void start()
		{
			this.startTime = DateTime.Now.TimeOfDay;
		}
		public void end()
		{
			this.stopTime= DateTime.Now.TimeOfDay;
		}
	}
}
