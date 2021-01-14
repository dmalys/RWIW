using Newtonsoft.Json;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace RwiwProject.Models
{
    public class Architecture
    {
        public int DependencyNumber { get; set; }
        public int AcceptableDowntime { get; set; }
        public int SyncronicUserNumber { get; set; }
        public int PacketNumberPerSession { get; set; }
        public ApplicationComplexity ApplicationComplexity { get; set; }
        public DataTypes DataTypeUsed { get; set; }


        public ArchitectureType ArchitectureTypeChosen { get; set; }
        public string ResponseDecision { get; set; }

        public void CreateResponse(ArchitectureType architectureTypeChosen, string responseDecision)
        {
            ArchitectureTypeChosen = architectureTypeChosen;
            ResponseDecision = responseDecision;
        }

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
    }
}
