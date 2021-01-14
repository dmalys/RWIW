import { Component } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { Result } from '../models/result';
import { ClearResult } from '../store/app.actions';
import { AppState } from '../store/app.state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  @Select(AppState.result) result$: Observable<Result>;

  constructor(private store: Store) {}

  public clearResult() {
    this.store.dispatch(new ClearResult());
  }
}
