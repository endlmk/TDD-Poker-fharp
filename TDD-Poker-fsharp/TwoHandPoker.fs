module TDD_Poker_fsharp.TwoHandPoker

type Cards = { cards: Card.Card array }

let createCards suitRankTuples =
    let cards = suitRankTuples |> Seq.map (fun (s, r) -> Card.create s r) |> Seq.toArray
    { cards = cards }

let isCardsPair a b =
    Card.hasSameRank a b

let isPair cards =
    isCardsPair cards.cards[0] cards.cards[1]
    
let isCardsFlush a b =
    Card.hasSameSuit a b

let isFlush cards =
    isCardsFlush cards.cards[0] cards.cards[1]

let isCardsStraight (a: Card.Card)  (b: Card.Card) =
    let rankOrder = [| "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "J"; "Q"; "K"; "A" |]
    let index_a = Array.findIndex ((=) a.rank) rankOrder
    let index_b = Array.findIndex ((=) b.rank) rankOrder
    
    let minDistanceOnCircular a b lengthCircular =
        let l1 = (abs (a - b))
        min l1 (lengthCircular - l1)
    
    minDistanceOnCircular index_a index_b rankOrder.Length = 1
    
let isStraight cards =
    isCardsStraight cards.cards[0] cards.cards[1]
    
let isStraightFlush cards =
    (isStraight cards) && (isFlush cards)
    
let isHighCard cards =
    not (isPair cards) && not (isFlush cards) && not (isStraight cards)

type Result =
    Win | Lose | Draw
type Hands =
    HighCard | Flush | Straight | Pair | StraightFlush
    
let judgeHands cards =
    if isStraightFlush cards then StraightFlush
    elif isPair cards then Pair
    elif isStraight cards then Straight
    elif isFlush cards then Flush
    else HighCard
    
let judge myCards opponentCards =
    let myHands = judgeHands myCards
    let opponentHands = judgeHands opponentCards
    
    if myHands > opponentHands then Win
    elif myHands < opponentHands then Lose
    else Draw
