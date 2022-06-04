import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { AddressBook } from '../../models/address-book.model';
import { AddressBookService } from '../../services/addressbook.service';
declare var $: any;

@Component({
  selector: 'app-address-book-entries',
  templateUrl: './address-book-entries.component.html',
  styleUrls: ['./address-book-entries.component.sass']
})
export class AddressBookEntriesComponent implements OnInit, OnDestroy {
  addressBookRecords: Array<AddressBook> = [];
  @Input()
  reloadAllRecordsEvent!: Observable<void>;

  @Output() selectedAddressBookEvent = new EventEmitter<AddressBook>();

  private eventsSubscription!: Subscription;
  constructor(private addressBookService: AddressBookService) { }
  ngOnInit(): void {
    this.eventsSubscription = this.reloadAllRecordsEvent.subscribe(() => {
      this.loadAllRecords();
    });

    this.loadAllRecords();
  }
  ngOnDestroy() {
    this.eventsSubscription.unsubscribe();
  }

  recordSelected(record: AddressBook): void {
    this.selectedAddressBookEvent.emit(record);

    this.addressBookRecords.forEach(r => {
      r.IsActive = false;      
    });
    
    record.IsActive = true;
  }

  addClassActive(event: any): void {
    $(event.target).addClass("active");
  }

  addClassHover(event: any): void {
    $(event.target).addClass("hover");
  }

  removeClassHover(event: any): void {
    $(event.target).removeClass("hover");
  }

  loadAllRecords(): void {
    this.addressBookService.getAll().subscribe(data => {
      this.addressBookRecords = data;
    })
  }

}

