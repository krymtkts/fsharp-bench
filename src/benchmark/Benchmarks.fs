module benchmark

open BenchmarkDotNet.Attributes

type SimpleRecord3 =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

[<Struct>]
type StructRecord3 =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

let updateSimpleRecord3 (record: SimpleRecord3) (i: int) = { record with IntValue = i }
let updateStructRecord3 (record: StructRecord3) (i: int) = { record with IntValue = i }

[<MemoryDiagnoser>]
type Benchmarks() =
    [<Params(1000, 10000, 100000, 1000000)>]
    member val N = 0 with get, set

    member val data: int seq = seq {  } with get, set

    [<GlobalSetup>]
    member __.GlobalSetup() = __.data <- seq { 1 .. __.N }

    [<Benchmark>]
    member __.SimpleRecord() =
        __.data
        |> Seq.fold
            updateSimpleRecord3
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord() =
        __.data
        |> Seq.fold
            updateStructRecord3
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore
