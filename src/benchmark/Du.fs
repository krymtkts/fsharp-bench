module du

open BenchmarkDotNet.Attributes
open record

[<RequireQualifiedAccess>]
type SimpleDu3 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool

[<RequireQualifiedAccess>]
type SimpleDu6 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool

[<RequireQualifiedAccess>]
type SimpleDu12 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool

[<RequireQualifiedAccess>]
type SimpleDu18 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool
    | IntValue5 of i5: int
    | StringValue5 of s5: string
    | BoolValue5 of b5: bool
    | IntValue6 of i6: int
    | StringValue6 of s6: string
    | BoolValue6 of b6: bool

[<RequireQualifiedAccess>]
type SimpleDu24 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool
    | IntValue5 of i5: int
    | StringValue5 of s5: string
    | BoolValue5 of b5: bool
    | IntValue6 of i6: int
    | StringValue6 of s6: string
    | BoolValue6 of b6: bool
    | IntValue7 of i7: int
    | StringValue7 of s7: string
    | BoolValue7 of b7: bool
    | IntValue8 of i8: int
    | StringValue8 of s8: string
    | BoolValue8 of b8: bool

[<RequireQualifiedAccess>]
[<Struct>]
type StructDu3 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool

[<RequireQualifiedAccess>]
[<Struct>]
type StructDu6 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool

[<RequireQualifiedAccess>]
[<Struct>]
type StructDu12 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool

[<RequireQualifiedAccess>]
[<Struct>]
type StructDu18 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool
    | IntValue5 of i5: int
    | StringValue5 of s5: string
    | BoolValue5 of b5: bool
    | IntValue6 of i6: int
    | StringValue6 of s6: string
    | BoolValue6 of b6: bool

[<RequireQualifiedAccess>]
[<Struct>]
type StructDu24 =
    | IntValue1 of i1: int
    | StringValue1 of s1: string
    | BoolValue1 of b1: bool
    | IntValue2 of i2: int
    | StringValue2 of s2: string
    | BoolValue2 of b2: bool
    | IntValue3 of i3: int
    | StringValue3 of s3: string
    | BoolValue3 of b3: bool
    | IntValue4 of i4: int
    | StringValue4 of s4: string
    | BoolValue4 of b4: bool
    | IntValue5 of i5: int
    | StringValue5 of s5: string
    | BoolValue5 of b5: bool
    | IntValue6 of i6: int
    | StringValue6 of s6: string
    | BoolValue6 of b6: bool
    | IntValue7 of i7: int
    | StringValue7 of s7: string
    | BoolValue7 of b7: bool
    | IntValue8 of i8: int
    | StringValue8 of s8: string
    | BoolValue8 of b8: bool

let updateSimpleDu3 (i: int) du =
    match du with
    | SimpleDu3.IntValue1 _ -> SimpleDu3.IntValue1 i
    | _ -> du

let updateStructDu3 (i: int) du =
    match du with
    | StructDu3.IntValue1 _ -> StructDu3.IntValue1 i
    | _ -> du

let updateSimpleDu6 (i: int) du =
    match du with
    | SimpleDu6.IntValue1 _ -> SimpleDu6.IntValue1 i
    | _ -> du

let updateStructDu6 (i: int) du =
    match du with
    | StructDu6.IntValue1 _ -> StructDu6.IntValue1 i
    | _ -> du

let updateSimpleDu12 (i: int) du =
    match du with
    | SimpleDu12.IntValue1 _ -> SimpleDu12.IntValue1 i
    | _ -> du

let updateStructDu12 (i: int) du =
    match du with
    | StructDu12.IntValue1 _ -> StructDu12.IntValue1 i
    | _ -> du

let updateSimpleDu18 (i: int) du =
    match du with
    | SimpleDu18.IntValue1 _ -> SimpleDu18.IntValue1 i
    | _ -> du

let updateStructDu18 (i: int) du =
    match du with
    | StructDu18.IntValue1 _ -> StructDu18.IntValue1 i
    | _ -> du

let updateSimpleDu24 (i: int) du =
    match du with
    | SimpleDu24.IntValue1 _ -> SimpleDu24.IntValue1 i
    | _ -> du

let updateStructDu24 (i: int) du =
    match du with
    | StructDu24.IntValue1 _ -> StructDu24.IntValue1 i
    | _ -> du

[<MemoryDiagnoser>]
type DuBenchmarks() =

    [<Params(10, 100, 1000)>]
    member val N = 0 with get, set

    member val data: int seq = seq {  } with get, set
    member val recData: int list = [] with get, set

    // dus  --------------------------------------------------------------------
    [<GlobalSetup>]
    member __.GlobalSetup() =
        __.data <- seq { 1 .. __.N }
        __.recData <- seq { 1 .. __.N } |> List.ofSeq

    [<Benchmark>]
    member __.SimpleRecord3() =
        Seq.foldBack updateSimpleDu3 __.data (SimpleDu3.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord3() =
        Seq.foldBack updateStructDu3 __.data (StructDu3.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord3rec() =
        recFoldBack updateSimpleDu3 __.recData (SimpleDu3.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord3rec() =
        recFoldBack updateStructDu3 __.recData (StructDu3.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord6() =
        Seq.foldBack updateSimpleDu6 __.data (SimpleDu6.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord6() =
        Seq.foldBack updateStructDu6 __.data (StructDu6.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord6rec() =
        recFoldBack updateSimpleDu6 __.recData (SimpleDu6.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord6rec() =
        recFoldBack updateStructDu6 __.recData (StructDu6.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord12() =
        Seq.foldBack updateSimpleDu12 __.data (SimpleDu12.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord12() =
        Seq.foldBack updateStructDu12 __.data (StructDu12.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord12rec() =
        recFoldBack updateSimpleDu12 __.recData (SimpleDu12.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord12rec() =
        recFoldBack updateStructDu12 __.recData (StructDu12.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord18() =
        Seq.foldBack updateSimpleDu18 __.data (SimpleDu18.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord18() =
        Seq.foldBack updateStructDu18 __.data (StructDu18.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord18rec() =
        recFoldBack updateSimpleDu18 __.recData (SimpleDu18.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord18rec() =
        recFoldBack updateStructDu18 __.recData (StructDu18.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord24() =
        Seq.foldBack updateSimpleDu24 __.data (SimpleDu24.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord24() =
        Seq.foldBack updateStructDu24 __.data (StructDu24.IntValue1 1)

    [<Benchmark>]
    member __.SimpleRecord24rec() =
        recFoldBack updateSimpleDu24 __.recData (SimpleDu24.IntValue1 1)

    [<Benchmark>]
    member __.StructRecord24rec() =
        recFoldBack updateStructDu24 __.recData (StructDu24.IntValue1 1)
