module IdiomaticDUTests

open Tests
open NUnit.Framework

type Simple =
    | Int of int
    | String of string

type Status =
    | Named of active:bool * text:string
    | Else of int
    | New

[<Test>]
let ``simple unnamed dus are serialized idiomatically`` () =
    Int 5 |> serializes "{\"Case\":\"Int\",\"Fields\":[5]}"

[<Test>]
let ``dus without fields don't generate Fields property`` () =
    New |> serializes "{\"Case\":\"New\"}"