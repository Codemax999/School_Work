import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { GoogleService } from './services/google.service';
import { FacebookService } from './services/facebook.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    ReactiveFormsModule
  ],
  providers: [
    GoogleService,
    FacebookService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
