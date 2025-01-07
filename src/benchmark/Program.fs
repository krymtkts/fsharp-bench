open System
open BenchmarkDotNet.Running
open benchmark

[<EntryPoint>]
let main argv =
    BenchmarkSwitcher
        .FromTypes([| typeof<Benchmarks> |])
        .Run(argv)
    |> ignore

    0 // return an integer exit code
