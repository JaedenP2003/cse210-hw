using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "What challenge did you overcome today?",
        "Who are you grateful for?",
        "What’s one thing you learned today?",
        "What’s something you’re looking forward to?"
    };

    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
