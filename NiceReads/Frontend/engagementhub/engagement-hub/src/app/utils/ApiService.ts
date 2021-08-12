import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const httpMethods = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    DELETE: 'DELETE'
};

@Injectable()
export class ApiService {

    public get<T>(url: string): Observable<T> {
        return new Observable<T>(observer => {
            this.executeRequest<T>(url)
            .then(r => observer.next(r))
            .catch(e => observer.error(e))
            .finally(() => observer.complete());
        });
    }

    public post<TPayload, TResult>(url: string, payload: TPayload): Observable<TResult> {
        return new Observable<TResult>(observer => {
            const requestInit:RequestInit = {
                method: httpMethods.POST,
                body: JSON.stringify(payload)
            };
            this.executeRequest<TResult>(url, requestInit)
            .then(r => observer.next(r))
            .catch(e => observer.error(e))
            .finally(() => observer.complete());
        });
    }

    public delete(url: string): Observable<void> {
        return new Observable<void>(observer => {
            const requestInit:RequestInit = {
                method: httpMethods.DELETE
            };
            this.executeRequest<void>(url, requestInit)
            .then(() => observer.next())
            .catch(e => observer.error(e))
            .finally(() => observer.complete());
        });
    }

    private async executeRequest<T>(url: string, requestInit?: RequestInit): Promise<T> {
        const response: Response = await fetch(url, requestInit)
        return await response.json();
    }
}