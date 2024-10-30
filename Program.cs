using Newtonsoft.Json;
string path = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "names.json"));
List<string> names = new List<string>();







AddName("Ilkin");
AddName("ISlam");
AddName("Hesen");
AddName("Kamil");



Console.WriteLine(Search("Ilkin"));

Remove("Ilkin");


names.ForEach(x => Console.WriteLine(x));









void GetJson(string path, List<string> names)
{
    string newresult;
    using (StreamReader sr = new(path))
    {
        newresult = sr.ReadToEnd();
    }
    names = JsonConvert.DeserializeObject<List<string>>(newresult);
}
void SetJson(string path, List<String> names)
{
    string result = JsonConvert.SerializeObject(names);
    using (StreamWriter sw = new(path))
        sw.WriteLine(result);
}
void AddName(string name)
{
    GetJson(path, names);
    names.Add(name);
    SetJson(path, names);
}

bool Search(string name)
{
    GetJson(path, names);
    return names.Find(x => x == name) != null;
}

void Remove(string name)
{
    GetJson(path, names);
    names.Remove(name);
    SetJson(path, names);
}
