using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EarthdawnGamemasterAssistant.Racial;

namespace EarthdawnGamemasterAssistant
{
    internal static class Program
    {
        public static Dictionary<string, Character> DefaultCharacters = new Dictionary<string, Character>()
        {
            { "Dwarf", new Dwarf().CreateDefault()}
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}