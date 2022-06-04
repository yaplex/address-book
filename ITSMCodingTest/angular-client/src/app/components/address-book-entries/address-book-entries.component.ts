import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AddressBook } from '../../models/address-book.model';
import { AddressBookService } from '../../services/addressbook.service';
declare var $: any;

@Component({
  selector: 'app-address-book-entries',
  templateUrl: './address-book-entries.component.html',
  styleUrls: ['./address-book-entries.component.sass']
})
export class AddressBookEntriesComponent implements OnInit {
  addressBookRecords: Array<AddressBook> = [];

  @Output() selectedAddressBookEvent = new EventEmitter<AddressBook>();

  constructor(private addressBookService: AddressBookService) { }
  ngOnInit(): void {
    this.addressBookService.getAll().subscribe(data => {
      this.addressBookRecords = data;
    })
  }

  recordSelected(record: AddressBook): void{
    this.selectedAddressBookEvent.emit(record);
  }

  addClass(event: any): void {
    $(event.target).addClass("hover");
  }

  removeClass(event: any): void {
    $(event.target).removeClass("hover");
  }
}
