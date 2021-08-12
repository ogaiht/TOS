import { Injectable } from '@angular/core';

const URI_JOIN = '/';

@Injectable()
export class URLBuilder {

    private baseUrl: string = '';

    constructor() { }

    public setBaseUrl(url: string): void {
        this.baseUrl = url;
    }

    public build(uri: string | string[], queryString?: any): string {
        const urlSegments:string[] = [this.baseUrl, URI_JOIN, Array.isArray(uri) ? uri.join(URI_JOIN) : uri];
        this.buildQuerystring(urlSegments, queryString);
        return urlSegments.join('');
    }

    private buildQuerystring(urlSegments: string[], queryString: any): void {
        if (!!queryString) {
            const queryStringSegments: string[] = [];
            Object
                .getOwnPropertyNames(queryString)
                .forEach((property: string) => {
                    const value: any = queryString[property];
                    if (value !== undefined && value !== null) {
                        queryStringSegments.push(`${property}=${queryString[property]}`);
                    }
                });
            if (queryStringSegments.length > 0) {
                urlSegments.push('?' + queryStringSegments.join('&'));
            }
        }
    }
}