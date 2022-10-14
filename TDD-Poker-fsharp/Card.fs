namespace TDD_Poker_fsharp

open System

module Card =
    type Card = { suit: String; rank: String; }
    let create suit rank =
        { suit = suit; rank = rank; }
    
    let getNotation card =
        card.rank + card.suit