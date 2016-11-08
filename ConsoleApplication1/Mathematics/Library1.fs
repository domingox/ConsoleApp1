namespace Mathematics

type Number = 
    |Natural
    |Integer of int
    |Fraction of Number * Number
    |Real of decimal
    |Complex of Number * int
        with member this.Natural > 0



type Operation = Number * Number -> Number
    
type Operations =
    |Add of Operation
    |Subtract  of Operation
    |Divide  of Operation
    |Multiply  of Operation
    |Power of Operation
    |Root of Operation
