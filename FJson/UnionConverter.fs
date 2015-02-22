namespace FJson

open System
open Microsoft.FSharp.Reflection
open Raven.Imports.Newtonsoft.Json
open System.Collections

type UnionConverter() =
    inherit JsonConverter()

    let [<Literal>] CaseTag = "Case"
    let [<Literal>] FieldsTag = "Fields"

    let read (reader:JsonReader) =
        if reader.Read() 
            then () 
            else failwith "unexpected end when reading union"

    override x.CanConvert(t) = 
        not(typeof<IEnumerable>.IsAssignableFrom(t)) && FSharpType.IsUnion(t)

    override x.WriteJson(writer, value, serializer) = 
        let t = value.GetType()
        let case, fields = FSharpValue.GetUnionFields(value, t)

        writer.WriteStartObject()
        writer.WritePropertyName(CaseTag)
        writer.WriteValue(case.Name)
        writer.WritePropertyName(FieldsTag)
        serializer.Serialize(writer, fields)
        writer.WriteEndObject()
            
    override x.ReadJson(reader, t, existingValue, serializer) = 
        read reader // start object

        obj()
