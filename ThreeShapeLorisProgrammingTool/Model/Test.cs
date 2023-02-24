﻿/// <copyright>3Shape A/S</copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeShapeLorisProgrammingTool.Test
{
    public class Test
    {
        const string pass = "PASS";
        const string fail = "FAIL";
        private string _result;
        public int Id { get; set; }
        public string Name { get; set; }
        public string value { get; set; }
        public string result
        {
            get { return _result; }
            set
            {
                if (value == pass)
                {
                    _result = value;
                }
                else if (value == fail)
                {
                    _result = value;
                }
            }
        }
    }
}