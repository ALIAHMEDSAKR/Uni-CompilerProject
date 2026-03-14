using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CompilerProject.Core;
using CompilerProject.Models;

public class TinyScanner
{
    public List<Token> Tokens { get; private set; } = new List<Token>();
    public List<string> Errors { get; private set; } = new List<string>();

    // Pattern definitions based on Tiny PL rules
    private readonly string _pattern;

    public TinyScanner()
    {
        // Define individual patterns
        string comment = @"/\*[\s\S]*?\*/";
        string @string = @"""[^""]*""";
        string keywords = @"\b(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl|main)\b";
        string identifier = @"\b[a-zA-Z][a-zA-Z0-9]*\b";
        string number = @"\d+(\.\d+)?";
        string assignment = @":=";
        string operators = @"\+|\-|\*|/|=|<|\|\||&&";
        string symbols = @"\(|\)|\{|\}|,|;";

        // Combine into one master pattern with Named Groups
        _pattern = $"(?<Comment>{comment})|(?<String>{@string})|(?<Keyword>{keywords})|" +
                   $"(?<Identifier>{identifier})|(?<Number>{number})|(?<Assignment>{assignment})|" +
                   $"(?<Operator>{operators})|(?<Symbol>{symbols})";
    }

    public void Analyze(string input)
    {
        Tokens.Clear();
        Errors.Clear();

        Regex regex = new Regex(_pattern);
        MatchCollection matches = regex.Matches(input);

        int lastPos = 0;

        foreach (Match match in matches)
        {
            
            string gap = input.Substring(lastPos, match.Index - lastPos);
            if (!string.IsNullOrWhiteSpace(gap))
            {
                Errors.Add($"Lexical Error: Unrecognized token '{gap.Trim()}'");
            }

            // --- Token Classification ---
            if (match.Groups["Comment"].Success)
            {
                // we don't add comments to the token list for the parser, 
            }
            else if (match.Groups["String"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.String });
            else if (match.Groups["Keyword"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Keyword });
            else if (match.Groups["Identifier"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Identifier });
            else if (match.Groups["Number"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Number });
            else if (match.Groups["Assignment"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Assignment });
            else if (match.Groups["Operator"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Operator });
            else if (match.Groups["Symbol"].Success)
                Tokens.Add(new Token { Lexeme = match.Value, Type = TokenType.Symbol });

            lastPos = match.Index + match.Length;
        }

        // Check for trailing errors at the end of the file
        if (lastPos < input.Length)
        {
            string tail = input.Substring(lastPos).Trim();
            if (!string.IsNullOrEmpty(tail))
                Errors.Add($"Lexical Error: Unrecognized token '{tail}'");
        }
    }
}