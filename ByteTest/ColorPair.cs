using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteTest {
	class ColorPair {

		public ConsoleColor OnesBackgroundColor { get; }
		public ConsoleColor OnesForgroundColor { get; }
		public ConsoleColor ZerosBackgroundColor { get; }
		public ConsoleColor ZerosForegroundColor { get; }

		//All color pairs should be inverse for zeros and ones.
		public ColorPair( ConsoleColor onesBgColor, ConsoleColor onesFgColor ) {
			OnesBackgroundColor = onesBgColor;
			OnesForgroundColor = onesFgColor;
			ZerosBackgroundColor = onesFgColor;
			ZerosForegroundColor = onesBgColor;
		}

	}
}
