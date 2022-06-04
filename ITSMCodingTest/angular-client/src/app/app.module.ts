import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddressBookService } from './services/addressbook.service';
import { AddressBookEntriesComponent } from './components/address-book-entries/address-book-entries.component';

@NgModule({
  declarations: [
    AppComponent,
    AddressBookEntriesComponent
  ],
  imports: [
    BrowserModule,
   HttpClientModule
  ],
  providers: [AddressBookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
