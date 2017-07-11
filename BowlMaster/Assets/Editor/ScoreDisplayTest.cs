using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () {
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T02Bowl12 () {
		int[] rolls = {1,2};
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T03Bowl123 () {
		int[] rolls = {1,2, 3};
		string rollsString = "123";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T04Bowl1234 () {
		int[] rolls = {1,2, 3,4};
		string rollsString = "1234";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T05BowlspareOnFirst () {
		int[] rolls = {2,8};
		string rollsString = "2/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T06Bowlspare2 () {
		int[] rolls = {1,2, 3,4, 2,8};
		string rollsString = "12342/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T07Bowlspare3 () {
		int[] rolls = {1,2, 3,4, 2,8, 5,5, 2,0, 7};
		string rollsString = "12342/5/207";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T08BowlstrikeOnFirst () {
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T09Bowlstrike1 () {
		int[] rolls = {1,4, 10, 3,5,};
		string rollsString = "14X 35";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T10Bowlstrike2 () {
		int[] rolls = {1,4, 10, 10, 3,5, 10};
		string rollsString = "14X X 35X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T11Bowlzero () {
		int[] rolls = {0};
		string rollsString = "0";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T12BowlallGuttered () {
		int[] rolls = {0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0};
		string rollsString = "00000000000000000000";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T13BowlallSpare () {
		int[] rolls = {1,9, 5,5, 6,4, 7,3, 2,8, 4,6, 3,7, 9,1, 8,2, 3,7,5};
		string rollsString = "1/5/6/7/2/4/3/9/8/3/5";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T14BowlallStrike () {
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}