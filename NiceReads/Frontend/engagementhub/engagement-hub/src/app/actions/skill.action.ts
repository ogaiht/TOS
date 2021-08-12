import { createAction, props } from "@ngrx/store";
import { PagedResult } from "../models/filter";
import { SkillFilter } from "../models/skill.filter";
import { Skill } from "../models/skill.model";

export const loadSkills = createAction(
    '[Skill] Load',
    props<{ filter?: SkillFilter, forceLoad?: boolean }>()
);

export const loadSkillsComplete = createAction(
    '[Skill] Load Complete',
    props<{ skills: PagedResult<Skill> }>()
);

export const createSkill = createAction(
    '[Skill] Create',
    props<{ name: string, description: string }>()
);