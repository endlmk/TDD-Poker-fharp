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
    
    