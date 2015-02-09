using UnityEngine;
using System.Collections;

/*
 * Is: A class for storing a single bet's data
 * Has: No functions
 * Use:	For placing bets as well as checking for winning bets.
 * 
*/

public class C_Bet : MonoBehaviour 
{
	public BetType mBetType;
	public int mRaceNumber;
	public int mAmount;
	public int[] mSelections;
	public int mTimeStamp;
}
