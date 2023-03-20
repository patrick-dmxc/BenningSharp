// See https://aka.ms/new-console-template for more information
using BenningSharp.Manager;

string path = "C:\\Users\\Patrick\\Desktop\\LAV2022.db";
var runManager = RunManager.Instance;
DatabaseManager.Instance.OpenOrGetDatabase(path);
Console.ReadLine();