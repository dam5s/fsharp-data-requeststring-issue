open FSharp.Data
open System.Net.Http


let downloadWithSystemNet (url : string) : Result<string, string> =
    try
        (new HttpClient())
            .GetStringAsync(url)
            .GetAwaiter()
            .GetResult()
            |> Ok
    with
    | ex -> Error ex.Message


let downloadWithFsharpData (url : string) : Result<string, string> =
    try
        url
        |> Http.RequestString
        |> Ok
    with
    | ex -> Error ex.Message


let downloadAndOutput downloadFunction =
    match downloadFunction "https://www.lemonde.fr/rss/une.xml" with
    | Ok content ->
        printfn "Downloaded\n%s" content
        0
    | Error msg ->
        eprintfn "Could not download content: %s" msg
        1


[<EntryPoint>]
let main argv =
    match Array.tryHead argv with
    | Some "fsharp.data" -> downloadAndOutput downloadWithFsharpData
    | Some "system.net" -> downloadAndOutput downloadWithSystemNet
    | _ -> eprintfn "Run with one of the arguments: fsharp.data or system.net"; 1
