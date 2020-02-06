using System.Collections.Generic;



namespace TikTak.Objects
{
    public class ObjectIllness
    {

        public Dictionary<string,  List<string>> select { get; set; }
        public Dictionary<string, List<string>> from { get; set; }
        public Dictionary<string, List<string>> to { get; set; }
        public Dictionary<string, List<string>> date { get; set; }
        public Dictionary<string, List<string>> endingHours { get; set; }
        public Dictionary<string, List<string>> startingHours { get; set; }
        public Dictionary<string, List<string>> activity { get; set; }
    }
}

