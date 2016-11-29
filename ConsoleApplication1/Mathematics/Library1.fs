namespace DMC.Mathematics

module NumberTheory =

    type Number = 
        |Natural
        |Integer of int
        |Fraction of Number * Number
        |Real of decimal
        |Complex of Number * int

    type Operation = Number * Number -> Number
    
    type Operations =
        |Add of Operation
        |Subtract  of Operation
        |Divide  of Operation
        |Multiply  of Operation
        |Power of Operation
        |Root of Operation


module Statistics =

    type IEvent = 
        abstract member Probability: int -> int -> float

    type Outcome = Result of bool


    type IExperiment = 
        abstract member Description: string
        abstract member PossibleOutcomes: seq<Outcome>
        abstract member Result: Outcome

    let outcomeContinuation success failure 