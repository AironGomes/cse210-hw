using System;
using System.Collections.Generic;

public class PromptGenerator 
{

    public static List<string> _prompts = new List<string>() 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Who did I help today?",
        "What did I learn today?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int position = randomGenerator.Next(1, _prompts.Count-1);
        return _prompts[position];
    }
    
}