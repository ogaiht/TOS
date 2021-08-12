import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PagedResult } from 'src/app/models/filter';
import { Skill } from 'src/app/models/skill.model';
import { AppState } from 'src/app/reducers/app-state';
import { selectSkills } from 'src/app/selectors/skill.selector';
import * as SkillActions from 'src/app/actions/skill.action';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.scss']
})
export class SkillListComponent implements OnInit {

  skills$: Observable<PagedResult<Skill>>;

  constructor(private readonly store: Store<AppState>) {
    this.skills$ = this.store.select(selectSkills);
  }

  ngOnInit(): void {
    this.store.dispatch(SkillActions.loadSkills({}));
  }

  public onNameSearchChange(event: Event): void {
    this.store.dispatch(SkillActions.loadSkills({
      forceLoad: true,
      filter: {
        name: (event.target as HTMLInputElement).value
      }
    }));
  }
}
