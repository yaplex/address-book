import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddressBook } from '../models/address-book.model';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'multipart/form-data'
  })
};
@Injectable({
  providedIn: 'root'
})

export class AddressBookService {
  public API = '/api';
  public ADDRESS_BOOK_ENDPOINT = `${this.API}/AddressBook`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<AddressBook>> {
    return this.http.get<Array<AddressBook>>(this.ADDRESS_BOOK_ENDPOINT);
  }

  save(record: AddressBook): Observable<AddressBook> {
    if (record.Id) {
      // update PUT
      return this.http.put<AddressBook>(`${this.ADDRESS_BOOK_ENDPOINT
        }/${record.Id}`, record);
    } else {
      // create POST
      return this.http.post<AddressBook>(this.ADDRESS_BOOK_ENDPOINT, record);
    }
  }

  delete(recordId: number): Observable<number> {
    return this.http.delete<number>(`${this.ADDRESS_BOOK_ENDPOINT
      }/${recordId}`);
  }

  uploadPhoto(photo: File): Observable<string> {
    const formData = new FormData();
    formData.append("file", photo, photo.name);
    return this.http.post<string>(`${this.ADDRESS_BOOK_ENDPOINT}/upload`, formData);
  }

}
