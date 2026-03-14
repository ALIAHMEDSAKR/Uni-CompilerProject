namespace CompilerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TinyScanner scanner = new TinyScanner();
            scanner.Analyze("int val, counter;\r\nread val;\r\ncounter:=0;   " +
                "                                                                             \r\nrepeat    " +
                "                                                                            \r\nval := val - 1;\r\nwrite \"Iteration number [\";\r\nwrite counter;\r\nwrite \"] the value of x = \";\r\nwrite val;\r\nwrite endl;                       " +
                "   \r\ncounter := counter+1;                                                      \r\nuntil val = 1                                                                                  \r\nwrite endl;                                                   " +
                "                             \r\nstring s := \"number of Iterations = \";\r\nwrite s;                                                                                \r\ncounter:=counter-1;\r\nwrite counter;\r\n/* complicated equation */ " +
                "   \r\nfloat z1 := 3*2*(2+1)/2-5.3;\r\nz1 := z1 + sum(1,y);\r\nif  z1 > 5 || z1 < counter && z1 = 1 then \r\nwrite z1;\r\nelseif z1 < 5 then\r\nz1 := 5;\r\nelse\r\n         z1 := counter;\r\nend\r\nreturn 0;\r\n");
            foreach (var item in scanner.Tokens)
            {
                Console.WriteLine($"{item.Lexeme}");
                Console.WriteLine($"{item.Type}");
            }
        }
    }
}
