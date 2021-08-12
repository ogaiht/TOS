import { Action, createReducer, on } from '@ngrx/store';
import * as EmployeeActions from '../actions/employee.actions';
import { Employee } from '../models/employee.model';
import { DEFAULT_PAGED_RESULT, PagedResult } from '../models/filter';
import { Nullable } from '../utils/nullable';

export interface EmployeeState {
    employees: PagedResult<Employee>;
    selectedEmployee: Nullable<Employee>;
    loaded: boolean;
    submiting: boolean;
}

export const DEFAULT_EMPLOYEE_STATE: EmployeeState = Object.freeze({
    employees: { ...DEFAULT_PAGED_RESULT },
    selectedEmployee: null,
    loaded: false,
    submiting: false
});


const employeeReducerFunction = createReducer(
    DEFAULT_EMPLOYEE_STATE,
    on(EmployeeActions.createEmployee, (state: EmployeeState) => ({ ...state, submiting: true })),
    on(EmployeeActions.createEmployeeComplete, (state: EmployeeState) => ({ ...state, submiting: false })),
    on(EmployeeActions.loadEmployee, (state: EmployeeState, { forceLoad }) => {
        if (forceLoad && state.loaded) {
            return { ...state, submiting: true, loaded: false };
        }
        return { ...state, submiting: true };}),
    on(EmployeeActions.loadEmployeeComplete, (state: EmployeeState, { employees }) => ({ ...state, employees, loaded: true, submiting: false })),
    on(EmployeeActions.updateEmployee, (state: EmployeeState) => ({ ...state, submiting: true })),
    on(EmployeeActions.updateEmployeeComplete, (state: EmployeeState) => ({ ...state, submiting: false })),
    on(EmployeeActions.deleteEmployee, (state: EmployeeState) => ({ ...state, submiting: true })),
    on(EmployeeActions.deleteEmployeeComplete, (state: EmployeeState) => ({ ...state, submiting: false }))
);

export function employeeReducer(state: EmployeeState | undefined, action: Action): EmployeeState {
    return employeeReducerFunction(state, action);
}