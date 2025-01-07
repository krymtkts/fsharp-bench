module benchmark

open BenchmarkDotNet.Attributes

type SimpleRecord3 =
    { IntValue: int
      StringValue: string
      BoolValue: bool }

type SimpleRecord6 =
    { IntValue: int
      StringValue: string
      BoolValue: bool
      IntValue2: int
      StringValue2: string
      BoolValue2: bool }

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

type SimpleRecord18 =
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
      BoolValue6: bool }

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
type StructRecord6 =
    { IntValue: int
      StringValue: string
      BoolValue: bool
      IntValue2: int
      StringValue2: string
      BoolValue2: bool }

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
type StructRecord18 =
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
      BoolValue6: bool }

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
let updateSimpleRecord6 (i: int) (record: SimpleRecord6) = { record with IntValue = i }
let updateStructRecord6 (i: int) (record: StructRecord6) = { record with IntValue = i }
let updateSimpleRecord12 (i: int) (record: SimpleRecord12) = { record with IntValue = i }
let updateStructRecord12 (i: int) (record: StructRecord12) = { record with IntValue = i }
let updateSimpleRecord18 (i: int) (record: SimpleRecord18) = { record with IntValue = i }
let updateStructRecord18 (i: int) (record: StructRecord18) = { record with IntValue = i }
let updateSimpleRecord24 (i: int) (record: SimpleRecord24) = { record with IntValue = i }
let updateStructRecord24 (i: int) (record: StructRecord24) = { record with IntValue = i }

[<TailCall>]
let rec recFoldBack f xs acc =
    match xs with
    | [] -> acc
    | x :: xs -> recFoldBack f xs (f x acc)

[<MemoryDiagnoser>]
type Benchmarks() =
    let simple3: SimpleRecord3 =
        { IntValue = 0
          StringValue = "Hello"
          BoolValue = true }

    let struct3: StructRecord3 =
        { IntValue = 0
          StringValue = "Hello"
          BoolValue = true }

    let simple6: SimpleRecord6 =
        { IntValue = 0
          StringValue = "Hello"
          BoolValue = true
          IntValue2 = 0
          StringValue2 = "Hello"
          BoolValue2 = true }

    let struct6: StructRecord6 =
        { IntValue = 0
          StringValue = "Hello"
          BoolValue = true
          IntValue2 = 0
          StringValue2 = "Hello"
          BoolValue2 = true }

    let simple12: SimpleRecord12 =
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

    let struct12: StructRecord12 =
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

    let simple18: SimpleRecord18 =
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
          BoolValue6 = true }

    let struct18: StructRecord18 =
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
          BoolValue6 = true }

    let simple24: SimpleRecord24 =
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

    let struct24: StructRecord24 =
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
        Seq.foldBack updateSimpleRecord3 __.data simple3

    [<Benchmark>]
    member __.StructRecord3() =
        Seq.foldBack updateStructRecord3 __.data struct3

    [<Benchmark>]
    member __.SimpleRecord3rec() =
        recFoldBack updateSimpleRecord3 __.recData simple3

    [<Benchmark>]
    member __.StructRecord3rec() =
        recFoldBack updateStructRecord3 __.recData struct3

    [<Benchmark>]
    member __.SimpleRecord6() =
        Seq.foldBack updateSimpleRecord6 __.data simple6

    [<Benchmark>]
    member __.StructRecord6() =
        Seq.foldBack updateStructRecord6 __.data struct6

    [<Benchmark>]
    member __.SimpleRecord6rec() =
        recFoldBack updateSimpleRecord6 __.recData simple6

    [<Benchmark>]
    member __.StructRecord6rec() =
        recFoldBack updateStructRecord6 __.recData struct6

    [<Benchmark>]
    member __.SimpleRecord12() =
        Seq.foldBack updateSimpleRecord12 __.data simple12

    [<Benchmark>]
    member __.StructRecord12() =
        Seq.foldBack updateStructRecord12 __.data struct12

    [<Benchmark>]
    member __.SimpleRecord12rec() =
        recFoldBack updateSimpleRecord12 __.recData simple12

    [<Benchmark>]
    member __.StructRecord12rec() =
        recFoldBack updateStructRecord12 __.recData struct12

    [<Benchmark>]
    member __.SimpleRecord18() =
        Seq.foldBack updateSimpleRecord18 __.data simple18

    [<Benchmark>]
    member __.StructRecord18() =
        Seq.foldBack updateStructRecord18 __.data struct18

    [<Benchmark>]
    member __.SimpleRecord18rec() =
        recFoldBack updateSimpleRecord18 __.recData simple18

    [<Benchmark>]
    member __.StructRecord18rec() =
        recFoldBack updateStructRecord18 __.recData struct18

    [<Benchmark>]
    member __.SimpleRecord24() =
        Seq.foldBack updateSimpleRecord24 __.data simple24

    [<Benchmark>]
    member __.StructRecord24() =
        Seq.foldBack updateStructRecord24 __.data struct24

    [<Benchmark>]
    member __.SimpleRecord24rec() =
        recFoldBack updateSimpleRecord24 __.recData simple24

    [<Benchmark>]
    member __.StructRecord24rec() =
        recFoldBack updateStructRecord24 __.recData struct24
