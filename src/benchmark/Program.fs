open System
open BenchmarkDotNet.Running
open record
open NestedRecord

[<EntryPoint>]
let main argv =
    BenchmarkSwitcher
        .FromTypes(
            [| typeof<RecordBenchmarks>
               typeof<NestedRecordBenchmarks> |]
        )
        .Run(argv)
    |> ignore

    0 // return an integer exit code
