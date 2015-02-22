﻿module PersistentStructureTests

open Tests
open NUnit.Framework

type Enum = A | B | C

[<Test>]
let ``can serialize a set``() =
    same <| set [1;2;3;4]
    same <| set [A; B; C]
    same <| set [Some 3; None]
    same <| set [set [1;2]; set [3;1]]
    
[<Test>]
let ``can serialize a map``() =
    same <| Map.ofList [("a",1);("b",2)]