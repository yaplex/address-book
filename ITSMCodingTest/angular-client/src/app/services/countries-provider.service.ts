import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountriesProviderService {
  public API = '/api';
  public COUNTRIES_ENDPOINT = `${this.API}/CountriesProvider`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<Country>> {
    return this.http.get<Array<Country>>(this.COUNTRIES_ENDPOINT);
  }

}
