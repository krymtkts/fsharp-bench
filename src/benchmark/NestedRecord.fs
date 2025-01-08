module NestedRecord

open BenchmarkDotNet.Attributes
open record

type SimpleNestedRecord3 = { Nested3: SimpleRecord3 }

type SimpleNestedRecord6 =
    { Nested3: SimpleRecord3
      Nested6: SimpleRecord6 }

type SimpleNestedRecord12 =
    { Nested3: SimpleRecord3
      Nested6: SimpleRecord6
      Nested12: SimpleRecord12 }

type SimpleNestedRecord18 =
    { Nested3: SimpleRecord3
      Nested6: SimpleRecord6
      Nested12: SimpleRecord12
      Nested18: SimpleRecord18 }

type SimpleNestedRecord24 =
    { Nested3: SimpleRecord3
      Nested6: SimpleRecord6
      Nested12: SimpleRecord12
      Nested18: SimpleRecord18
      Nested24: SimpleRecord24 }

[<Struct>]
type StructNestedRecord3 = { Nested3: StructRecord3 }

[<Struct>]
type StructNestedRecord6 =
    { Nested3: StructRecord3
      Nested6: StructRecord6 }

[<Struct>]
type StructNestedRecord12 =
    { Nested3: StructRecord3
      Nested6: StructRecord6
      Nested12: StructRecord12 }

[<Struct>]
type StructNestedRecord18 =
    { Nested3: StructRecord3
      Nested6: StructRecord6
      Nested12: StructRecord12
      Nested18: StructRecord18 }

[<Struct>]
type StructNestedRecord24 =
    { Nested3: StructRecord3
      Nested6: StructRecord6
      Nested12: StructRecord12
      Nested18: StructRecord18
      Nested24: StructRecord24 }

let updateSimpleNestedRecord3 (i: int) (record: SimpleNestedRecord3) = { record with Nested3.IntValue = i }
let updateStructNestedRecord3 (i: int) (record: StructNestedRecord3) = { record with Nested3.IntValue = i }
let updateSimpleNestedRecord6 (i: int) (record: SimpleNestedRecord6) = { record with Nested6.IntValue = i }
let updateStructNestedRecord6 (i: int) (record: StructNestedRecord6) = { record with Nested6.IntValue = i }
let updateSimpleNestedRecord12 (i: int) (record: SimpleNestedRecord12) = { record with Nested12.IntValue = i }
let updateStructNestedRecord12 (i: int) (record: StructNestedRecord12) = { record with Nested12.IntValue = i }
let updateSimpleNestedRecord18 (i: int) (record: SimpleNestedRecord18) = { record with Nested18.IntValue = i }
let updateStructNestedRecord18 (i: int) (record: StructNestedRecord18) = { record with Nested18.IntValue = i }
let updateSimpleNestedRecord24 (i: int) (record: SimpleNestedRecord24) = { record with Nested24.IntValue = i }
let updateStructNestedRecord24 (i: int) (record: StructNestedRecord24) = { record with Nested24.IntValue = i }

let simpleNested3: SimpleNestedRecord3 = { Nested3 = simple3 }
let simpleNested6: SimpleNestedRecord6 = { Nested3 = simple3; Nested6 = simple6 }

let simpleNested12: SimpleNestedRecord12 =
    { Nested3 = simple3
      Nested6 = simple6
      Nested12 = simple12 }

let simpleNested18: SimpleNestedRecord18 =
    { Nested3 = simple3
      Nested6 = simple6
      Nested12 = simple12
      Nested18 = simple18 }

let simpleNested24: SimpleNestedRecord24 =
    { Nested3 = simple3
      Nested6 = simple6
      Nested12 = simple12
      Nested18 = simple18
      Nested24 = simple24 }

let structNested3: StructNestedRecord3 = { Nested3 = struct3 }
let structNested6: StructNestedRecord6 = { Nested3 = struct3; Nested6 = struct6 }

let structNested12: StructNestedRecord12 =
    { Nested3 = struct3
      Nested6 = struct6
      Nested12 = struct12 }

let structNested18: StructNestedRecord18 =
    { Nested3 = struct3
      Nested6 = struct6
      Nested12 = struct12
      Nested18 = struct18 }

let structNested24: StructNestedRecord24 =
    { Nested3 = struct3
      Nested6 = struct6
      Nested12 = struct12
      Nested18 = struct18
      Nested24 = struct24 }

[<MemoryDiagnoser>]
type NestedRecordBenchmarks() =
    [<Params(10, 100, 1000)>]
    member val N = 0 with get, set

    member val data: int seq = seq {  } with get, set
    member val recData: int list = [] with get, set

    // records -----------------------------------------------------------------
    [<GlobalSetup>]
    member __.GlobalSetup() =
        __.data <- seq { 1 .. __.N }
        __.recData <- seq { 1 .. __.N } |> List.ofSeq

    // Nested records ----------------------------------------------------------
    [<Benchmark>]
    member __.SimpleNestedRecord3() =
        Seq.foldBack updateSimpleNestedRecord3 __.data simpleNested3

    [<Benchmark>]
    member __.StructNestedRecord3() =
        Seq.foldBack updateStructNestedRecord3 __.data structNested3

    [<Benchmark>]
    member __.SimpleNestedRecord3rec() =
        recFoldBack updateSimpleNestedRecord3 __.recData simpleNested3

    [<Benchmark>]
    member __.StructNestedRecord3rec() =
        recFoldBack updateStructNestedRecord3 __.recData structNested3

    [<Benchmark>]
    member __.SimpleNestedRecord6() =
        Seq.foldBack updateSimpleNestedRecord6 __.data simpleNested6

    [<Benchmark>]
    member __.StructNestedRecord6() =
        Seq.foldBack updateStructNestedRecord6 __.data structNested6

    [<Benchmark>]
    member __.SimpleNestedRecord6rec() =
        recFoldBack updateSimpleNestedRecord6 __.recData simpleNested6

    [<Benchmark>]
    member __.StructNestedRecord6rec() =
        recFoldBack updateStructNestedRecord6 __.recData structNested6

    [<Benchmark>]
    member __.SimpleNestedRecord12() =
        Seq.foldBack updateSimpleNestedRecord12 __.data simpleNested12

    [<Benchmark>]
    member __.StructNestedRecord12() =
        Seq.foldBack updateStructNestedRecord12 __.data structNested12

    [<Benchmark>]
    member __.SimpleNestedRecord12rec() =
        recFoldBack updateSimpleNestedRecord12 __.recData simpleNested12

    [<Benchmark>]
    member __.StructNestedRecord12rec() =
        recFoldBack updateStructNestedRecord12 __.recData structNested12

    [<Benchmark>]
    member __.SimpleNestedRecord18() =
        Seq.foldBack updateSimpleNestedRecord18 __.data simpleNested18

    [<Benchmark>]
    member __.StructNestedRecord18() =
        Seq.foldBack updateStructNestedRecord18 __.data structNested18

    [<Benchmark>]
    member __.SimpleNestedRecord18rec() =
        recFoldBack updateSimpleNestedRecord18 __.recData simpleNested18

    [<Benchmark>]
    member __.StructNestedRecord18rec() =
        recFoldBack updateStructNestedRecord18 __.recData structNested18

    [<Benchmark>]
    member __.SimpleNestedRecord24() =
        Seq.foldBack updateSimpleNestedRecord24 __.data simpleNested24

    [<Benchmark>]
    member __.StructNestedRecord24() =
        Seq.foldBack updateStructNestedRecord24 __.data structNested24

    [<Benchmark>]
    member __.SimpleNestedRecord24rec() =
        recFoldBack updateSimpleNestedRecord24 __.recData simpleNested24

    [<Benchmark>]
    member __.StructNestedRecord24rec() =
        recFoldBack updateStructNestedRecord24 __.recData structNested24
