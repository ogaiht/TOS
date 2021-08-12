import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { filter, map, mergeMap, withLatestFrom } from 'rxjs/operators';
import { AppState } from '../reducers/app-state';
import { SkillService } from '../services/skill.service';
import * as SkillActions from '../actions/skill.action';
import { areSkillsLoaded } from '../selectors/skill.selector';
import { Skill } from '../models/skill.model';
import { of } from 'rxjs';
import { PagedResult } from '../models/filter';

@Injectable()
export class SkillEffects {
    constructor(
        private readonly actions$: Actions,
        private readonly store: Store<AppState>,
        private readonly skillService: SkillService
    ) { }

    loadSkills$ = createEffect(() => this.actions$
        .pipe(
            ofType(SkillActions.loadSkills),
            mergeMap(action => of(action)
                .pipe(
                    withLatestFrom(this.store.select(areSkillsLoaded)),
                    filter(([filterAction, loaded]) => !loaded),
                    mergeMap(([mergeAction, loaded]) => this.skillService.loadSkills(mergeAction.filter)
                        .pipe(
                            map((skills: PagedResult<Skill>) => SkillActions.loadSkillsComplete({skills}))
                        )
                    )
                )
            )
        )
    );
}