using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzMVC.Models
{
    public class FizzBuzz
    {
        public int FizzValue { get; set; }
        public int BuzzValue { get; set; }
        // Instantiate a list of strings named Result
        public List<string> Results { get; set; } = new();
    }
}
