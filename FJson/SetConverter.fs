namespace FJson

open System
open Microsoft.FSharp.Reflection
open Raven.Imports.Newtonsoft.Json
open System.Collections.Generic
open Raven.Imports.Newtonsoft.Json.Linq

type SetConverter() =
    inherit JsonConverter()

    let listConverter = new ListConverter()
    
    override x.CanConvert(t:Type) = 
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Set<_>>
 
    override x.WriteJson(writer, value, serializer) =
        listConverter.WriteJson(writer, value, serializer)
 
    override x.ReadJson(reader, t, obj, serializer) = 
        let itemType = t.GetGenericArguments().[0]
        let collectionType = typedefof<List<_>>.MakeGenericType(itemType)
        let collection = serializer.Deserialize(reader, collectionType) 
                            :?> System.Collections.IEnumerable
                            |> Seq.cast

        set collection :> obj