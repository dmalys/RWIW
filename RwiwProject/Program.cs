using NRules;
using NRules.Fluent;
using RwiwProject.Models;
using RwiwProject.Rules;
using System;

namespace RwiwProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(FirstRule).Assembly));

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            //Load domain model
            var architecture = new Architecture(51, 4, 51, 101, ApplicationComplexity.Average, DataTypes.Normal);
            
            //Insert facts into rules engine's memory
            session.Insert(architecture);

            //Start match/resolve/act cycle
            session.Fire();

            Console.WriteLine("I am thinking and ending here. \n");
        }
    }
}
