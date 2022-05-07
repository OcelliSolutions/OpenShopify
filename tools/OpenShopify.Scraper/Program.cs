using HtmlAgilityPack;
using Newtonsoft.Json;

const string adminUrl = @"https://shopify.dev/api/admin-rest";
var web = new HtmlWeb();
var doc = web.Load(adminUrl);
Console.WriteLine("Getting Main Menu");
var menuScript = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");

var menuJson = menuScript.InnerText.Replace("//<![CDATA[", string.Empty).Replace("window.RailsData = ", string.Empty)
    .Replace("//]]>", string.Empty);
dynamic mainMenu = JsonConvert.DeserializeObject(menuJson.ReplaceLineEndings(string.Empty)) ??
                   throw new InvalidOperationException("No CDATA found for the main menu.");

SaveFile(@"../../../menu.json", mainMenu);


if (mainMenu.api.rest_sidenav is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The main menu did not return anything or the structure has changed.");
    Console.ResetColor();
}
else
{
    var currentVersion = (string)mainMenu.api.current_stable_version;
    foreach (var mainMenuItem in mainMenu.api.rest_sidenav)
    {
        var section = mainMenuItem.label;
        foreach (var child in mainMenuItem.children)
        {
            var subSection = child.label;
            Console.WriteLine($@"{section}/{subSection}.json");
            var url = $@"https://shopify.dev/api/admin-rest/{currentVersion}/resources/{child.key}";
            var childDoc = web.Load(url);
            var childScript = childDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/script[2]");
            var childJson = childScript.InnerText.Replace("//<![CDATA[", string.Empty)
                .Replace("window.RailsData = ", string.Empty).Replace("//]]>", string.Empty);
            dynamic childObject = JsonConvert.DeserializeObject(childJson) ??
                                  throw new InvalidOperationException("No CDATA returned.");
            var openApi = childObject.api.rest_resource;
            var path = $@"../../../{section}";
            CreateIfMissing(path);
            SaveFile($@"{path}/{subSection}.json", openApi);
        }
    }
}

Console.WriteLine("Core Structure Downloaded. Press any key to continue.");

void SaveFile(string file, object? content)
{
    File.WriteAllText(file, JsonConvert.SerializeObject(content, Formatting.Indented));
}

void CreateIfMissing(string path)
{
    var folderExists = Directory.Exists(path);
    if (!folderExists)
    {
        Directory.CreateDirectory(path);
    }
}