using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AOC2020.Inputs
{
    public class AOCInput
    {
        public List<int> Input = new List<int>();

        public List<string> InputString = new List<string>();

        public AOCInput GetInput(string fileLocation)
        {
            AOCInput input = new AOCInput();

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                input = JsonConvert.DeserializeObject<AOCInput>(json);
            }

            return input;
        }
    }
}
