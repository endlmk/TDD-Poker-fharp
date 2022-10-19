module TDD_Poker_fsharp.TwoHandPoker

let isPair a b =
    Card.hasSameRank a b
    
let isFlush a b =
    Card.hasSameSuit a b
    
let isHighCard a b =
    not (isPair a b) && not (isFlush a b)