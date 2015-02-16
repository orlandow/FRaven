module AllMixedTests

open Tests
open NUnit.Framework

type Color = Red | Green | Blue

type Status =
    | New
    | Cold of string
    | Scheduled of string * int

type ComplexRecord = {
    name: string
    number: int option
    status: Status
    previous: Status option
}

[<Test>]
let ``final test``() =
    let p = { name = "asdf"; number = Some 5; status = New; previous = None } 
    [ 
        p
        { p with number = None }
        { p with status = Cold "asdf"; previous = Some New }
        { p with status = New; previous = Some <| Scheduled ("a", 12) }
    ] |> List.iter same
