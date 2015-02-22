namespace FJson

open System
open Microsoft.FSharp.Reflection
open Raven.Imports.Newtonsoft.Json
open System.Collections

type UnionConverter() =
    inherit JsonConverter()

    let [<Literal>] CaseTag = "Case"

    override x.CanConvert(t) = 
        not(typeof<IEnumerable>.IsAssignableFrom(t)) && FSharpType.IsUnion(t)

    override x.WriteJson(writer, value, serializer) = 
        let t = value.GetType()
        let case, fields = FSharpValue.GetUnionFields(value, t)

        writer.WriteStartObject()
        writer.WritePropertyName(CaseTag)
        writer.WriteValue(case.Name)
        fields |> Array.iteri (fun index value ->
            writer.WritePropertyName(sprintf "Item%d" index)
            serializer.Serialize(writer, value))
        writer.WriteEndObject()
            
    override x.ReadJson(reader, t, existingValue, serializer) = obj()