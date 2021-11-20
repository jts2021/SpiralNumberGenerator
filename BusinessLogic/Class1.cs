using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Class1
    {

        private Dictionary<int, string> _numberMap;
        private Dictionary<int, string> _multipleMap;


        public Class1()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitalizeNumberMap();
            InitalizeMultipleMap();

           
        }

        private void InitalizeNumberMap()
        {
            _numberMap = new Dictionary<int, string>();

            _numberMap.Add(1, "one");
            _numberMap.Add(2, "two");
            _numberMap.Add(3, "three");
            _numberMap.Add(4, "four");
            _numberMap.Add(5, "five");
            _numberMap.Add(6, "six");
            _numberMap.Add(7, "seven");
            _numberMap.Add(8, "eight");
            _numberMap.Add(9, "nine");
            _numberMap.Add(10, "ten");
        }

        private void InitalizeMultipleMap()
        {
            _multipleMap = new Dictionary<int, string>();
        }

    }
}
