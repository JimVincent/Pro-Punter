using UnityEngine;
using System.Collections;

public class C_Horse : MonoBehaviour 
{
	public string mName;
	public float mSpeed;
	public float mValue;
	public bool isPlayer = false;

	// Use this for initialization
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// randomly generated member var values
	public void SetData()
	{
		mName = S_TXT_Data.inst.NewName();

	}
	
}
