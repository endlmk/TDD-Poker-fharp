module TDD_Poker_fsharp.TwoHandPoker

let isPair a b =
    Card.hasSameRank a b
    
let isFlush a b =
    Card.hasSameSuit a b
    
let isHighCard a b =
    not (isPair a b) && not (isFlush a b)


let isStraight (a: Card.Card)  (b: Card.Card) =
    let rankOrder = [| "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "J"; "Q"; "K"; "A" |]
    let index_a = Array.findIndex ((=) a.rank) rankOrder
    let index_b = Array.findIndex ((=) b.rank) rankOrder
    
    let minDistanceOnCircular a b lengthCircular =
        let l1 = (abs (a - b))
        min l1 (lengthCircular - l1)
    
    minDistanceOnCircular index_a index_b rankOrder.Length = 1
    
let isStraightFlush a b =
    (isStraight a b) && (isFlush a b)