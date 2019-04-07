using System.ComponentModel;

namespace lab5
{
    public class Country
    {
        public string ImageFileName { get; set; }
        [DisplayName("Name"), Category("Overall")]
        public string Name { get; set; }
        [DisplayName("Capital"), Category("Overall")]
        public string Capital { get; set; }
        [DisplayName("Population"), Category("Demography")]
        [Description("Population, in bln.people")]
        public double Population { get; set; }
        [DisplayName("Size"), Category("Overall")]
        [Description("Square in thousands sq. km.")]
        public double Size{ get; set; }
    }
}
