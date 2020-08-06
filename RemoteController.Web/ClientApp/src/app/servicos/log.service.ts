import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Computador } from '../modelos/computador';
import { Observable } from 'rxjs';

@Injectable()
export class LogService {
    constructor(private httpClient: HttpClient) { }

    getLogList(id: number): Observable<Computador[]> {
        return this.httpClient.get<Computador[]>('/api/Log/' + id);
    }
}
