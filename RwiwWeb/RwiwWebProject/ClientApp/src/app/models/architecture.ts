import { AppComplexity } from "./app-complexity"
import { DataTypes } from "./data-types";

export interface Architecture {
  dependencyNumber: number,
  acceptableDowntime: number,
  syncronicUserNumber: number,
  packetNumberPerSession: number,
  applicationComplexity: AppComplexity,
  dataTypeUsed: DataTypes
}
