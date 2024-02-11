using System;
using System.ComponentModel.DataAnnotations;
using Develop05;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }

}