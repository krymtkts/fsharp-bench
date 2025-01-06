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

type SimpleRecord24 =
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
      BoolValue4: bool
      IntValue5: int
      StringValue5: string
      BoolValue5: bool
      IntValue6: int
      StringValue6: string
      BoolValue6: bool
      IntValue7: int
      StringValue7: string
      BoolValue7: bool
      IntValue8: int
      StringValue8: string
      BoolValue8: bool }

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

[<Struct>]
type StructRecord24 =
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
      BoolValue4: bool
      IntValue5: int
      StringValue5: string
      BoolValue5: bool
      IntValue6: int
      StringValue6: string
      BoolValue6: bool
      IntValue7: int
      StringValue7: string
      BoolValue7: bool
      IntValue8: int
      StringValue8: string
      BoolValue8: bool }

let updateSimpleRecord3 (record: SimpleRecord3) (i: int) = { record with IntValue = i }
let updateStructRecord3 (record: StructRecord3) (i: int) = { record with IntValue = i }
let updateSimpleRecord12 (record: SimpleRecord12) (i: int) = { record with IntValue = i }
let updateStructRecord12 (record: StructRecord12) (i: int) = { record with IntValue = i }
let updateSimpleRecord24 (record: SimpleRecord24) (i: int) = { record with IntValue = i }
let updateStructRecord24 (record: StructRecord24) (i: int) = { record with IntValue = i }

let updateSimpleRecord3two (record: SimpleRecord3) (i: int) =
    updateSimpleRecord3 { record with StringValue = string i } i

let updateStructRecord3two (record: StructRecord3) (i: int) =
    updateStructRecord3 { record with StringValue = string i } i

let updateSimpleRecord12two (record: SimpleRecord12) (i: int) =
    updateSimpleRecord12 { record with StringValue = string i } i

let updateStructRecord12two (record: StructRecord12) (i: int) =
    updateStructRecord12 { record with StringValue = string i } i

let updateSimpleRecord24two (record: SimpleRecord24) (i: int) =
    updateSimpleRecord24 { record with StringValue = string i } i

let updateStructRecord24two (record: StructRecord24) (i: int) =
    updateStructRecord24 { record with StringValue = string i } i

let updateSimpleRecord3three (record: SimpleRecord3) (i: int) =
    updateSimpleRecord3two { record with BoolValue = i % 2 = 0 } i

let updateStructRecord3three (record: StructRecord3) (i: int) =
    updateStructRecord3two { record with BoolValue = i % 2 = 0 } i

let updateSimpleRecord12three (record: SimpleRecord12) (i: int) =
    updateSimpleRecord12two { record with BoolValue = i % 2 = 0 } i

let updateStructRecord12three (record: StructRecord12) (i: int) =
    updateStructRecord12two { record with BoolValue = i % 2 = 0 } i

let updateSimpleRecord24three (record: SimpleRecord24) (i: int) =
    updateSimpleRecord24two { record with BoolValue = i % 2 = 0 } i

let updateStructRecord24three (record: StructRecord24) (i: int) =
    updateStructRecord24two { record with BoolValue = i % 2 = 0 } i

[<MemoryDiagnoser>]
type Benchmarks() =
    [<Params(1000, 10000, 10000)>]
    member val N = 0 with get, set

    member val data: int seq = seq {  } with get, set

    [<GlobalSetup>]
    member __.GlobalSetup() = __.data <- seq { 1 .. __.N }

    [<Benchmark>]
    member __.SimpleRecord3() =
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


    [<Benchmark>]
    member __.SimpleRecord24() =
        __.data
        |> Seq.fold
            updateSimpleRecord24
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord24() =
        __.data
        |> Seq.fold
            updateStructRecord24
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord3two() =
        __.data
        |> Seq.fold
            updateSimpleRecord3two
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3two() =
        __.data
        |> Seq.fold
            updateStructRecord3two
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12two() =
        __.data
        |> Seq.fold
            updateSimpleRecord12two
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
    member __.StructRecord12two() =
        __.data
        |> Seq.fold
            updateStructRecord12two
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
    member __.SimpleRecord24two() =
        __.data
        |> Seq.fold
            updateSimpleRecord24two
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord24two() =
        __.data
        |> Seq.fold
            updateStructRecord24two
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord3three() =
        __.data
        |> Seq.fold
            updateSimpleRecord3three
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3three() =
        __.data
        |> Seq.fold
            updateStructRecord3three
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12three() =
        __.data
        |> Seq.fold
            updateSimpleRecord12three
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
    member __.StructRecord12three() =
        __.data
        |> Seq.fold
            updateStructRecord12three
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
    member __.SimpleRecord24three() =
        __.data
        |> Seq.fold
            updateSimpleRecord24three
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord24three() =
        __.data
        |> Seq.fold
            updateStructRecord24three
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
              BoolValue4 = true
              IntValue5 = 0
              StringValue5 = "Hello"
              BoolValue5 = true
              IntValue6 = 0
              StringValue6 = "Hello"
              BoolValue6 = true
              IntValue7 = 0
              StringValue7 = "Hello"
              BoolValue7 = true
              IntValue8 = 0
              StringValue8 = "Hello"
              BoolValue8 = true }
        |> ignore
