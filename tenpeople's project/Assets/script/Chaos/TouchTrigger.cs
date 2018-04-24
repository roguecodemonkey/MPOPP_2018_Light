﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class TouchTrigger : MonoBehaviour
{
	private GameObject Communicate;
	[SerializeField]
	bool onlyTriggerOnce;

	[SerializeField]
	string[] TriggerTags;

	[SerializeField]
	float EnterTriggerDelay;
	[SerializeField]
	UnityEvent OnEnter;

	[SerializeField]
	float ExitTriggerDelay;
	[SerializeField]
	UnityEvent OnExit;
	public int levelchoose;
	bool triggered;
	float match0=1;
	float match1=0;
	float match2=1;
	float match3=1;
	float match4=0;
	float match5=0;
	float match6=0;
	float match7=0;
	float match8=0;

	bool IsTriggerable(Collision2D collision)
	{
		return IsTriggerable (collision.collider);
	}

	bool IsTriggerable(Collider2D collider)
	{
		if (triggered && onlyTriggerOnce)
			return false;

		if (TriggerTags.Length == 0)
			return true;
		
		foreach (var s in TriggerTags) {
			if (collider.tag == s) {
				return true;
			}
		}

		return false;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (!IsTriggerable (collider))
			return;
		triggered = true;

		StartCoroutine (Triggering(true));
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!IsTriggerable (collision))
			return;
		triggered = true;
		StartCoroutine (Triggering(true));
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (!IsTriggerable (collider))
			return;
		triggered = true;
		StartCoroutine (Triggering(false));
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (!IsTriggerable (collision))
			return;
		triggered = true;
		StartCoroutine (Triggering(false));
	}

	IEnumerator Triggering(bool enter)
	{
		if (enter) {
			if (EnterTriggerDelay > 0)
				yield return new WaitForSeconds (EnterTriggerDelay);
			if (OnEnter != null)
				OnEnter.Invoke ();
		} else {
			if (ExitTriggerDelay > 0)
				yield return new WaitForSeconds (ExitTriggerDelay);
			if (OnExit != null)
				OnExit.Invoke ();
		}
	}
	public void ChangeLevel(int i)
	{
		Application.LoadLevel (i);
	}

	public void ChangeLevel1(){
		ChangeLevel (1);
	}
	public void ChangeLevel2(){
		ChangeLevel (2);
	}
	public void ChangeLevel3(){
		ChangeLevel (3);
	}
	public void ChangeLevel4(){
		ChangeLevel (4);
	}
	public void ChangeLevel5(){
		ChangeLevel (5);
	}
	public void match(){
		if ((RecordBurger.Record >= match0)||(RecordBurger.Record2>=match2)||(RecordBurger.Record3>=match3)&&(RecordBurger.Record5>0)&&(RecordBurger.Record5>0)&&(RecordBurger.Record8>0)) {
			Application.LoadLevel (11);
		}
		else
			Application.LoadLevel(12);
	}
	public void LightTeach(){
		RecordBurger.Time=7;
	}
}