module TDD_Poker_fsharp.TwoHandPoker

type Cards = { cards: Card.Card array }

let createCards suitRankTuples =
    let cards = suitRankTuples |> Seq.map (fun (s, r) -> Card.create s r) |> Seq.toArray
    { cards = cards }

let rankOrder = [| "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"; "10"; "J"; "Q"; "K"; "A" |]

let rankValue rank = Array.findIndex ((=) rank) rankOrder

let isCardsPair a b =
    Card.hasSameRank a b

let isPair cards =
    isCardsPair cards.cards[0] cards.cards[1]
    
let isCardsFlush a b =
    Card.hasSameSuit a b

let isFlush cards =
    isCardsFlush cards.cards[0] cards.cards[1]

let isCardsStraight (a: Card.Card)  (b: Card.Card) =
    let index_a = rankValue a.rank
    let index_b = rankValue b.rank
    
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

type HandsWithRank = { hands: Hands; rank: int array; }

let rankOfStraight cards =
    let rank1 = rankValue cards.cards[0].rank
    let rank2 = rankValue cards.cards[1].rank
    let sorted = Array.sort [| rank1; rank2;|]
    
    if sorted[0] = 0 && sorted[1] = 12 then [| 0 |]
    else [| sorted[1] |]

let rankOfPair cards =
    let rank = rankValue cards.cards[0].rank
    [| rank |]

let rankOfFlushOrHighCard cards =
    let rank1 = rankValue cards.cards[0].rank
    let rank2 = rankValue cards.cards[1].rank
    Array.sortDescending [| rank1; rank2;|]

let judgeHands cards =
    if isStraightFlush cards then { hands = StraightFlush; rank = rankOfStraight cards; }
    elif isPair cards then { hands = Pair; rank = rankOfPair cards; }
    elif isStraight cards then { hands = Straight; rank = rankOfStraight cards; }
    elif isFlush cards then { hands = Flush; rank = rankOfFlushOrHighCard cards; }
    else { hands = HighCard; rank = rankOfFlushOrHighCard cards; }

let judge myCards opponentCards =
    let myHands = judgeHands myCards
    let opponentHands = judgeHands opponentCards
    
    if myHands > opponentHands then Win
    elif myHands < opponentHands then Lose
    else Draw

