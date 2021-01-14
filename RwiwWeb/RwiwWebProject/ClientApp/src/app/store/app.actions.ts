import { Architecture } from "../models/architecture";

export class CreateArchitecture {
  static readonly type = '[App] Create Architecture';
  constructor(public archRequest: Architecture) {}
}

export class ClearResult {
  static readonly type = '[App] Clear Result';
}
