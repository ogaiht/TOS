import { Action, createReducer, on } from '@ngrx/store';
import { DEFAULT_PAGED_RESULT, PagedResult } from '../models/filter';
import { Skill } from '../models/skill.model';
import * as SkillActions from '../actions/skill.action';

export interface SkillState {
    skills: PagedResult<Skill>;
    loaded: boolean;
}

export const DEFAULT_SKILL_STATE: SkillState = {
    skills: {... DEFAULT_PAGED_RESULT},
    loaded: false
};

const skillReducerFunction = createReducer(
    DEFAULT_SKILL_STATE,
    on(SkillActions.loadSkills, (state: SkillState, { forceLoad }) => {
        if (forceLoad && state.loaded) {
            return { ...state, loaded: false };
        }
        return { ...state, submiting: true };}),
    on(SkillActions.loadSkillsComplete, (state: SkillState, { skills }) => ({ ...state, skills, loaded: true }))
);

export function skillReducer(state: SkillState | undefined, action: Action): SkillState {
    return skillReducerFunction(state, action);
}
