module BasicTests

open Tests
open NUnit.Framework

[<Test>]
let ``it works with primitive types``() =
    same true
    same false
    same null
    same "asdf"
    same 5
    same 'c'
    same System.DateTime.Now
    same 0

[<Test>]
let ``it works with option types`` () =
    same <| Some 3
    same <| Some "asdf"
    same <| None
    same <| Some (Some 3)
//    same <| Some (None)           //this one fails in idiomatic json
//    same <| Some (Some None)      //this one fails in idiomatic json

[<Test>]
let ``it works with tuple types`` () =
    same <| (1,2)
    same <| ("asdf", true, false)
    same <| (null, Some true, None)

[<Test>]
let ``it works with lists`` () =
    same <| [1..10]
    same <| []
    same <| [true; false]
    same <| [Some 5; None]

[<Test>]
let ``it works with arrays`` () =
    same <| [|1..10|]
    same <| [||]
    same <| [|Some 5; None|]

[<Test>]
let ``it works with 2D arrays`` () =
    same <| Array2D.init 10 10 (fun x y -> x + y)

