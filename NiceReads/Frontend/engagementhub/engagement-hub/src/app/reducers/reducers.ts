import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app-state';
import { employeeReducer } from './employee.reducer';
import { skillReducer } from './skill.reducer';

export const REDUCERS: ActionReducerMap<AppState> = {
    employee: employeeReducer,
    skill: skillReducer
};