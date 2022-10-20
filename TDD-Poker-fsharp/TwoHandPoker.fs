module TDD_Poker_fsharp.TwoHandPoker

type Hands = { cards: Card.Card array }

let createHands suitranktuples =
    let cards = suitranktuples |> Seq.map (fun (s, r) -> Card.create s r) |> Seq.toArray
    { cards = cards }

let isCardsPair a b =
    Card.hasSameRank a b

let isPair hands =
    isCardsPair hands.cards[0] hands.cards[1]
    
let isCardsFlush a b =
    Card.hasSameSuit a b

let isFlush hands =
    isCardsFlush hands.cards[0] hands.cards[1]

let isCardsStraight (a: Card.Card)  (b: Card.Card) =
    let rankOrder = [| "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "J"; "Q"; "K"; "A" |]
    let index_a = Array.findIndex ((=) a.rank) rankOrder
    let index_b = Array.findIndex ((=) b.rank) rankOrder
    
    let minDistanceOnCircular a b lengthCircular =
        let l1 = (abs (a - b))
        min l1 (lengthCircular - l1)
    
    minDistanceOnCircular index_a index_b rankOrder.Length = 1
    
let isStraight hands =
    isCardsStraight hands.cards[0] hands.cards[1]
    
let isStraightFlush hands =
    (isStraight hands) && (isFlush hands)
    
let isHighCard hands =
    not (isPair hands) && not (isFlush hands) && not (isStraight hands)

