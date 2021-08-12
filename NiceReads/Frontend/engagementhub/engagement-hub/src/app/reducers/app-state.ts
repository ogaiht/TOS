import { DEFAULT_EMPLOYEE_STATE, EmployeeState } from './employee.reducer';
import { DEFAULT_SKILL_STATE, SkillState } from './skill.reducer';

export interface AppState {
    employee: EmployeeState;
    skill: SkillState;
}

export const DEFAULT_STATE: AppState = Object.freeze({
    employee: DEFAULT_EMPLOYEE_STATE,
    skill: DEFAULT_SKILL_STATE
});