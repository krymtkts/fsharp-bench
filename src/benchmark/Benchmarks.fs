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

let updateSimpleRecord3 (i: int) (record: SimpleRecord3) = { record with IntValue = i }
let updateStructRecord3 (i: int) (record: StructRecord3) = { record with IntValue = i }
let updateSimpleRecord12 (i: int) (record: SimpleRecord12) = { record with IntValue = i }
let updateStructRecord12 (i: int) (record: StructRecord12) = { record with IntValue = i }
let updateSimpleRecord24 (i: int) (record: SimpleRecord24) = { record with IntValue = i }
let updateStructRecord24 (i: int) (record: StructRecord24) = { record with IntValue = i }

let updateSimpleRecord3two (i: int) (record: SimpleRecord3) =
    { record with StringValue = string i }
    |> updateSimpleRecord3 i

let updateStructRecord3two (i: int) (record: StructRecord3) =
    { record with StringValue = string i }
    |> updateStructRecord3 i

let updateSimpleRecord12two (i: int) (record: SimpleRecord12) =
    { record with StringValue = string i }
    |> updateSimpleRecord12 i

let updateStructRecord12two (i: int) (record: StructRecord12) =
    { record with StringValue = string i }
    |> updateStructRecord12 i

let updateSimpleRecord24two (i: int) (record: SimpleRecord24) =
    { record with StringValue = string i }
    |> updateSimpleRecord24 i

let updateStructRecord24two (i: int) (record: StructRecord24) =
    { record with StringValue = string i }
    |> updateStructRecord24 i

let updateSimpleRecord3three (i: int) (record: SimpleRecord3) =
    { record with BoolValue = i % 2 = 0 }
    |> updateSimpleRecord3two i

let updateStructRecord3three (i: int) (record: StructRecord3) =
    { record with BoolValue = i % 2 = 0 }
    |> updateStructRecord3two i

let updateSimpleRecord12three (i: int) (record: SimpleRecord12) =
    { record with BoolValue = i % 2 = 0 }
    |> updateSimpleRecord12two i

let updateStructRecord12three (i: int) (record: StructRecord12) =
    { record with BoolValue = i % 2 = 0 }
    |> updateStructRecord12two i

let updateSimpleRecord24three (i: int) (record: SimpleRecord24) =
    { record with BoolValue = i % 2 = 0 }
    |> updateSimpleRecord24two i

let updateStructRecord24three (i: int) (record: StructRecord24) =
    { record with BoolValue = i % 2 = 0 }
    |> updateStructRecord24two i

[<TailCall>]
let rec recFoldBack f xs acc =
    match xs with
    | [] -> acc
    | x :: xs -> recFoldBack f xs (f x acc)

[<MemoryDiagnoser>]
type Benchmarks() =
    [<Params(10, 100, 1000)>]
    member val N = 0 with get, set

    member val data: int seq = seq {  } with get, set
    member val recData: int list = [] with get, set

    [<GlobalSetup>]
    member __.GlobalSetup() =
        __.data <- seq { 1 .. __.N }
        __.recData <- seq { 1 .. __.N } |> List.ofSeq

    [<Benchmark>]
    member __.SimpleRecord3() =
        Seq.foldBack
            updateSimpleRecord3
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3() =
        Seq.foldBack
            updateStructRecord3
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord3rec() =
        recFoldBack
            updateSimpleRecord3
            __.recData
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3rec() =
        recFoldBack
            updateStructRecord3
            __.recData
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12() =
        Seq.foldBack
            updateSimpleRecord12
            __.data
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
        Seq.foldBack
            updateStructRecord12
            __.data
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
    member __.StructRecord12rec() =
        recFoldBack
            updateStructRecord12
            __.recData
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
    member __.SimpleRecord12rec() =
        recFoldBack
            updateSimpleRecord12
            __.recData
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
        Seq.foldBack
            updateSimpleRecord24
            __.data
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
        Seq.foldBack
            updateStructRecord24
            __.data
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
    member __.SimpleRecord24rec() =
        recFoldBack
            updateSimpleRecord24
            __.recData
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
    member __.StructRecord24rec() =
        recFoldBack
            updateStructRecord24
            __.recData
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
        Seq.foldBack
            updateSimpleRecord3two
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3two() =
        Seq.foldBack
            updateStructRecord3two
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12two() =
        Seq.foldBack
            updateSimpleRecord12two
            __.data
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
        Seq.foldBack
            updateStructRecord12two
            __.data
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
        Seq.foldBack
            updateSimpleRecord24two
            __.data
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
        Seq.foldBack
            updateStructRecord24two
            __.data
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
        Seq.foldBack
            updateSimpleRecord3three
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.StructRecord3three() =
        Seq.foldBack
            updateStructRecord3three
            __.data
            { IntValue = 0
              StringValue = "Hello"
              BoolValue = true }
        |> ignore

    [<Benchmark>]
    member __.SimpleRecord12three() =
        Seq.foldBack
            updateSimpleRecord12three
            __.data
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
        Seq.foldBack
            updateStructRecord12three
            __.data
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
        Seq.foldBack
            updateSimpleRecord24three
            __.data
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
        Seq.foldBack
            updateStructRecord24three
            __.data
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
