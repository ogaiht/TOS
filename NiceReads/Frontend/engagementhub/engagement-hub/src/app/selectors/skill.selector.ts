import { createFeatureSelector, createSelector } from '@ngrx/store';
import { PagedResult } from '../models/filter';
import { Skill } from '../models/skill.model';
import { AppState } from '../reducers/app-state';
import { SkillState } from '../reducers/skill.reducer';

export const getSkillState = createFeatureSelector<AppState, SkillState>('skill');

export const selectSkills = createSelector(
    getSkillState,
    (state: SkillState): PagedResult<Skill> => {
        return {... state.skills};
    }
);

export const areSkillsLoaded = createSelector(
    getSkillState,
    (state: SkillState): boolean => state.loaded
);