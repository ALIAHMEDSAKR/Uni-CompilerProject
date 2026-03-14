using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerProject.Core
{
    public static class TinyLanguageConstants
    {
        public const string Comment = @"/\*[\s\S]*?\*/";
        public const string String = @"""[^""]*""";
        public const string ReservedKeywords = @"\b(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl|main)\b";
        public const string Identifier = @"\b[a-zA-Z][a-zA-Z0-9]*\b";
        public const string Number = @"\d+(\.\d+)?";
        public const string Assignment = @":=";
        public const string Operators = @"\+|\-|\*|/|=|<|\|\||&&";
        public const string Symbols = @"\(|\)|\{|\}|,|;";
    }
}
