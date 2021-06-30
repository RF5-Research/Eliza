using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Eliza.UI.Helpers
{
    public class Json
    {
        public static Dictionary<string, dynamic> Load(string path)
        {
            using (StreamReader fs = File.OpenText(path))
            {
                return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(fs.ReadToEnd());
            }
        }
    }
}
