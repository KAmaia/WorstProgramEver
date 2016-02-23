using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteTest {
	class ByteCounter {

		private int max;
		private bool running = false;
		private bool paused = false;

		public ByteCounter( int max ) {
			this.max = max;
		}

		internal void Run( ) {
			running = true;
			while ( running ) {
				if ( !paused ) {
					for ( int i = 0; i < max; i++ ) {
						WriteBoolArray( CreateBitArray( i ) );
					}
					for ( int i = max; i > 0; i-- ) {
						WriteBoolArray( CreateBitArray( i ) );
					}
				}
				if ( Console.KeyAvailable ) {
					HandleInput( Console.ReadKey( ) );
				}
			}
		}

		private void HandleInput( ConsoleKeyInfo key ) {
			switch ( key.Key ) {
				case ConsoleKey.Escape:
					PauseResume( );
					break;
				case ConsoleKey.Q:
					running = false;
					break;
				default:
					break;
			}
		}

		private bool[ ] CreateBitArray( int incoming ) {
			BitArray b = new BitArray(new int[] { incoming } );
			bool[] booleanbits = new bool[b.Count];
			b.CopyTo( booleanbits, 0 );
			Array.Reverse( booleanbits );
			bool[] newBits = new bool[booleanbits.Count()];
			booleanbits.CopyTo( newBits, 0 );
			Array.Reverse( newBits );

			bool[] finalBits = new bool[booleanbits.Count()+newBits.Count()];

			for ( int idx = 0; idx < booleanbits.Length; idx++ ) {
				finalBits[idx] = booleanbits[idx];
				finalBits[idx + booleanbits.Count( )] = newBits[idx];
			}
			return finalBits;
		}

		private void WriteBoolArray( bool[ ] incoming ) {

			foreach ( var asf in incoming ) {
				if ( asf == true ) {
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write( '1' );
				}
				else if ( asf == false ) {
					Console.BackgroundColor = ConsoleColor.Blue;
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write( '0' );
				}
			}
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine( "" );


		}
		public void PauseResume( ) {
			paused = !paused;
		}
	}

}

