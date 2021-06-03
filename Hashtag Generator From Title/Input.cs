using CsvHelper.Configuration;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtag_Generator_From_Title
{
    public class Input
    {
        public string Title { get; set; }
        public string AllTag { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
    }
    public sealed class InputMap : ClassMap<Input>
    {
        public InputMap()
        {
            AutoMap(System.Globalization.CultureInfo.InvariantCulture);
            Map(m => m.AllTag).Ignore();
            Map(m => m.Tag1).Ignore();
            Map(m => m.Tag2).Ignore();
            Map(m => m.Tag3).Ignore();
        }
    }
}
