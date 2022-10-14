module TDD_Poker_fsharp_Test

open NUnit.Framework
open TDD_Poker_fsharp

[<SetUp>]
let Setup () =
    ()

[<Test>]
let FirstTest () =
    Assert.That(Say.hello "someone", Is.EqualTo("Hello someone"))