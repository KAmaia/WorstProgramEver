using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ByteTest {
	class ByteCounter {

		private int max;
		private bool running = false;
		private bool paused = false;
		private bool decrement = true;  //HACK: While loop will toggle this on first run, so set it true now.

		private ColorPair[] colorPairs;
		private int colorIndex;
		private ColorPair currentColorPair;

		/// <summary>
		/// CTOR.  Yeah, no comment.
		/// </summary>
		/// <param name="max"></param>
		public ByteCounter( int max ) {
			this.max = max;
			InitColorPairs( );
		}
		/// <summary>
		/// Initialize our color pairs.
		/// </summary>
		private void InitColorPairs( ) {
			colorPairs = new ColorPair[ ] {
				new ColorPair(ConsoleColor.DarkRed, ConsoleColor.DarkBlue),
				new ColorPair(ConsoleColor.DarkGreen, ConsoleColor.DarkRed),
				new ColorPair(ConsoleColor.DarkGray, ConsoleColor.DarkMagenta)
			};
			currentColorPair = colorPairs[0];

		}

		/// <summary>
		/// MainLoop
		/// </summary>
		internal void Run( ) {
			running = true;
			int i = 0;
			while ( running ) {
				//only loop, if it's not paused.
				if ( !paused ) {
					//If i is maxxed out, or zeroed out, toggle our decrement flag.
					//This is here to remove our for loops that caused lengthy runs before pausing.
					if ( i == max || i == 0 ) {
						ToggleDecrement( );
					}

					if ( decrement ) {
						i--;
					}

					else {
						i++;
					}

					WriteBoolArray( CreateBitArray( i ) );
				}

				if ( Console.KeyAvailable ) {
					HandleInput( Console.ReadKey( true ) );
				}
			}
		}

		/// <summary>
		/// Handles Input.
		/// </summary>
		/// <param name="key">Keystroke to handle</param>
		private void HandleInput( ConsoleKeyInfo key ) {
			switch ( key.Key ) {
				case ConsoleKey.Escape:
					PauseResume( );
					break;
				case ConsoleKey.Q:
					running = false;
					break;
				case ConsoleKey.Backspace:
					ToggleDecrement( );
					break;
				case ConsoleKey.UpArrow:
					CycleColors( true );
					break;
				case ConsoleKey.DownArrow:
					CycleColors( false );
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Toggles whether the loop is incremental or decremental.
		/// </summary>
		private void ToggleDecrement( ) {
			decrement = !decrement;
		}

		/// <summary>
		/// Creates a bit array from an int.
		/// </summary>
		/// <param name="incoming">The integer to create a bit array out of.</param>
		/// <returns></returns>
		private bool[ ] CreateBitArray( int incoming ) {
			BitArray b = new BitArray(new int[] { incoming } );
			bool[] booleanbits = new bool[b.Count];
			b.CopyTo( booleanbits, 0 );
			Array.Reverse( booleanbits );
			bool[] newBits = new bool[booleanbits.Count( )];
			booleanbits.CopyTo( newBits, 0 );
			Array.Reverse( newBits );

			bool[] finalBits = new bool[booleanbits.Count( )+newBits.Count( )];

			for ( int idx = 0; idx < booleanbits.Length; idx++ ) {
				finalBits[idx] = booleanbits[idx];
				finalBits[idx + booleanbits.Count( )] = newBits[idx];
			}
			return finalBits;
		}

		/// <summary>
		/// Writes a bool array to screen using console colors.
		/// </summary>
		/// <param name="incoming">The bit array to print.</param>
		private void WriteBoolArray( bool[ ] incoming ) {
			foreach ( var asf in incoming ) {
				if ( asf == true ) {
					Console.BackgroundColor = currentColorPair.OnesBackgroundColor;
					Console.ForegroundColor = currentColorPair.OnesForgroundColor;
					Console.Write( '1' );
				}
				else if ( asf == false ) {
					Console.BackgroundColor = currentColorPair.ZerosBackgroundColor;
					Console.ForegroundColor = currentColorPair.ZerosForegroundColor;
					Console.Write( '0' );
				}
			}
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine( "" );


		}

		private void CycleColors( bool forward ) {
			if ( forward ) {
				if ( colorIndex == colorPairs.Length - 1 ) {
					colorIndex = 0;
				}
				else {
					colorIndex++;
				}
			}
			else if ( !forward ) {
				if ( colorIndex == 0 ) {
					colorIndex = colorPairs.Length - 1;
				}
				else {
					colorIndex--;
				}
			}
			currentColorPair = colorPairs[colorIndex];

		}


		/// <summary>
		/// Toggles Paused Status.
		/// </summary>
		public void PauseResume( ) {
			paused = !paused;
		}
	}

}

