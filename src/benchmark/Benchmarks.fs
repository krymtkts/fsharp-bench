module benchmark

open BenchmarkDotNet.Attributes

type SimpleRecord3 =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

type SimpleRecord12 =
    { IntValue: int
      StringValue: string
      BoolValue: bool
      IntValue2: int
      StringValue2: string
      BoolValue2: bool
      IntValue3: int
      StringValue3: string
      BoolValue3: bool
      IntValue4: int
      StringValue4: string
      BoolValue4: bool }

[<Struct>]
type StructRecord3 =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

[<Struct>]
type StructRecord12 =
    { IntValue: int
      StringValue: string
      BoolValue: bool
      IntValue2: int
      StringValue2: string
      BoolValue2: bool
      IntValue3: int
      StringValue3: string
      BoolValue3: bool
      IntValue4: int
      StringValue4: string
      BoolValue4: bool }

let updateSimpleRecord3 (record: SimpleRecord3) (i: int) = { record with IntValue = i }
let updateStructRecord3 (record: StructRecord3) (i: int) = { record with IntValue = i }
let updateSimpleRecord12 (record: SimpleRecord12) (i: int) = { record with IntValue = i }
let updateStructRecord12 (record: StructRecord12) (i: int) = { record with IntValue = i }

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
    member __.StructRecord3() =
        __.data
        |> Seq.fold
            updateStructRecord3
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12() =
        __.data
        |> Seq.fold
            updateSimpleRecord12
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true
              IntValue2 = 0
              StringValue2 = "Hello"
              BoolValue2 = true
              IntValue3 = 0
              StringValue3 = "Hello"
              BoolValue3 = true
              IntValue4 = 0
              StringValue4 = "Hello"
              BoolValue4 = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord12() =
        __.data
        |> Seq.fold
            updateStructRecord12
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true
              IntValue2 = 0
              StringValue2 = "Hello"
              BoolValue2 = true
              IntValue3 = 0
              StringValue3 = "Hello"
              BoolValue3 = true
              IntValue4 = 0
              StringValue4 = "Hello"
              BoolValue4 = true }
        |> ignore
