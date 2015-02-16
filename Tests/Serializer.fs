module Serializer

open Newtonsoft.Json
open System
open FJson

let opt = new OptionConverter()

let converters : JsonConverter array = [| opt |]

let serialize x =
    JsonConvert.SerializeObject(x, converters)

let deserialize<'a> str =
    JsonConvert.DeserializeObject<'a>(str, converters)
