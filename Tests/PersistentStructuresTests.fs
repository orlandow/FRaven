module PersistentStructureTests

open Tests
open NUnit.Framework

[<Test>]
let ``can serialize a set``() =
    same <| set [1;2;3;4]
    
[<Test>]
let ``can serialize a map``() =
    same <| Map.ofList [("a",1);("b",2)]