import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResult } from '../models/filter';
import { SkillFilter } from '../models/skill.filter';
import { Skill } from '../models/skill.model';
import { EngagementHubApiService } from './engagement-hub-api.service';
import * as Uri from './route-uris';


@Injectable()
export class SkillService {

    constructor(private readonly apiService: EngagementHubApiService) { }

    public loadSkills(filter?: SkillFilter): Observable<PagedResult<Skill>> {
        return this.apiService.get(Uri.SKILLS, filter);
    }
}