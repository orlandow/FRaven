module Serializer

open System
open FJson
open Raven.Imports.Newtonsoft.Json

let opt = new OptionConverter()
let un = new UnionConverter()
let li = new ListConverter()
let set = new SetConverter()

let converters : JsonConverter array = [| opt; un; li; set |]

let serialize x =
    JsonConvert.SerializeObject(x, converters)

let deserialize<'a> str =
    JsonConvert.DeserializeObject<'a>(str, converters)