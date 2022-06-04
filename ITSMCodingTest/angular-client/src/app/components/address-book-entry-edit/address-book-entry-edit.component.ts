import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AddressBook } from 'src/app/models/address-book.model';
import { Country } from 'src/app/models/country.model';
import { NgForm } from '@angular/forms';
import { AddressBookService } from 'src/app/services/addressbook.service';
import { CountriesProviderService } from 'src/app/services/countries-provider.service';
declare var $: any;
@Component({
  selector: 'app-address-book-entry-edit',
  templateUrl: './address-book-entry-edit.component.html',
  styleUrls: ['./address-book-entry-edit.component.sass']
})
export class AddressBookEntryEditComponent implements OnInit {
  @Input()
  private _addressBookEditable: AddressBook = new AddressBook;

  public get addressBookEditable(): AddressBook {
    return this._addressBookEditable;
  }
  @Input() public set addressBookEditable(value: AddressBook) {
    this._addressBookEditable = Object.assign({}, value);
  }

  @Output() recordSavedUpdatedEvent = new EventEmitter<AddressBook>();
  @Output() recordDeletedEvent = new EventEmitter<AddressBook>();
  @Output() selectRecordEvent = new EventEmitter<AddressBook>();

  allCountries: Array<Country> = [];
  constructor(private addressBookService: AddressBookService, private countriesProviderService: CountriesProviderService) {
 
  }

  ngOnInit(): void {
    this.countriesProviderService.getAll().subscribe(data=>{
      this.allCountries = data;
    });
  }

  private showLoading(): void {
    $(".loading-overlay-panel").show();
  }

  private hideLoading(): void {
    $(".loading-overlay-panel").hide();
  }

  onSaveAddressBookEntity(f: NgForm): void {
    if (f.valid) {
      console.log("Form Submitted!");

      this.showLoading();
      this.addressBookService.save(f.value).subscribe(data => {
        this.hideLoading();
        this.selectRecordEvent.emit(f.value);
        this.recordSavedUpdatedEvent.emit();
      });
    }
  }

  selectRecord(record: AddressBook): void {
    this.selectRecordEvent.emit(record);
  }

  onDeleteRecord(recordId: number): void {
    console.info(`Deleting: ${recordId}`);
    this.showLoading();
    this.addressBookService.delete(recordId).subscribe(data => {
      this.hideLoading();
      this.recordDeletedEvent.emit();
    });
  }
}
