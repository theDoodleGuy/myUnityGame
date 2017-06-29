using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionManagerZTest
{
	ActionManager actionManager;
	ActionManager.myAction endTurn = ActionManager.myAction.EndTurn;
	ActionManager.myAction tidy = ActionManager.myAction.Tidy;
	ActionManager.myAction endGame = ActionManager.myAction.EndGame;
	ActionManager.myAction reset = ActionManager.myAction.Reset;

	[SetUp]
	public void Setup ()
	{
		actionManager = new ActionManager ();
	}

	//Test first bowl of frame
	[Test]
	public void T01_onStrikeReturnsEndTurn () {
		Assert.AreEqual (endTurn, actionManager.Bowl(10));
	}

	[Test]
	public void T02_firstBowlOfFrameReturnTidy () {
		Assert.AreEqual (tidy, actionManager.Bowl(5));
	}

	[Test]
	public void T03_onSpareReturnEndTurn () {
		actionManager.Bowl(8);
		Assert.AreEqual (endTurn, actionManager.Bowl(2));
	}

	[Test]
	public void T04_ResetIfStrikeOnLastFrame () {
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		Assert.AreEqual (reset, actionManager.Bowl(10));
	}

	[Test]
	public void T05_ResetRoll2IfSpareOnLastFrame () {
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		actionManager.Bowl(1);
		Assert.AreEqual (reset, actionManager.Bowl(9));
	}

	[Test]
	public void T06_TestGameEndsAfterRoll21 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		Assert.AreEqual (endGame, actionManager.Bowl(9));
	}

	[Test]
	public void T07_TestGameEndsIfNoSpareOnRoll20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 1};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		Assert.AreEqual (endGame, actionManager.Bowl(1));
	}

	[Test]
	public void T08_TestTidyIfStrikeOn19butNotOn20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 10};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		Assert.AreEqual (tidy, actionManager.Bowl(1));
	}

	[Test]
	public void T09_TestTidyIfStrikeOn19butGutteredOn20 () {
		int [] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 10};
		foreach(int roll in rolls) {
			actionManager.Bowl(roll);
		}
		Assert.AreEqual (tidy, actionManager.Bowl(0));
	}
}