using NRules.Fluent.Dsl;
using RwiwProject.Models;

namespace RwiwProject.Rules
{
    [Priority(10)]
    public class FirstRule : Rule
    {
        public override void Define()
        {
            Architecture architecture = null;

            When()
                .Match<Architecture>(() => architecture, a => a.AcceptableDowntime <= 3);

            Then()
                .Do(_ => architecture.ArchitectureDecision("Acceptable downtime is too low to use serverless architecture.", ArchitectureType.Server));
        }
    }

    [Priority(9)]
    public class SecondRule : Rule
    {
        public override void Define()
        {
            Architecture architecture = null;

            When()
                .Match<Architecture>(() => architecture, a => a.ApplicationComplexity == ApplicationComplexity.Big);

            Then()
                .Do(_ => architecture.ArchitectureDecision("Application complexity is too complicated to use serverless architecture.", ArchitectureType.Server));
        }
    }

    [Priority(8)]
    public class ThirdRule : Rule
    {
        public override void Define()
        {
            Architecture architecture = null;

            When()
                .Match<Architecture>(() => architecture, a => a.DependencyNumber > 50
                                                        && a.SyncronicUserNumber > 50
                                                        && a.PacketNumberPerSession > 100)
                .Not<Architecture>(a => a.DependencyNumber <= 50
                                                        || a.SyncronicUserNumber <= 50
                                                        || a.PacketNumberPerSession <= 100); ;

            Then()
                .Do(_ => architecture.ArchitectureDecision("Dependency number, synchronic users number and packet numbers per session" +
                " will have too high impact on your application using serverless architecture.", ArchitectureType.Server));
        }
    }

    [Priority(7)]
    public class SixthRule : Rule
    {
        public override void Define()
        {
            Architecture architecture = null;

            When()
                .Match<Architecture>(() => architecture, a => a.DataTypeUsed == DataTypes.SensitiveData);

            Then()
                .Do(_ => architecture.ArchitectureDecision("Data type used suggests to use server architecture for security reasons/assurance.", ArchitectureType.Server));
        }
    }

    [Priority(0)]
    public class SeventhRule : Rule
    {
        public override void Define()
        {
            Architecture architecture = null;

            When()
                .Match<Architecture>(() => architecture, 
                    a => a.AcceptableDowntime > 3
                    && a.ApplicationComplexity != ApplicationComplexity.Big
                    && a.DataTypeUsed != DataTypes.SensitiveData
                    && a.PacketNumberPerSession > 0
                    && a.SyncronicUserNumber > 0
                    && a.DependencyNumber > 0
                )
                .Not<Architecture>(a => a.DependencyNumber > 50
                                                        && a.SyncronicUserNumber > 50
                                                        && a.PacketNumberPerSession > 100);

            Then()
                .Do(_ => architecture.ArchitectureDecision("Your preferences suggests to use serverless architecture.", ArchitectureType.Serverless));
        }
    }
}