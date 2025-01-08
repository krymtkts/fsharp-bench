open System
open BenchmarkDotNet.Running
open record

[<EntryPoint>]
let main argv =
    BenchmarkSwitcher
        .FromTypes([| typeof<RecordBenchmarks> |])
        .Run(argv)
    |> ignore

    0 // return an integer exit code
