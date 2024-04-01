using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PartlySeriesOfNumbers
    {
        private IEnumerable<double> input, output;
        public PartlySeriesOfNumbers() { }
        public PartlySeriesOfNumbers(IEnumerable<double> row) 
        { 
            input = row;  
            output = GetRowSums(row);
        }
        public IEnumerable<double> GetRowSums(IEnumerable<double> row)
                => row.Select((x, i) => row.Take(i).Sum() + x);
        public override string ToString()
            => $"Input string: {String.Join(",", input)}; Output string: {String.Join(",", output)};";

        
    }
}
