using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompilerProject.Models;

namespace CompilerProject.Core
{
    public class Token
    {
        public string Lexeme { get; set; }
        public TokenType Type { get; set; }
    }
}
