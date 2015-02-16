module UnionTests

open Tests
open NUnit.Framework

type Enum = A | B | C
type Union =
    | Empty
    | Value of int
type ComplexUnion =
    | One of string
    | Two of named:string * value:int
    | Complex of Union * Enum

type Record = {
    union: Union
    number: Union option
}

[<Test>]
let ``works with enums`` () =
    same A
    same B

[<Test>]
let ``works with unions`` () =
    same Empty
    same (Value 5)

[<Test>]
let ``works with complex unions`` ()=
    same <| One "asdf"
    same <| Two (named = "asdf", value = 5)
    same <| Complex (Value 5, C)

[<Test>]
let ``can read a union inside a record`` () =
    same <| { union = Empty; number = None }