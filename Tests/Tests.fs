namespace Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Implementation
open Functions


[<TestClass>]
type TestNumberOfConnectives () =

    [<TestMethod>]
    member this.AtomicFormula_ShouldReturn0 () =
        let p: Formula = AtomicFormula 'p';
        let formula: Formula = p;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(0, result);


    [<TestMethod>]
    member this.NegatedAtomicFormula_ShouldReturn1 () =
        let p: Formula = AtomicFormula 'p';
        let formula: Formula = -p;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(1, result);


    [<TestMethod>]
    member this.ConjunctionOfAtomics_ShouldReturn1 () =
        let p: Formula = AtomicFormula 'p';
        let q: Formula = AtomicFormula 'q';
        let formula: Formula = p .& q;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(1, result);


    [<TestMethod>]
    member this.DisjunctionOfAtomics_ShouldReturn1 () =
        let p: Formula = AtomicFormula 'p';
        let q: Formula = AtomicFormula 'q';
        let formula: Formula = p .| q;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(1, result);


    [<TestMethod>]
    member this.ImplicationOfAtomics_ShouldReturn1 () =
        let p: Formula = AtomicFormula 'p';
        let q: Formula = AtomicFormula 'q';
        let formula: Formula = p --> q;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(1, result);


    [<TestMethod>]
    member this.TestComplicatedFormula () =
        let p: Formula = AtomicFormula 'p';
        let q: Formula = AtomicFormula 'q';
        let r: Formula = AtomicFormula 'r';
        let formula: Formula = (p --> q .& p) .| -r;

        let result: int = NumberOfConnectives formula

        Assert.AreEqual(4, result);


[<TestClass>]
type TestGetSubformulas () =

    [<TestMethod>]
    member this.AtomicFormula_ShouldReturnItself () =
        let p: Formula = AtomicFormula 'p'
        let formula = p

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add(p), result);


    [<TestMethod>]
    member this.NegatedAtomic_ShouldReturnItselfAndAtomic () =
        let p: Formula = AtomicFormula 'p'
        let formula = -p

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add(-p).Add(p), result);


    [<TestMethod>]
    member this.TestConjunctionOfAtomics () =
        let p: Formula = AtomicFormula 'p'
        let q: Formula = AtomicFormula 'q'
        let formula = p .& q

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add(p .& q).Add(p).Add(q), result);


    [<TestMethod>]
    member this.TestDisjunctionOfAtomics () =
        let p: Formula = AtomicFormula 'p'
        let q: Formula = AtomicFormula 'q'
        let formula = p .| q

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add(p .| q).Add(p).Add(q), result);


    [<TestMethod>]
    member this.TestImplicationOfAtomics () =
        let p: Formula = AtomicFormula 'p'
        let q: Formula = AtomicFormula 'q'
        let formula = p --> q

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add(p --> q).Add(p).Add(q), result);


    [<TestMethod>]
    member this.TestComplicatedFormula () =
        let p: Formula = AtomicFormula 'p'
        let q: Formula = AtomicFormula 'q'
        let r: Formula = AtomicFormula 'r'
        let formula = (p --> q .& p) .| -r

        let result: Set<Formula> = GetSubformulas formula

        Assert.AreEqual(Set.empty.Add((p --> q .& p) .| -r)
                                 .Add(p --> q .& p)
                                    .Add(p --> q)
                                        .Add(p)
                                        .Add(q)
                                 .Add(-r)
                                    .Add(r),
                        result);
