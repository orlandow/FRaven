module ListTests

open Tests
open NUnit.Framework

[<Test>]
let ``can serialize lists``() =
    same <| [1;2;3;4]
    same <| [Some 5; Some 3; None]
    same <| [true; false]

[<Test>]
let ``lists are serialized to json arrays``() =
    [1;2;3;4] |> serializes "[1,2,3,4]"