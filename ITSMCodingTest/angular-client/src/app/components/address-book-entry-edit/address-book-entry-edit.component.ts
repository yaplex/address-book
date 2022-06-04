import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AddressBook } from 'src/app/models/address-book.model';
import { Country } from 'src/app/models/country.model';
import { NgForm } from '@angular/forms';
import { AddressBookService } from 'src/app/services/addressbook.service';

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

  allCountries: Array<Country> = [];
  constructor(private addressBookService: AddressBookService) {
    this.allCountries.push(new Country("Canada", "CA", "CAD"));
    this.allCountries.push(new Country("USA", "US", "USA"));
    this.allCountries.push(new Country("Germany", "DE", "DEU"));
    this.allCountries.push(new Country("Australia", "AU", "AUS"));
  }

  ngOnInit(): void {
  }

  onSaveAddressBookEntity(f: NgForm): void {
    if (f.valid) {
      console.log("Form Submitted!");
      this.addressBookService.save(f.value).subscribe(data => {
        this.recordSavedUpdatedEvent.emit();
      });
    }
  }
}
