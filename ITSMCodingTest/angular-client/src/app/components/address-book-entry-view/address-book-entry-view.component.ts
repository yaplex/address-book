import { Component, Input, OnInit } from '@angular/core';
import { AddressBook } from 'src/app/models/address-book.model';

@Component({
  selector: 'app-address-book-entry-view',
  templateUrl: './address-book-entry-view.component.html',
  styleUrls: ['./address-book-entry-view.component.sass']
})
export class AddressBookEntryViewComponent implements OnInit {

  @Input() addressBookReadOnly: AddressBook = new AddressBook();

  constructor() { }

  ngOnInit(): void {
  }

}
