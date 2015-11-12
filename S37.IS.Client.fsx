#r @"d:\Code\csharp\S37.IS\S37.IS.Client\bin\Debug\S37.IS.Client.dll"

open S37.IS.Client.Workflow
open System
open System.IO

let publish message =
    let pipeline = new MessagePipeline()
    pipeline.Push message

let result = publish "Hello, world!"
result.Wait()
result.Status


let getFiles path =
    let query = new DirectoryInfo(path)
    printfn "%A" (query.EnumerateFiles())
    
let createFiles path =
    for n in [1..1000] do
        let filename = Path.Combine(path, String.Format("{0}.txt", n))
        if n % 100 = 0 then printfn "Creating file...%s" filename 
        File.WriteAllText(filename, n.ToString())
