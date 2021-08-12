import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Employee } from '../models/employee.model';
import { PagedResult } from '../models/filter';
import { AppState } from '../reducers/app-state';
import { EmployeeState } from '../reducers/employee.reducer';

export const getEmployeeState = createFeatureSelector<AppState, EmployeeState>('employee');

export const selectEmployees = createSelector(
    getEmployeeState,
    (state: EmployeeState): PagedResult<Employee> => {
        return {... state.employees};
    }
);

export const areEmployeesLoaded = createSelector(
    getEmployeeState,
    (state: EmployeeState): boolean => state.loaded
);