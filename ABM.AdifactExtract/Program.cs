﻿using System;
using System.Linq;

namespace ABM.AdifactExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            var edifact = @"UNA:+.? '
            UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'
            UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
            BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
            LOC+17+IT044100'
            LOC+18+SOL'
            LOC+35+SE'
            LOC+36+TZ'
            LOC+116+SE003033'
            DTM+9:20090527:102'
            DTM+268:20090626:102'
            DTM+182:20090527:102'
";

            var result = edifact.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Trim()
                .StartsWith("LOC+")).Select(i => i.Trim().Substring(0, i.Trim().IndexOf('\'')))
                .Select(line => line.Split('+').ToArray()).Select(items => new { firstElement = items[1], secondElement = items[2] }).ToList();

            result.ForEach(x => Console.WriteLine($"{x.firstElement}, {x.secondElement}"));
        }
    }
}
