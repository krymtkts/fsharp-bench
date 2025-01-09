namespace inspector

open ObjectLayoutInspector

module Program =
    let printLayout t =
        typeof<TypeLayout>
            .GetMethod("PrintLayout", [| typeof<bool> |])
            .MakeGenericMethod([| t |])
            .Invoke(null, [| true |])
        |> ignore

    [<EntryPoint>]
    let main argv =
        printfn "Record layouts"

        [ typeof<Record.SimpleRecord3>
          typeof<Record.SimpleRecord6>
          typeof<Record.SimpleRecord12>
          typeof<Record.SimpleRecord18>
          typeof<Record.SimpleRecord24>
          typeof<Record.StructRecord3>
          typeof<Record.StructRecord6>
          typeof<Record.StructRecord12>
          typeof<Record.StructRecord18>
          typeof<Record.StructRecord24> ]
        |> List.iter printLayout

        printfn "Nested record layouts"

        [ typeof<NestedRecord.SimpleNestedRecord3>
          typeof<NestedRecord.SimpleNestedRecord6>
          typeof<NestedRecord.SimpleNestedRecord12>
          typeof<NestedRecord.SimpleNestedRecord18>
          typeof<NestedRecord.SimpleNestedRecord24>
          typeof<NestedRecord.StructNestedRecord3>
          typeof<NestedRecord.StructNestedRecord6>
          typeof<NestedRecord.StructNestedRecord12>
          typeof<NestedRecord.StructNestedRecord18>
          typeof<NestedRecord.StructNestedRecord24> ]
        |> List.iter printLayout

        printfn "Discriminated union layouts"

        [ typeof<du.SimpleDu3>
          typeof<du.SimpleDu6>
          typeof<du.SimpleDu12>
          typeof<du.SimpleDu18>
          typeof<du.SimpleDu24>
          typeof<du.StructDu3>
          typeof<du.StructDu6>
          typeof<du.StructDu12>
          typeof<du.StructDu18>
          typeof<du.StructDu24> ]
        |> List.iter printLayout

        0
