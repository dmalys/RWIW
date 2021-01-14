import { State, StateContext, Action, Selector } from '@ngxs/store';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ClearResult, CreateArchitecture } from './app.actions';
import { Result } from '../models/result';

export interface AppStateModel {
  result: Result;
}

@State<AppStateModel>({
  name: 'app',
  defaults: {
    result: null,
  },
})
@Injectable()
export class AppState {
  constructor(private http: HttpClient) { }

  @Action(CreateArchitecture)
  createArchitecture(ctx: StateContext<AppStateModel>, action: CreateArchitecture) {
    const url = `architecture`;
    const body = action.archRequest;

    return this.http.post<Result>(url, body)
      .pipe(
        tap((result: Result) => {
          ctx.patchState({ result })
        })
      );
  }

  @Action(ClearResult)
  clearResult(ctx: StateContext<AppStateModel>) {
    ctx.patchState({ result: null })
  }

  @Selector()
  static result(state: AppStateModel) {
    return state.result;
  }

}
