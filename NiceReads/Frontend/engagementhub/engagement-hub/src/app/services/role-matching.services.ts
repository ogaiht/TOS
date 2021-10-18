import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResult } from '../models/filter';
import { RoleFilter } from '../models/role-filter';
import { Role } from '../models/role.model';
import { EngagementHubApiService } from './engagement-hub-api.service';
import * as URI from './route-uris';

@Injectable()
export class RoleMatchingService {
    constructor(private readonly apiService: EngagementHubApiService) { }

    public findMatchingEmployees(employeeId: string, filter?: RoleFilter): Observable<PagedResult<Role>> {
        return this.apiService.get<PagedResult<Role>>([URI.MATCHING, URI.EMPLOYEES, employeeId, URI.ROLES], filter);
    }
}