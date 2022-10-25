namespace Implementation


type Formula =
    | AtomicFormula of char
    | Negation of Formula
    | Conjunction of Formula * Formula
    | Disjunction of Formula * Formula
    | Implication of Formula * Formula

    static member (~-) (p: Formula) =
        Negation p

    static member (.&) (p: Formula, q: Formula) =
        Conjunction (p, q)

    static member (.|) (p: Formula, q: Formula) =
        Disjunction (p, q)

    static member (-->) (p: Formula, q: Formula) =
        Implication (p, q)


module Functions =
    let rec NumberOfConnectives (formula: Formula) =
        match formula with
        | AtomicFormula p -> 0
        | Negation p -> 1 + NumberOfConnectives p
        | Conjunction (p, q) -> 1 + NumberOfConnectives p + NumberOfConnectives q
        | Disjunction (p, q) -> 1 + NumberOfConnectives p + NumberOfConnectives q
        | Implication (p, q) -> 1 + NumberOfConnectives p + NumberOfConnectives q

    let GetSubformulas (formula: Formula) =
        match formula with
        | AtomicFormula p -> Set.empty.Add(AtomicFormula p)
        | Negation p -> Set.empty.Add(formula).Add(p)
        | Conjunction (p, q) -> Set.empty.Add(formula).Add(p).Add(q)
