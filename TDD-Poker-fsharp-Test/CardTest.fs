module TDD_Poker_fsharp_Test.CardTest

open NUnit.Framework
open TDD_Poker_fsharp

[<SetUp>]
let Setup () =
    ()

[<Test>]
let CardNotationTest () =
    let threeOfSpades = Card.create "♠" "3"
    Assert.AreEqual("3♠", Card.getNotation threeOfSpades)
    let jackOfHearts = Card.create "♥" "J"
    Assert.AreEqual("J♥", Card.getNotation jackOfHearts)

[<Test>]
let CardEqualityTest() =
    let threeOfSpades = Card.create "♠" "3"
    let aceOfSpades = Card.create "♠" "A"
    let aceOfHearts = Card.create "♥" "A"
    Assert.AreEqual(true, Card.hasSameSuit threeOfSpades aceOfSpades)
    Assert.AreEqual(false, Card.hasSameSuit threeOfSpades aceOfHearts)
    Assert.AreEqual(false, Card.hasSameRank threeOfSpades aceOfSpades)
    Assert.AreEqual(true, Card.hasSameRank aceOfSpades aceOfHearts)