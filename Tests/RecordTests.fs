module RecordTests

open Tests
open NUnit.Framework

type Point = { x:int; y:int }
type Circle = { center: Point; radius: float }
type Graphic = { points: Point list; color: string option }

[<Test>]
let ``works with simple record types``() =
   same <| { x = 3; y = 5 } 

[<Test>]
let ``works with complex record types``() =
   same <| { center = { x = 0; y = 0 }; radius = 10. }
   same <| { x = 3; y = 5 } 