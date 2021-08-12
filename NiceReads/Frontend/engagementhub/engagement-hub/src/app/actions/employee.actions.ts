import { createAction, props } from '@ngrx/store';
import { Employee } from '../models/employee.model';
import { PagedResult } from '../models/filter';

export const loadEmployee = createAction(
    '[Employee] Load',
    props<{ name?: string, offset?: number, limit?: number, forceLoad?: boolean }>()
);

export const loadEmployeeComplete = createAction(
    '[Employee] Load Complete',
    props<{ employees: PagedResult<Employee> }>()
);

export const createEmployee = createAction(
    '[Employee] Create',
    props<{employee: Employee }>()
);

export const createEmployeeComplete = createAction(
    '[Employee] Create Complete',
    props<{ employeeId: string }>()
);

export const updateEmployee = createAction(
    '[Employee] Update',
    props<{ employeeId: string, employee: Employee }>()
);

export const updateEmployeeComplete = createAction(
    '[Employee] Update Complete'
);

export const deleteEmployee = createAction(
    '[Employee] Delete',
    props<{ employeeId: string }>()
);

export const deleteEmployeeComplete = createAction(
    '[Employee] Delete Complete'
);