module VeryComplexTests

open Tests
open NUnit.Framework

type Enum = A | B | C
type Tree =
    | Tree of int * Tree * Tree
    | Leaf
type Union =
    | First of string * int
    | Second of Enum * Enum option
    | Third
type Record = {
    enum: Enum option
    union: Union option
    tree: Tree option
    record: Record option
    set: Enum Set option
    map: Map<int,Tree> option
}

[<Test>]
let ``can serialize a recursive union``() =
    same <| Leaf
    same <| Tree (5, Tree (2, Leaf, Leaf), Tree (3, Leaf, Tree (7, Leaf, Leaf)))

[<Test>]
let ``can serialize a recursive record``() =
    let t = { enum = None; union = None; tree = None; record = None; set = None; map = None }
    same <| t
    same <| { t with record = Some t }

[<Test>]
let ``can serialize a very complex record`` () =
    same <|
        { enum = Some A
          union = Some <| Second (B, None)
          tree = Some <| Tree(3, Leaf, Tree(2, Leaf, Leaf))
          record = None
          set = Some <| set [A;B]
          map = Some <| Map.ofList [(1,Leaf);(2,Tree(2,Leaf,Leaf))]}