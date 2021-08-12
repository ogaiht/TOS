import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeFilter } from '../models/employee-filter';
import { Employee } from '../models/employee.model';
import { PagedResult } from '../models/filter';
import { EngagementHubApiService } from './engagement-hub-api.service';

import * as URI from './route-uris';

@Injectable()
export class EmployeeMatchingService {
    constructor(private readonly apiService: EngagementHubApiService) { }

    public findMatchingEmployees(roleId: string, filter?: EmployeeFilter): Observable<PagedResult<Employee>> {
        return this.apiService.get<PagedResult<Employee>>([URI.MATCHING, URI.ROLES, roleId, URI.EMPLOYEES], filter);
    }
}