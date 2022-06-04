import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddressBook } from '../models/address-book.model';

@Injectable({
  providedIn: 'root'
})
export class AddressBookService {
  public API = '/api';
  public GET_ALL_RECORDS_ENDPOINT =  `${this.API}/addressbook`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<AddressBook>> {
    return this.http.get<Array<AddressBook>>(this.GET_ALL_RECORDS_ENDPOINT);
  }
}
