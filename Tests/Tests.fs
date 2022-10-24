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

