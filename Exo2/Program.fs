// Learn more about F# at http://fsharp.org

open System
open FSharp.Data
open XPlot.Plotly

let [<Literal>] connectionString = "Server=(local);Database=CleemyDepenses;Trusted_Connection=True;MultipleActiveResultSets=true"

[<EntryPoint>]
let main argv =
    use cmd = new SqlCommandProvider<"Select Date, Montant, UtilisateurId from Depenses WHERE UtilisateurId=@userId", connectionString>(connectionString)
    cmd.Execute(userId = 1) |> Seq.iter(fun r -> printfn "%s %f" (r.Date.ToShortDateString()) r.Montant) 
    0 // return an integer exit code
