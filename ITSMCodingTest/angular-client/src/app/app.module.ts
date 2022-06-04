import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddressBookService } from './services/addressbook.service';
import { AddressBookEntriesComponent } from './components/address-book-entries/address-book-entries.component';
import { AddressBookEntryViewComponent } from './components/address-book-entry-view/address-book-entry-view.component';
import { AddressBookEntryEditComponent } from './components/address-book-entry-edit/address-book-entry-edit.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AddressBookEntriesComponent,
    AddressBookEntryViewComponent,
    AddressBookEntryEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AddressBookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
