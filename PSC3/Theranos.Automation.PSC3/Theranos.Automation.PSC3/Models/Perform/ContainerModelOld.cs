using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.Perform
{
    public class ContainerModelOld
    {
        public static string[] Containers = { "CTN (Purple)", "CTN (Green)", "Lavender Tube", "Light Green (Mint) Tube", "Light Blue Tube", "Gold (SST) Tube", "Tan Tube", "Pearl Tube", "NIL (Grey)", "TB Antigen (Red)", "Mitogen (Lavender)", "24 Hour Urine Kit", "Urine Collection Kit", "Sputum Collection", "Nasal Swab Kit", "Fecal Collection Kit", "Stool - 1 Card", "Stool - 3 Card", "Stool Collection Kit A", "Stool Collection Kit B", "Swab Kit" };
        public static List<string> TotalConatainers = Containers.ToList<string>();
        public string Name { get; set; }
        public string Count { get; set; }
    }
}
