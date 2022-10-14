module TDD_Poker_fsharp_Test

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