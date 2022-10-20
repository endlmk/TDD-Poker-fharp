module TDD_Poker_fsharp_Test.TwoCardsPokerTest

open NUnit.Framework
open TDD_Poker_fsharp

[<Test>]
let judgeHandsTest() =
    Assert.AreEqual(true, TwoHandPoker.isPair (TwoHandPoker.createHands [("♥", "3"); ("♠", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isPair (TwoHandPoker.createHands [("♦", "4"); ("♠", "3")]))
    
    Assert.AreEqual(true, TwoHandPoker.isFlush (TwoHandPoker.createHands [("♦", "4"); ("♦", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isFlush (TwoHandPoker.createHands [("♣", "4"); ("♦", "4")]))
    
    Assert.AreEqual(true, TwoHandPoker.isHighCard (TwoHandPoker.createHands [("♥", "3"); ("♦", "5")]))
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createHands [("♥", "4"); ("♥", "3")])) // StraightFlush
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createHands [("♥", "3"); ("♦", "3")])) // Pair
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createHands [("♥", "4"); ("♦", "3")])) // Straight
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createHands [("♥", "4"); ("♥", "6")])) // Flush
    
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "4"); ("♦", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "5"); ("♦", "3")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "K"); ("♦", "A")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "2"); ("♦", "A")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraight (TwoHandPoker.createHands [("♥", "A"); ("♦", "3")]))
    
    Assert.AreEqual(true, TwoHandPoker.isStraightFlush (TwoHandPoker.createHands [("♦", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (TwoHandPoker.createHands [("♠", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (TwoHandPoker.createHands [("♠", "A"); ("♠", "Q")]))

//[<Test>]
//let judgeHandsRank() =
//    Assert.AreEqual(true, TwoHandPoker.isHandsRankHigher )
    