import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddressBook } from '../models/address-book.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class AddressBookService {
  public API = '/api';
  public ADDRESS_BOOK_ENDPOINT = `${this.API}/addressbook`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<AddressBook>> {
    return this.http.get<Array<AddressBook>>(this.ADDRESS_BOOK_ENDPOINT);
  }

  save(record: AddressBook): Observable<AddressBook> {
    if (record.Id) {
      // update PUT
      return this.http.put<AddressBook>(`${this.ADDRESS_BOOK_ENDPOINT
        }/${record.Id}`, record, httpOptions);
    } else {
      // create POST
      return this.http.post<AddressBook>(this.ADDRESS_BOOK_ENDPOINT, record, httpOptions);
    }
  }

}