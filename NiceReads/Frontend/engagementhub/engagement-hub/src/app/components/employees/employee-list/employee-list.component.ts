import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { AppState } from 'src/app/reducers/app-state';
import { selectEmployees } from 'src/app/selectors/employee.selectors';
import * as EmployeeActions from 'src/app/actions/employee.actions';
import { PagedResult } from 'src/app/models/filter';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  employees$: Observable<PagedResult<Employee>>;

  constructor(private readonly store: Store<AppState>) {
    this.employees$ = this.store.select(selectEmployees);
   }

  ngOnInit(): void {
    this.store.dispatch(EmployeeActions.loadEmployee({ }));
  }

  public onNameSearchChange(event: Event): void {
    this.store.dispatch(EmployeeActions.loadEmployee({forceLoad: true, name: (event.target as HTMLInputElement).value}));
  }
}
