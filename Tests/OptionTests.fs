module OptionTests

open Tests
open NUnit.Framework

type Complex = A | B

[<Test>]
let ``some serializes to the object``() =
    Some 5 |> serializes "5"
    Some true |> serializes "true"

[<Test>]
let ``none serializes to null`` () =
    None |> serializes "null"
    [Some 3; None; Some 4] |> serializes "[3,null,4]"

[<Test>]
let ``can serialize a complex option``() =
    let none : Complex option = None
    same none