namespace FJson

open System
open Microsoft.FSharp.Reflection
open Raven.Imports.Newtonsoft.Json
open System.Collections.Generic
open Raven.Imports.Newtonsoft.Json.Linq
open System.Reflection

type MapConverter() =
    inherit JsonConverter()

    static member BuildMap<'k,'v when 'k:comparison>(d:Dictionary<'k,'v>) =
        d :> IEnumerable<KeyValuePair<'k,'v>>
        |> Seq.map (fun t -> (t.Key, t.Value))
        |> Map.ofSeq

    override x.CanConvert(t:Type) = 
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Map<_,_>>
 
    override x.WriteJson(writer, value, serializer) =
        let s = new JsonSerializer()
        let cs = [ for c in serializer.Converters do
                      if c.GetType() <> x.GetType() 
                        then yield c ]
        cs |> List.iter (s.Converters.Add)

        s.Serialize(writer, value)
 
    override x.ReadJson(reader, t, obj, serializer) = 
        let keyType = t.GetGenericArguments().[0]
        let valueType = t.GetGenericArguments().[1]
        let collectionType = typedefof<Dictionary<_,_>>.MakeGenericType(keyType, valueType)
        let collection = serializer.Deserialize(reader, collectionType) 

        let builder = typedefof<MapConverter>.GetMethod("BuildMap")
        let builder = builder.MakeGenericMethod([|keyType;valueType|])
        builder.Invoke(null, [|collection|])
