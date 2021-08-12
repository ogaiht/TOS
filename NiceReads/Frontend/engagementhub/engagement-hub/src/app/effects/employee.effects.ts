import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from '../reducers/app-state';
import { EmployeeService } from '../services/employee.service';
import * as EmployeeActions from '../actions/employee.actions';
import { exhaustMap, filter, map, mergeMap, withLatestFrom } from 'rxjs/operators';
import { of } from 'rxjs';
import { areEmployeesLoaded } from '../selectors/employee.selectors';
import { Employee } from '../models/employee.model';
import { PagedResult } from '../models/filter';

@Injectable()
export class EmployeeEffects {
    constructor(
        private readonly actions$: Actions,
        private readonly store: Store<AppState>,
        private readonly employeeService: EmployeeService
    ) {}

    loadEmployees$ = createEffect(() => this.actions$
        .pipe(
            ofType(EmployeeActions.loadEmployee),
            mergeMap(action => of(action)
                .pipe(
                    withLatestFrom(this.store.select(areEmployeesLoaded)),
                    filter(([filterAction, loaded]) => !loaded),
                    mergeMap(([mergeAction, loaded]) => this.employeeService.loadEmployees({
                        name: mergeAction.name,
                        offset: mergeAction.offset,
                        limit: mergeAction.limit
                    }).pipe(
                            map((employees: PagedResult<Employee>) => EmployeeActions.loadEmployeeComplete({employees}))
                        )
                    )
                )
            )
        )
    );

    createEmployee$ = createEffect(() => this.actions$
        .pipe(
            ofType(EmployeeActions.createEmployee),
            exhaustMap(action => this.employeeService.createEmployee(action.employee)
                .pipe(map((employeeId: string) => EmployeeActions.createEmployeeComplete({ employeeId })))

            )
        )
    );

    // updatedEmployee$: Observable<EmployeeActions.UpdateEmployeeCompleteAction> = createEffect(() => this.actions$
    //     .pipe(
    //         ofType(EmployeeActions.UPDATE),
    //         exhaustMap((action: EmployeeActions.UpdateEmployeeAction) => this.employeeService.(action.payload.employee)
    //             .pipe(map((employeeId: string) => new EmployeeActions.CreateEmployeeCompleteAction({ employeeId })))

    //         )
    //     )
    // );
}