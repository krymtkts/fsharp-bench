open System
open BenchmarkDotNet.Running
open Record
open NestedRecord
open du

[<EntryPoint>]
let main argv =
    BenchmarkSwitcher
        .FromTypes(
            [| typeof<SimpleRecordBenchmarks>
               typeof<NestedRecordBenchmarks>
               typeof<DuBenchmarks> |]
        )
        .Run(argv)
    |> ignore

    0 // return an integer exit code
