import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routing } from './app.routes';

import { AppComponent } from './app.component';

import { GoogleService } from './services/google.service';
import { FacebookService } from './services/facebook.service';
import { HeaderComponent } from './components/header/header.component';
import { LandingComponent } from './components/landing/landing.component';
import { ResultsComponent } from './components/results/results.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LandingComponent,
    ResultsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    ReactiveFormsModule,
    Routing
  ],
  providers: [
    GoogleService,
    FacebookService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
