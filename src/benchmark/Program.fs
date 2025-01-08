open System
open BenchmarkDotNet.Running
open record
open NestedRecord
open du

[<EntryPoint>]
let main argv =
    BenchmarkSwitcher
        .FromTypes(
            [| typeof<RecordBenchmarks>
               typeof<NestedRecordBenchmarks>
               typeof<DuBenchmarks> |]
        )
        .Run(argv)
    |> ignore

    0 // return an integer exit code
