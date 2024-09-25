// See https://aka.ms/new-console-template for more information
/*
ToolCollection toolCollection = new ToolCollection();


toolCollection.Insert(new Tool("Hammer"));
toolCollection.Insert(new Tool("Spanner"));
toolCollection.Insert(new Tool("Anglegrinder"));
toolCollection.Insert(new Tool("Chisel"));
toolCollection.Insert(new Tool("Nail"));


ITool[] tools = toolCollection.ToArray();


for (int i = 0; i < tools.Length; i++)
{
    Console.WriteLine(tools[i].ToString());
}
*/
using System;
using System.Runtime.CompilerServices;

for (int i = 1000;  i <= 20000;  i += 1000) 
{
    Console.Write("Array Size = " + i + ": Count = ");
    IToolCollection tools = GenerateRandomTools(i);
    tools.ToArray();
}


static IToolCollection GenerateRandomTools(int size)
{
    ToolCollection newToolCollection = new ToolCollection();

    for (int i = 0; i < size; i++)
    {
        Tool tool = new Tool(GenerateRandomString());
        newToolCollection.Insert(tool);
    }
    return newToolCollection;

}
static string GenerateRandomString()
{
    Random random = new Random();

    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, 10)
        .Select(s => s[random.Next(s.Length)]).ToArray());
} 
