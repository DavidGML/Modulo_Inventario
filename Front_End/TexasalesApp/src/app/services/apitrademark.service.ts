import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders} from '@angular/common/http/';
import { Observable } from 'rxjs';

import { Response } from '../models/response';
import { Trademark } from '../models/trademark';

const httpOptions = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ApitrademarkService {

  url: string = 'https://localhost:44325/api/trademark';

  constructor(
    private _http: HttpClient
  ) { }

    getTrademark(): Observable<Response> {
      return this._http.get<Response>(this.url);
    }

    addTrademark( trademar: Trademark): Observable<Response> {
      return this._http.post<Response>(this.url,trademar,httpOptions);
    }

    editTrademark( trademar: Trademark): Observable<Response> {
      return this._http.put<Response>(this.url,trademar,httpOptions);
    }

    deleteTrademark( tmId:number ): Observable<Response> {
      return this._http.delete<Response>(`${this.url}/${tmId}`);
    }
}
