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


