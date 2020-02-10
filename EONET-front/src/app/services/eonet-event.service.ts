import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { EonetEvent } from '../models/eonet-event';

@Injectable()
export class EventService {

    constructor(
        private http: HttpClient) { }

    getEvents(filterOptions: any): Observable<EonetEvent[]> {
        var params = new URLSearchParams(filterOptions).toString();
        return this.http.get<EonetEvent[]>("https://localhost:44305/Events?" + params)
            .pipe(
                tap(_ => console.log('fetched')),
                catchError(err => {
                    console.log('error: ', err);
                    throw err;
                }),
            );
    }

    getEvent(eventId: string): Observable<EonetEvent> {
        return this.http.get<EonetEvent>("https://localhost:44305/Events/" + eventId)
            .pipe(
                tap(_ => console.log('fetched detail')),
                catchError(err => {
                    console.log('error: ', err);
                    throw err;
                }),
            );
    }
}