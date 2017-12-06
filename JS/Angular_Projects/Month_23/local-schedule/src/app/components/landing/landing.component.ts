import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GoogleService } from '../../services/google.service';
import { FacebookService } from '../../services/facebook.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent implements OnInit {

  // --- Component Variables ---
  form: FormGroup;
  city: string = '';
  schedule: Array<any>;
  venues: Array<any>;
  booked: Array<string>;
  noEvents: boolean = false;


  // --- Constructor ---
  constructor(
    public http: Http,
    public google: GoogleService,
    public facebook: FacebookService) { }


  // --- LifeCycle ---
  ngOnInit() {

    // initialize form 
    this.form = new FormGroup({
      city: new FormControl(this.city, Validators.maxLength(50))
    });
  }


  // --- Get Schedule ---
  getSchedule() {

    // reset no events
    this.noEvents = false;

    // get venues, for each get events
    this.google.geoLocate(this.city)
      .then(this.facebook.getVenues)
      .then(this.facebook.buildEventPaths)
      .then(this.facebook.getAllEvents)
      .then(this.facebook.sortEvents)
      .then(payload => {

        console.log('FINISHED', payload);

        // // no events: show local venues
        // if (!payload.allEvents.length) this.noEvents = true;

        // // events found: display schedule
        // const results = Array.from(payload.dates).sort((a, b) => a[0] - b[0]);
        // this.schedule = results;
        // this.venues = payload.venues;
      })
      .catch(console.error);
  }

  // remove venues that are booked
  filterVenues(venues: Array<any>): Array<any> {

    venues = venues.map(x => x.place.name);
    return this.venues.filter(x => !venues.includes(x.name));
  }
}
