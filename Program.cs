Console.WriteLine("Hello, World!");

// Ok so:
// First, whe organize the data and write it into a dummy file
// Seccond, integrate with github to run it as a action

Environment.CurrentDirectory += "/../../..";

if (!File.Exists("dummy.md"))
{
    Console.Error.WriteLine("Please create a 'dummy,md' file to be used by the script!");
    return;
}

var flag_start = "<!--START_SECTION:lumi2021pf";
var flag_end = "<!--END_SECTION:lumi2021pf";
var flag_right = "-->";

var file_content = File.ReadAllLines("dummy.md").ToList();
List<(string cmd, int start, int end)> markers = [];

for (var i = 0; i < file_content.Count; i++) {
    if (file_content[i].StartsWith(flag_start) && file_content[i].EndsWith(flag_right))
    {
        var command = file_content[i][(flag_start.Length + 1)..(file_content[i].Length - flag_right.Length)];
        Console.WriteLine(command);
    }
}

File.WriteAllLines("dummi-after.md", file_content);