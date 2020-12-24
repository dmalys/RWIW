using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace RwiwProject.Models
{
    public class Architecture
    {
        //public ArchitectureType ArchitectureType { get; set; }
        public int DependencyNumber { get; set; }
        public int AcceptableDowntime { get; set; }
        public int SyncronicUserNumber { get; set; }
        public int PacketNumberPerSession { get; set; }
        public ApplicationComplexity ApplicationComplexity { get; set; }
        public DataTypes DataTypeUsed { get; set; }

        public Architecture(
            int dependencyNumber,
            int acceptableDowntime,
            int syncronicUserNumber,
            int packetNumberPerSession,
            ApplicationComplexity applicationComplexity,
            DataTypes dataTypeUsed
            )
        {
            DependencyNumber = dependencyNumber;
            AcceptableDowntime = acceptableDowntime;
            SyncronicUserNumber = syncronicUserNumber;
            PacketNumberPerSession = packetNumberPerSession;
            ApplicationComplexity = applicationComplexity;
            DataTypeUsed = dataTypeUsed;
        }

        public void ArchitectureDecision(string ruleDecision, ArchitectureType architectureType)
        {
            Console.WriteLine("Your architecture should be {0}, because of: \n{1}", architectureType, ruleDecision);
        }
    }
}
