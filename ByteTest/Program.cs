using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByteTest {
	class Program {

		static void Main( string[ ] args ) {
			ByteCounter bc = new ByteCounter(10);
			bc.Run( );
			
		}
		
	}

}
