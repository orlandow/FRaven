module PersistentStructureTests

open Tests
open NUnit.Framework

[<Test>]
let ``can serialize a set``() =
    same <| set [1;2;3;4]