module Tests

open NUnit.Framework
open Serializer

let same (x:'a) =
    let str = serialize x
    let result = deserialize<'a> str
    Assert.AreEqual(x, result)

let serializes str obj =
    Assert.AreEqual(str, serialize obj)