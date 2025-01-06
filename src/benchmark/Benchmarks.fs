module benchmark

open BenchmarkDotNet.Attributes

type SimpleRecord =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

[<Struct>]
type StructRecord =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

let updateSimpleRecord (record: SimpleRecord) (i: int) = { record with IntValue = i }
let updateStructRecord (record: StructRecord) (i: int) = { record with IntValue = i }

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
            updateSimpleRecord
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord() =
        __.data
        |> Seq.fold
            updateStructRecord
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore
