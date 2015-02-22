module IdiomaticDUTests

open Tests
open NUnit.Framework

type Simple =
    | Int of int
    | String of string

type Status =
    | Named of active:bool * text:string
    | Else of int

[<Test>]
let ``simple unnamed dus are serialized idiomatically`` () =
    Int 5 |> serializes "{\"Case\":\"Int\",\"Fields\":[5]}"

[<Test;Ignore>]
let ``dus with named fields keep their names`` () =
    Named (true, "lorem ipsum") 
        |> serializes "{\"Case\":\"Named\",\"active\":true,\"text\":\"lorem ipsum\"}"