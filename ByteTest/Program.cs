using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByteTest {
	class Program {

		private static int max = 255; //default to 255

		static void Main( string[ ] args ) {
			if(args.Length > 0 ) {
				ParseApplyArgs( args );
			}
		
			ByteCounter bc = new ByteCounter(max);
			bc.Run( );
		}

		private static void ParseApplyArgs( string[ ] args ) {
			//for now, the only arg should be an int that's greater than 0 in args[0]
			int.TryParse( args[0], out max );

		}
	}

}
