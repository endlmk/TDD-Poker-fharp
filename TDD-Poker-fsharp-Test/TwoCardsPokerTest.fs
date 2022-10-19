module TDD_Poker_fsharp_Test.TwoCardsPokerTest

open NUnit.Framework
open TDD_Poker_fsharp

[<Test>]
let judgeHandsTest() =
    Assert.AreEqual(true, TwoHandPoker.isPair (Card.create "♥" "3") (Card.create "♠" "3"))
    Assert.AreEqual(false, TwoHandPoker.isPair (Card.create "♦" "4") (Card.create "♠" "3"))
    
    Assert.AreEqual(true, TwoHandPoker.isFlush (Card.create "♦" "4") (Card.create "♦" "3"))
    Assert.AreEqual(false, TwoHandPoker.isFlush (Card.create "♣" "4") (Card.create "♦" "4"))
    
    Assert.AreEqual(true, TwoHandPoker.isHighCard (Card.create "♥" "4") (Card.create "♦" "3"))
    Assert.AreEqual(false, TwoHandPoker.isHighCard (Card.create "♥" "4") (Card.create "♥" "3"))
    Assert.AreEqual(false, TwoHandPoker.isHighCard (Card.create "♥" "3") (Card.create "♦" "3"))
    
    Assert.AreEqual(true, TwoHandPoker.isStraight (Card.create "♥" "4") (Card.create "♦" "3"))
    Assert.AreEqual(false, TwoHandPoker.isStraight (Card.create "♥" "5") (Card.create "♦" "3"))
    Assert.AreEqual(true, TwoHandPoker.isStraight (Card.create "♥" "K") (Card.create "♦" "A"))
    Assert.AreEqual(true, TwoHandPoker.isStraight (Card.create "♥" "2") (Card.create "♦" "A"))
    Assert.AreEqual(true, TwoHandPoker.isStraight (Card.create "♥" "A") (Card.create "♦" "2"))
    Assert.AreEqual(false, TwoHandPoker.isStraight (Card.create "♥" "A") (Card.create "♦" "3"))
    
    Assert.AreEqual(true, TwoHandPoker.isStraightFlush (Card.create "♦" "A") (Card.create "♦" "2"))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (Card.create "♠" "A") (Card.create "♦" "2"))
    Assert.AreEqual(false, TwoHandPoker.isStraightFlush (Card.create "♠" "A") (Card.create "♠" "Q"))
    