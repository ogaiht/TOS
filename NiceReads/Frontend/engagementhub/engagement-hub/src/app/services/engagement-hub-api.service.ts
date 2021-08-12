import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiService } from '../utils/ApiService';
import { URLBuilder } from '../utils/URLBuilder';

interface ApiResponse {
    status: string
}

interface ApiResponseWithData<T> extends ApiResponse {
    data: T
}

@Injectable()
export class EngagementHubApiService {

    constructor(
        private readonly apiServices: ApiService,
        private readonly urlBuilder: URLBuilder) {
            this.urlBuilder.setBaseUrl(environment.apiUrl);
        }

    public get<TResult>(uri: string | string[], queryString?: any): Observable<TResult> {
        const url: string = this.urlBuilder.build(uri, queryString);
        return this.apiServices
            .get<ApiResponseWithData<TResult>>(url)
            .pipe(map((r: ApiResponseWithData<TResult>) => r.data));
    }

    public post<TPayload, TResult>(uri: string | string[], payload: TPayload): Observable<TResult> {
        const url: string = this.urlBuilder.build(uri);
        return this.apiServices.post<TPayload, TResult>(url, payload);
    }

    public delete(uri: string | string[]) : Observable<void> {
        const url: string = this.urlBuilder.build(uri);
        return this.apiServices.delete(url);
    }
}
