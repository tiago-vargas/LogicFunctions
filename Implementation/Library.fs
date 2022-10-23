namespace Implementation

type Formula =
    | AtomicFormula of char
    | Negation of Formula

module Functions =
    let NumberOfConnectives (formula: Formula) =
        match formula with
        | AtomicFormula p -> 0
        | Negation p -> 1
