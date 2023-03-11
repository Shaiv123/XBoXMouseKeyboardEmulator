﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxMouseKeyboardEmulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputMonitor = new XboxController();
            inputMonitor.Start();
            Console.WriteLine("XBox Controller to Mouse Keyboard has started");
            Console.ReadLine();
        }
    }
}
