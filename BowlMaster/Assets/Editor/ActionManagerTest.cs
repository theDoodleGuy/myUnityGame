using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionManagerZTest
{
	List<int> pinFalls;
	ActionManager.MyAction endTurn = ActionManager.MyAction.EndTurn;
	ActionManager.MyAction tidy = ActionManager.MyAction.Tidy;
	ActionManager.MyAction endGame = ActionManager.MyAction.EndGame;
	ActionManager.MyAction reset = ActionManager.MyAction.Reset;

	[SetUp]
	public void Setup ()
	{
		pinFalls = new List<int> ();
	}

	//Test first bowl of frame
	[Test]
	public void T01_onStrikeReturnsEndTurn () {
	pinFalls.Add(10);
		Assert.AreEqual (endTurn, ActionManager.NextAction(pinFalls));
	}
	
	[Test]
	public void T02_firstBowlOfFrameReturnTidy () {
		pinFalls.Add(5);
		Assert.AreEqual (tidy, ActionManager.NextAction(pinFalls));
	}

	[Test]
	public void T03_onSpareReturnEndTurn () {
		int[] rolls = {2, 8};
		Assert.AreEqual (endTurn, ActionManager.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04_ResetIfStrikeOnLastFrame () {
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual (reset,  ActionManager.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T05_ResetRoll2IfSpareOnLastFrame () {
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
		Assert.AreEqual (reset, ActionManager.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06_TestGameEndsAfterRoll21 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2, 9};
		Assert.AreEqual (endGame, ActionManager.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07_TestGameEndsIfNoSpareOnRoll20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 1,1};
		Assert.AreEqual (endGame, ActionManager.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08_TestTidyIfStrikeOn19butNotOn20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 10, 1,};
		Assert.AreEqual (tidy, ActionManager.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T09_TestTidyIfStrikeOn19butGutteredOn20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 10, 0};
		Assert.AreEqual (tidy, ActionManager.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10_GutterThenSpareToEndTurnAndIncrement1 () {
		int [] rolls = {0,10, 0,10, 0,10, 0,10, 0,10, 0,10, 5,1};
		Assert.AreEqual (endTurn, ActionManager.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T11_3StrikesOnFinalFrame () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 10, 10, 10 };
		Assert.AreEqual (endGame, ActionManager.NextAction(rolls.ToList()));
	}
}