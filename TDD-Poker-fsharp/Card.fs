namespace TDD_Poker_fsharp

open System

module Card =
    type Card = { suit: string; rank: string; }
    let create suit rank =
        { suit = suit; rank = rank; }
    
    let getNotation card =
        card.rank + card.suit
    
    let hasSameSuit l r =
        l.suit = r.suit
        
    let hasSameRank l r =
        l.rank = r.rank