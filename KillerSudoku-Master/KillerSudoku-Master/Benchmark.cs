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
		public long startTime;
		public long stopTime;

		public string getTime()
		{
			long time = this.stopTime - this.startTime;
			long minutes = (time / 1000) / 60;
			long seconds = (time / 1000) % 60;
			long milli = time - (seconds * 1000) - (minutes * 60000);
			return "Time: " + minutes + ':' + seconds + ':' + milli;
		}
		public void start()
		{
			this.startTime= DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}
		public void end()
		{
			this.stopTime= DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}
	}
}
