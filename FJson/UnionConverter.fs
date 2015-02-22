namespace FJson

open System
open Microsoft.FSharp.Reflection
open Raven.Imports.Newtonsoft.Json

type UnionConverter() =
    inherit JsonConverter()

    override x.CanConvert(t) = false

    override x.WriteJson(writer, value, serializer) = ()
            
    override x.ReadJson(reader, t, existingValue, serializer) = obj()