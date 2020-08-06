import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Computador } from '../modelos/computador';
import { Observable } from 'rxjs';

@Injectable()
export class ComputadorService {
    constructor(private httpClient: HttpClient) { }

    getComputadorList(): Observable<Computador[]> {
        return this.httpClient.get<Computador[]>('/api/Machines');
    }
}
