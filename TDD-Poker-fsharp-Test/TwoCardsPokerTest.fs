module TDD_Poker_fsharp_Test.TwoCardsPokerTest

open NUnit.Framework
open TDD_Poker_fsharp

[<Test>]
let judgeHandsTest() =
    Assert.AreEqual(true, TwoHandPoker.isPair (TwoHandPoker.createCards [("♥", "3"); ("♠", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isPair (TwoHandPoker.createCards [("♦", "4"); ("♠", "3")]))
    
    Assert.AreEqual(true, TwoHandPoker.isFlush (TwoHandPoker.createCards [("♦", "4"); ("♦", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isFlush (TwoHandPoker.createCards [("♣", "4"); ("♦", "4")]))
    
    Assert.AreEqual(true, TwoHandPoker.isHighCard (TwoHandPoker.createCards [("♥", "3"); ("♦", "5")]))
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createCards [("♥", "4"); ("♥", "3")])) // StraightFlush
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createCards [("♥", "3"); ("♦", "3")])) // Pair
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createCards [("♥", "4"); ("♦", "3")])) // Straight
    Assert.AreEqual(false, TwoHandPoker.isHighCard (TwoHandPoker.createCards [("♥", "4"); ("♥", "6")])) // Flush
    
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "4"); ("♦", "3")]))
    Assert.AreEqual(false, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "5"); ("♦", "3")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "K"); ("♦", "A")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "2"); ("♦", "A")]))
    Assert.AreEqual(true, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraight (TwoHandPoker.createCards [("♥", "A"); ("♦", "3")]))
    
    Assert.AreEqual(true, TwoHandPoker.isStraightFlush (TwoHandPoker.createCards [("♦", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (TwoHandPoker.createCards [("♠", "A"); ("♦", "2")]))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (TwoHandPoker.createCards [("♠", "A"); ("♠", "Q")]))

[<Test>]
let judgeResultWhenHandsDiffer() =
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♦", "A"); ("♦", "2")]) // StraightFlush
                        (TwoHandPoker.createCards [("♦", "A"); ("♥", "A")]) // Pair
        Assert.AreEqual(TwoHandPoker.Win, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♦", "A"); ("♥", "A")]) // Pair
                        (TwoHandPoker.createCards [("♦", "2"); ("♥", "A")]) // Straight
        Assert.AreEqual(TwoHandPoker.Win, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♦", "2"); ("♥", "A")]) // Straight
                        (TwoHandPoker.createCards [("♥", "4"); ("♥", "6")]) // Flush
        Assert.AreEqual(TwoHandPoker.Win, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♥", "4"); ("♥", "6")]) // Flush
                        (TwoHandPoker.createCards [("♥", "4"); ("♠", "6")]) // HighCard
        Assert.AreEqual(TwoHandPoker.Win, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♥", "4"); ("♠", "6")]) // HighCard
                        (TwoHandPoker.createCards [("♥", "4"); ("♥", "6")]) // Flush
        Assert.AreEqual(TwoHandPoker.Lose, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♥", "4"); ("♥", "6")]) // Flush
                        (TwoHandPoker.createCards [("♦", "2"); ("♥", "A")]) // Straight
        Assert.AreEqual(TwoHandPoker.Lose, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♦", "2"); ("♥", "A")]) // Straight
                        (TwoHandPoker.createCards [("♦", "A"); ("♥", "A")]) // Pair
        Assert.AreEqual(TwoHandPoker.Lose, result)
        let result = TwoHandPoker.judge
                        (TwoHandPoker.createCards [("♦", "A"); ("♥", "A")]) // Pair
                        (TwoHandPoker.createCards [("♦", "A"); ("♦", "2")]) // StraightFlush
        Assert.AreEqual(TwoHandPoker.Lose, result)
    