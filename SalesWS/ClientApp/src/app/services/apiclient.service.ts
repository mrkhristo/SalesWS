import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response';
import { Client } from '../models/client';

const httpOption = {
  Headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiclientService {
  url: string = 'http://localhost:5157/api/client';
  constructor(
    private _http: HttpClient
  ) { }

  getAll(): Observable<ApiResponse> {
    return this._http.get<ApiResponse>(`${this.url}/get-all`);
  }

  add(client: Client): Observable<ApiResponse> {
    return this._http.post<ApiResponse>(`${this.url}/add`, client);
  }

}
