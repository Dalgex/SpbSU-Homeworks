open System.Net
open System.IO
open System.Text.RegularExpressions

let informationAboutPage(url) =
    let returnHtml(url: string) =
        let request = WebRequest.Create(url)
        use response = request.GetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        html
    
    let regularExpression = new Regex("<a href=\"http://.+?\">")
    let allUrls = regularExpression.Matches(returnHtml(url))
    let expr (value : string) = value.Substring(value.IndexOf("=\"") + 2 , value.IndexOf("\">") - value.IndexOf("=\"") - 2)

    let fetchAsync(url : string) =
        async {
            try
                let request = WebRequest.Create(url)
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let html = reader.ReadToEndAsync()
                let! htmlTask = Async.AwaitTask(html)
                do printfn "%s --- %d" url htmlTask.Length
            with
                | exeption -> printfn "%s" exeption.Message
        }

    let tasks = [for url in allUrls -> 
                     let value = url.Value
                     fetchAsync(expr value)]    
    Async.Parallel tasks |> Async.RunSynchronously |> ignore

informationAboutPage("http://news.sportbox.ru/")