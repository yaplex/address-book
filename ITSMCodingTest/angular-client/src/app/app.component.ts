import { Component } from '@angular/core';
import { AddressBook } from './models/address-book.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  showReadOnlyView: boolean = false;
  selectedAddressBookRecord: AddressBook = new AddressBook();

  selectedAddressBookRecordHandler(record: AddressBook): void{
    if(record){
      this.showReadOnlyView = true;
      this.selectedAddressBookRecord = record;
    }
  }
}
