import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AddressBook } from './models/address-book.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.recordSavedUpdatedHandler();
  }
  showReadOnlyView: boolean = false;
  showEditView: boolean = false;
  canEditRecord: boolean = false;

  selectedAddressBookRecord: AddressBook = new AddressBook();
  reloadRecordsEvenSubject: Subject<void> = new Subject<void>();

  selectedAddressBookRecordHandler(record: AddressBook): void{
    if(record){
      this.showReadOnlyView = true;
      this.showEditView = false;
      this.selectedAddressBookRecord = record;
      this.canEditRecord = true;
    }
  }
  recordDeletedEventHander():void{
    this.showReadOnlyView = false;
    this.showEditView = false;
    this.selectedAddressBookRecord = new AddressBook();
    this.reloadRecordsEvenSubject.next();
  }

  recordSavedUpdatedHandler(): void{
    this.reloadRecordsEvenSubject.next();
  }

  editRecord(record: AddressBook):void{
    if(record){
      this.showReadOnlyView = false;
      this.showEditView = true;
    }
  }

  addNewEntry(): void{
    this.showReadOnlyView = false;
    this.showEditView = true;

    this.selectedAddressBookRecord = new AddressBook();
  }
}
