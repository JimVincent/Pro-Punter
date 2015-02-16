using UnityEngine;
using System.Collections;

/*
 * is: A class that looks after the players funds
 * has: Getter Functions and deposit and withdrawal functions
 * Use: For spending and receiving money as well as stats on money spent
 * 
*/

public class S_BankAccount : MonoBehaviour 
{
	S_BankAccount inst;

	private int mFunds = 0;
	private int mTotalSpent = 0;
	private int mTotalAquired = 0;

	// Use this for initialization
	void Awake () 
	{
		inst = this;	
	}

	// Getters

	public int Balance()
	{
		return mFunds;
	}

	public int TotalWithdrawals()
	{
		return mTotalSpent;
	}

	public int TotalDeposits()
	{
		return mTotalAquired;
	}

	// Adds to funds as well as the total money aquired
	public void Deposit(int amount)
	{
		mFunds += amount;
		mTotalAquired += amount;
	}

	// removes funds and adds to total spent
	public void Withdrawal(int amount)
	{
		mFunds -= amount;
		mTotalSpent += amount;
	}
}